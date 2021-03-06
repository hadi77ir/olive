
/* this file is generated by gen-collection-types.cs.  do not modify */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Media.Animation;

namespace System.Windows.Media {


	public class DrawingCollection : Animatable, ICollection<Drawing>, IList<Drawing>, ICollection, IList, IFormattable
	{
		List<Drawing> list;

		public struct Enumerator : IEnumerator<Drawing>, IEnumerator
		{
			public void Reset()
			{
				throw new NotImplementedException (); 
			}

			public bool MoveNext()
			{
				throw new NotImplementedException (); 
			}

			public Drawing Current {
				get { throw new NotImplementedException (); }
			}

			object IEnumerator.Current {
				get { return Current; }
			}

			void IDisposable.Dispose()
			{
			}
		}

		public DrawingCollection ()
		{
			list = new List<Drawing>();
		}

		public DrawingCollection (IEnumerable<Drawing> values)
		{
			list = new List<Drawing> (values);
		}

		public DrawingCollection (int length)
		{
			list = new List<Drawing> (length);
		}

		public new DrawingCollection Clone ()
		{
			throw new NotImplementedException ();
		}

		public new DrawingCollection CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		public bool Contains (Drawing value)
		{
			return list.Contains (value);
		}

		public bool Remove (Drawing value)
		{
			return list.Remove (value);
		}

		public int IndexOf (Drawing value)
		{
			return list.IndexOf (value);
		}

		public void Add (Drawing value)
		{
			list.Add (value);
		}

		public void Clear ()
		{
			list.Clear ();
		}

		public void CopyTo (Drawing[] array, int arrayIndex)
		{
			list.CopyTo (array, arrayIndex);
		}

		public void Insert (int index, Drawing value)
		{
			list.Insert (index, value);
		}

		public void RemoveAt (int index)
		{
			list.RemoveAt (index);
		}

		public int Count {
			get { return list.Count; }
		}

		public Drawing this[int index] {
			get { return list[index]; }
			set { list[index] = value; }
		}

		public static DrawingCollection Parse (string str)
		{
			throw new NotImplementedException ();
		}

		bool ICollection<Drawing>.IsReadOnly {
			get { return false; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator();
		}

		IEnumerator<Drawing> IEnumerable<Drawing>.GetEnumerator()
		{
			return GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator();
		}

		bool ICollection.IsSynchronized {
			get { return false; }
		}

		object ICollection.SyncRoot {
			get { return this; }
		}

		void ICollection.CopyTo(Array array, int offset)
		{
			CopyTo ((Drawing[]) array, offset);
		}

		bool IList.IsFixedSize {
			get { return false; }
		}

		bool IList.IsReadOnly {
			get { return false; }
		}

		object IList.this[int index] {
			get { return this[index]; }
			set { this[index] = (Drawing)value; }
		}

		int IList.Add (object value)
		{
			Add ((Drawing)value);
			return Count;
		}

		bool IList.Contains (object value)
		{
			return Contains ((Drawing)value);
		}

		int IList.IndexOf (object value)
		{
			return IndexOf ((Drawing)value);
		}

		void IList.Insert (int index, object value)
		{
			Insert (index, (Drawing)value);
		}

		void IList.Remove (object value)
		{
			Remove ((Drawing)value);
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}

		public string ToString (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		string IFormattable.ToString (string format, IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}


		protected override bool FreezeCore (bool isChecking)
		{{
			if (isChecking) {{
				return base.FreezeCore (isChecking);
			}}
			else {{
				return true;
			}}
		}}



		protected override Freezable CreateInstanceCore ()
		{
			return new DrawingCollection();
		}

		protected override void GetAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override void GetCurrentValueAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCurrentValueCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}
	}
}
