using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		Binding binding = new BasicHttpBinding ();
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		binding.OpenTimeout = TimeSpan.FromSeconds (20);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		host.Description.Behaviors.Find<ServiceBehaviorAttribute> ()
			.ConcurrencyMode = ConcurrencyMode.Multiple;
		host.Description.Behaviors.Add (new ServiceMetadataBehavior () { HttpGetUrl = new Uri ("http://localhost:8080/wsdl"), HttpGetEnabled = true });
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
		((IDisposable) host).Dispose ();
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);

	[OperationContract]
	uint Add (uint v1, uint v2);
}

class Foo : IFoo
{
	public string Echo (string msg) 
	{
Console.WriteLine (OperationContext.Current.IncomingMessageHeaders.Action);
Console.WriteLine (OperationContext.Current.Channel.GetType ());
		return msg + msg;
		//throw new NotImplementedException ();
	}

	public uint Add (uint v1, uint v2)
	{
Console.WriteLine ("ADD");
Console.WriteLine (OperationContext.Current.Channel.GetType ());
		return v1 + v2;
	}
}

