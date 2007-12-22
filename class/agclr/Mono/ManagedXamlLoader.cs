//
// ManagedXamlLoader.cs
//
// Authors:
//   Rolf Bjarne Kvinge (RKvinge@novell.com)
//   Miguel de Icaza (miguel@ximian.com)
//
// Copyright 2007 Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Mono;

namespace Mono.Xaml
{
	internal class ManagedXamlLoader : XamlLoader	{
		// We keep an instance copy of the surface and plugin here,
		// since we're not ensuring that there can be only one of each
		// in each AppDomain.
		IntPtr surface;
		IntPtr plugin;
		IntPtr native_loader;
//		string filename;
//		string contents;
		static Dictionary<string, string> mappings = new Dictionary <string, string> ();
		XamlLoaderCallbacks callbacks;
		bool load_deps_synch = false;

#if WITH_DLR
		DLRHost dlr_host;
#endif
				
		public IntPtr PluginHandle {
			get {
				return plugin;
			}
		}
		
		public IntPtr NativeLoader {
			get {
				return native_loader;
			}
		}

		//
		// Set whenever the loader will load dependencies synchronously using the browser
		// This is used in cases where the user of the loader can't operate in async mode
		// such as Control:InitializeFromXaml ()
		//
		public bool LoadDepsSynch {
			set {
				load_deps_synch = value;
			}
		}
		
		public ManagedXamlLoader ()
		{
		}
		
		public void CreateNativeLoader (string filename, string contents)
		{
			//Console.WriteLine ("ManagedXamlLoader::CreateNativeLoader (): SurfaceInDomain: {0}", SurfaceInDomain);
			native_loader = NativeMethods.xaml_loader_new (filename, contents, SurfaceInDomain);
			
			if (native_loader == IntPtr.Zero)
				throw new Exception ("Unable to create native loader.");
			
			Setup (native_loader, PluginInDomain, SurfaceInDomain, filename, contents);
		}
		
		public void FreeNativeLoader ()
		{
			NativeMethods.xaml_loader_free (native_loader);
			native_loader = IntPtr.Zero;
		}
		
		public override void Setup (IntPtr native_loader, IntPtr plugin, IntPtr surface, string filename, string contents)
		{
			this.native_loader = native_loader;
			this.plugin = plugin;
			this.surface = surface;
//			this.filename = filename;
//			this.contents = contents;

			callbacks.load_managed_object = new LoadObjectCallback (cb_load_object);
			callbacks.set_custom_attribute = new SetAttributeCallback (cb_set_custom_attribute);
			callbacks.hookup_event = new HookupEventCallback (cb_hookup_event);
			callbacks.insert_mapping = new InsertMappingCallback (cb_insert_mapping);
			callbacks.get_mapping = new GetMappingCallback (cb_get_mapping);
			callbacks.load_code = new LoadCodeCallback (cb_load_code);
			callbacks.set_name_attribute = new SetNameAttributeCallback (cb_set_name_attribute);

			NativeMethods.xaml_loader_set_callbacks (native_loader, callbacks);
			
			if (plugin != IntPtr.Zero) {
				AppDomain.CurrentDomain.SetData ("PluginInstance", plugin);
				System.Windows.Interop.PluginHost.SetPluginHandle (plugin);
			}

			PluginInDomain = plugin;
			SurfaceInDomain = surface;
			
		}

		public string GetMapping (string key)
		{
			if (!mappings.ContainsKey (key))
				return null;
			return mappings [key];
		}
		
		public void InsertMapping (string key, string name)
		{
			//Console.WriteLine ("ManagedXamlLoader::InsertMapping ({0}, {1}).", key, name);
			if (mappings.ContainsKey (key)){
				Console.Error.WriteLine ("ManagedXamlLoader::InsertMapping ({0}, {1}): Inserting a duplicate key? (current value: {2}).", key, name, mappings [key]);
				return;
			}
			
			mappings [key] = name;
		}
		
		public void RequestFile (string asm_path)
		{
			Console.WriteLine ("ManagedXamlLoader::RequestFile ({0}).", asm_path);
			NativeMethods.xaml_loader_add_missing (native_loader, asm_path);
		}

		//
		// Tries to load the assembly.
		// Requests any referenced assemblies if necessary.
		//
		public AssemblyLoadResult LoadAssembly (string asm_path, string asm_name, out Assembly clientlib)
		{
			//Console.WriteLine ("ManagedXamlLoader::LoadAssembly (asm_path={0} asm_name={1})", asm_path, asm_name);
			
			clientlib = null;

			//
			// NOTE: Moonlight.LoadFile is only used for loading assemblies
			// for the desktop case (if Moonlight.RegisterLoader has been
			// called).   For browser use, the following block is a
			// no-op.
			//
			try {
				clientlib = Moonlight.LoadFile (asm_path);
				if (clientlib != null)
					return AssemblyLoadResult.Success;
				
			} catch (System.IO.FileNotFoundException) {
				//Console.WriteLine ("ManagedXamlLoader::LoadAssembly (asm_path={0} asm_name={1}): client library not found.", asm_path, asm_name);
				RequestFile (asm_path);
				return AssemblyLoadResult.MissingAssembly;
			}

			if (load_deps_synch) {
				//
				// FIXME: Move this support into the DependencyLoader
				//
				Console.WriteLine ("WARNING: ManagedXamlLoader Sync Assembly Loader has not been ported to use DependencyLoader");
				byte[] arr = LoadDependency (asm_path);
				if (arr != null)
					clientlib = Assembly.Load (arr);
				if (clientlib == null) {
					//Console.WriteLine ("ManagedXamlLoader::LoadAssembly (asm_path={0} asm_name={1}): could not load client library: {2}", asm_path, asm_name, asm_path);
					return AssemblyLoadResult.LoadFailure;
				}
				return AssemblyLoadResult.Success;
			} else {
				DependencyLoader dl = new DependencyLoader (this, asm_path);
				
				return dl.Load (ref clientlib);
			}
		}
		
		private IntPtr LoadObject (string asm_name, string asm_path, string ns, string type_name)
		{
			AssemblyLoadResult load_result;
			Assembly clientlib = null;
			string name;
			
			if (asm_name == null)
				throw new ArgumentNullException ("asm_name");
			
			if (asm_path == null)
				throw new ArgumentNullException ("asm_path");
						
			if (type_name == null)
				throw new ArgumentNullException ("type_name");
			
			load_result = LoadAssembly (asm_path, asm_name, out clientlib);
			
			if (load_result != AssemblyLoadResult.Success)
				return IntPtr.Zero;

			if (clientlib == null) {
				Console.WriteLine ("ManagedXamlLoader::LoadObject ({0}, {1}, {2}, {3}): Assembly loaded, but where is it?", asm_name, asm_path, ns, type_name);
				return IntPtr.Zero;
			}
			
			if (ns == null || ns == string.Empty)
				name = type_name;
			else
				name = String.Concat (ns, ".", type_name);

			object res = null;
			try {
				res = clientlib.CreateInstance (name);
			}
			catch (TargetInvocationException ex) {
				Console.WriteLine ("ManagedXamlLoader::LoadObject: CreateInstance ({0}) failed: {1}", name, ex.InnerException);
				return IntPtr.Zero;
			}
			DependencyObject dob = res as DependencyObject;

			if (dob == null) {
				Console.Error.WriteLine ("ManagedXamlLoader::LoadObject ({0}, {1}, {2}, {3}): unable to create object instance: '{4}', the object was of type '{5}'", asm_name, asm_path, ns, type_name, name, res.GetType ().FullName);
				return IntPtr.Zero;
			}

			NativeMethods.base_ref (dob.native);

			return dob.native;
		}
		
		private bool SetCustomAttribute (IntPtr target_ptr, string name, string value)
		{
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr); 
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (target == null) {
				//Console.Error.WriteLine ("ManagedXamlLoader::SetCustomAttribute ({0}, {1}, {2}): unable to create target object.", target_ptr, name, value);
				return false;
			}

			string error;
			IntPtr unmanaged_value;
			Helper.SetPropertyFromString (target, name, value, out error, out unmanaged_value);

			if (unmanaged_value != IntPtr.Zero) {
				object obj_value = DependencyObject.ValueToObject (unmanaged_value);

				error = null;
				Helper.SetPropertyFromValue (target, name, obj_value, out error);
			}

			if (error != null){
				//Console.Error.WriteLine ("ManagedXamlLoader::SetCustomAttribute ({0}, {1}, {2}) unable to set property: {3}.", target_ptr, name, value, error);
				return false;
			}

			return true;
		}

		private bool LoadCode (string source, string type)
		{
			Console.WriteLine ("ManagedXamlLoader.load_code: '" + source + "' '" + type + "'");

			if (source == null) {
				Console.WriteLine ("ManagedXamlLoader.load_code: ERROR: Source can't be null.");
				return false;
			}

			if (type == null) {
				Console.WriteLine ("ManagedXamlLoader.load_code: ERROR: Type can't be null.");
				return false;
			}

			//
			// First try the desktop case
			//
			Stream s = Moonlight.LoadResource (source);
			if (s != null) {
#if WITH_DLR
				if (dlr_host == null)
					dlr_host = new DLRHost ();
				dlr_host.LoadSource (s, type, mappings);
				SetGlobalsAndEvents ();
#else
				Console.WriteLine ("ManagedXamlLoader.load_code: Ignoring request to load code.");
#endif
				return true;
			}

			//
			// Then the browser case
			//
			string local = GetMapping (source);
			if (local != null) {
				s = new FileStream (local, FileMode.Open, FileAccess.Read);
#if WITH_DLR
				if (dlr_host == null)
				    dlr_host = new DLRHost ();
				try {
					dlr_host.LoadSource (s, type, mappings);
				} catch (MissingReferenceException ex) {
					RequestFile (ex.Reference);
					return false;
				} catch (Exception ex) {
					if (Events.IsPlugin ()) {
						Events.ReportException (ex);
						// This is not a fatal error
						return true;
					}
					else
						throw;
				}
				SetGlobalsAndEvents ();
#else
				Console.WriteLine ("ManagedXamlLoader.load_code: Ignoring request to load code.");
#endif
				return true;
			} else {
				RequestFile (source);

				return false;
			}
		}

		private void SetNameAttribute (IntPtr target_ptr, string name)
		{
#if WITH_DLR
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr); 
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (dlr_host != null) {
				dlr_host.SetVariable (name, target);
			} else {
				RememberName (target, name);
			}
#endif
		}

#if WITH_DLR
		private class RememberedEvent {
			public DependencyObject target;
			public string name;
			public string value;
		}

		private Dictionary<string, DependencyObject> named_objects;

		private Dictionary<RememberedEvent, RememberedEvent> events;

		//
		// When SetNameAttribute and hookup_event are called, scripts are not yet loaded.
		// So we store the info in hash tables and process them after a script has been
		// loaded
		private void RememberName (DependencyObject target, string name) {
			if (named_objects == null)
				named_objects = new Dictionary<string, DependencyObject> ();
			named_objects [name] = target;
		}

		private void RememberEvent (DependencyObject target, string name, string value) {
			if (events == null)
				events = new Dictionary<RememberedEvent, RememberedEvent> ();
			RememberedEvent ev = new RememberedEvent ();
			ev.target = target;
			ev.name = name;
			ev.value = value;
			events [ev] = ev;
		}

		private void SetGlobalsAndEvents () {
			if (named_objects != null) {
				foreach (KeyValuePair<string, DependencyObject> kvp in named_objects)
					dlr_host.SetVariable (kvp.Key, kvp.Value);
				named_objects = null;
			}
			if (events != null) {
				foreach (RememberedEvent ev in events.Keys) {
					dlr_host.HookupEvent (ev.target, ev.name, ev.value);
				}
			}
		}
#endif

		//
		// Load a dependency file synchronously using the plugin
		//
		private byte[] LoadDependency (string path)
		{
			IntPtr plugin_handle = System.Windows.Interop.PluginHost.Handle;
			if (plugin_handle == IntPtr.Zero)
				return null;

			// FIXME: Cache result
			int size = 0;
			IntPtr n = NativeMethods.plugin_instance_load_url (plugin_handle, path, ref size);
			byte[] arr = new byte [size];
			unsafe {
				using (Stream u = new SimpleUnmanagedMemoryStream ((byte *) n, (int) size)){
					u.Read (arr, 0, size);
				}
			}
			Helper.FreeHGlobal (n);

			return arr;;
		}

		///
		///
		/// Callbacks invoked by the xaml.cpp C++ parser
		///
		///

#region Callbacks from xaml.cpp

		private string cb_get_mapping (string key)
		{
			try {
				return GetMapping (key);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::GetMapping ({0}) failed: {1}.", key, ex.Message);
				return null;
			}
		}
		
		private void cb_insert_mapping (string key, string name)
		{
			try {
				InsertMapping (key, name);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::InsertMapping ({0}, {1}) failed: {2}.", key, name, ex.Message);
			}
		}
		
		//
		// Proxy so that we return IntPtr.Zero in case of any failures, instead of
		// genereting an exception and unwinding the stack.
		//
		private IntPtr cb_load_object (string asm_name, string asm_path, string ns, string type_name)
		{
			try {
				return LoadObject (asm_name, asm_path, ns, type_name);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::LoadObject ({0}, {1}, {2}, {3}) failed: {4} ({5}).", asm_name, asm_path, ns, type_name, ex.Message, ex.GetType ().FullName);
				return IntPtr.Zero;
			}
		}
		
		//
		// Proxy so that we return IntPtr.Zero in case of any failures, instead of
		// genreating an exception and unwinding the stack.
		//
		private bool cb_set_custom_attribute (IntPtr target_ptr, string name, string value)
		{
			try {
				return SetCustomAttribute (target_ptr, name, value);
			} catch (Exception ex) {
				Console.Error.WriteLine ("ManagedXamlLoader::SetCustomAttribute ({0}, {1}, {2}) threw an exception: {3}.", target_ptr, name, value, ex.Message);
				return false;
			}
		}
		
		private bool cb_hookup_event (IntPtr target_ptr, string name, string value)
		{
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr);
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (target == null) {
				//Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to create target object.", target_ptr, name, value);
				return false;
			}

			EventInfo src = target.GetType ().GetEvent (name);
			if (src == null) {
				//Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to find event name.", target_ptr, name, value);
				return false;
			}

#if WITH_DLR
			if (dlr_host != null) {
				try {
					dlr_host.HookupEvent (target, name, value);
				}
				catch (Exception ex) {
					Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to hookup event: {3}", target_ptr, name, value, ex);
					return false;
				}
			} else {
				RememberEvent (target, name, value);
			}
#endif

			try {
				Delegate d = Delegate.CreateDelegate (src.EventHandlerType, target, value);
				if (d == null) {
					//Console.WriteLine ("ManagedXamlLoader::HookupEvent ({0}, {1}, {2}): unable to create delegate (src={3} target={4}).", target_ptr, name, value, src.EventHandlerType, target);
					return false;
				}

				src.AddEventHandler (target, d);
				return true;
			}
			catch {
				return false;
			}
		}

		private bool cb_load_code (string source, string type)
		{
			try {
				return LoadCode (source, type);
			}
			catch (Exception ex) {
				Console.WriteLine ("ManagedXamlLoader::LoadCode ({0}, {1}): {2}", source, type, ex);
				return false;
			}
		}

		private void cb_set_name_attribute (IntPtr target_ptr, string name)
		{
			try {
				SetNameAttribute (target_ptr, name);
			}
			catch (Exception ex) {
				Console.WriteLine ("ManagedXamlLoader::SetNameAttribute () threw an exception: " + ex);
			}
		}

#endregion
	}

	//
	// This class is a helper routine used to load an assembly and
	// its dependencies;  If a dependnecy is missing, it requests that
	// it be downloaded, if the dependency can not be met, it errors out.
	//
	// Handles recursive and multiple requests
	//
	internal class DependencyLoader {
		Assembly main;
		ManagedXamlLoader loader;
		int missing;
		string dirname;
		string asm_path;
		
		//
		// The hashtable is indexed by assembly name, and can contain:
		//   * An Assembly (for resolved references).
		//   * An AssemblyName (for unresolved references).
		//
		Hashtable deps;

		public DependencyLoader (ManagedXamlLoader parent, string asm_path)
		{
			loader = parent;
			this.asm_path = asm_path;
			
			dirname = ""; 
			int p = asm_path.LastIndexOf ('/');
			if (p != -1)
				dirname = asm_path.Substring (0, p + 1);
		}
		
		//
		// Loads the entry point
		//
		AssemblyLoadResult LoadMain ()
		{
			string mapped = loader.GetMapping (asm_path);
			if (mapped == null){
				loader.RequestFile (asm_path);
				return AssemblyLoadResult.MissingAssembly;
			}
			
			main = Helper.LoadFile (mapped);
			if (main == null){
				Console.WriteLine ("DependencyLoader: LoadMain (\"{0}\") failed to load client library", asm_path);
				return AssemblyLoadResult.LoadFailure;
			}
			return AssemblyLoadResult.Success;
		}
		
		void UpdateDeps (Assembly a)
		{
			AssemblyName [] list = Helper.GetReferencedAssemblies (a);
			
			foreach (AssemblyName an in list){
				if (an.Name == "agclr" || an.Name == "mscorlib" ||
				    an.Name == "System.Xml.Core" || an.Name == "System" ||
				    an.Name == "Microsoft.Scripting" ||
				    an.Name == "System.SilverLight" ||
				    an.Name == "System.Core")
					continue;
				
				if (deps == null){
					deps = new Hashtable ();
					deps [a.GetName ().Name] = a;
				}
				if (deps.Contains (an.Name))
					continue;
				deps [an.Name] = an;
				missing++;
			}
		}

		Assembly LoadDependency (string key, string file)
		{
			try {
				Assembly a = Helper.LoadFile (file);

				// enter it into the loaded deps
				deps [key] = a;
				missing--;

				return a;
			} catch (Exception ex){
				Console.WriteLine ("DependencyLoader.LoadDependency, error loading file {0}: {1}", file, ex.Message);
				throw;
			}
		}

		//
		// Triggers the assembly loading
		//
		public AssemblyLoadResult Load (ref Assembly clientlib)
		{
			AssemblyLoadResult result;
			
			// Load the initial assembly
			if (main == null){
				result = LoadMain ();
				if (result != AssemblyLoadResult.Success)
					return result;
				
				UpdateDeps (main);
				
				if (missing == 0){
					clientlib = main;
					return AssemblyLoadResult.Success;
				}
			}
			
			while (missing > 0){
				foreach (string name in deps.Keys){
					object v = deps [name];

					// If its already loaded, ignore
					if (v is Assembly)
						continue;
					
					AssemblyName an = (AssemblyName) v;
					string request = dirname + an.Name + ".dll";
					string mapped = loader.GetMapping (request);
					
					// Try first to detect a downloaded dependency
					if (mapped == null){
						loader.RequestFile (request);
						return AssemblyLoadResult.MissingAssembly;
					}

					try {
						Assembly a = LoadDependency (name, mapped);
						UpdateDeps (a);
						break;
					} catch {
						return AssemblyLoadResult.LoadFailure;
					}
				}
			}

			clientlib = main;
			return AssemblyLoadResult.Success;
		}
	}
}
