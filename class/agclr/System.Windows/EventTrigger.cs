//
// EventTrigger.cs
//
// Author:
//   Alan McGovern (amcgovern@novell.com)
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
// LIABLE FOR ANY CLAIM, DAMAGES OR OTEVENTTRIGGERHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
namespace System.Windows 
{
	public sealed class EventTrigger : DependancyObject 
	{
		public static readonly DependancyProperty ActionsProperty = 
			   DependencyProperty.Lookup (Kind.EVENTTRIGGER, "ACTIONS", typeof (TriggerActionCollection));

		public static readonly DependancyProperty RoutedEventProperty = 
			   DependencyProperty.Lookup (Kind.EVENTTRIGGER, "ROUTEDEVENT", typeof (string));


		public EventTrigger(): base (Mono.NativeMethods.eventtrigger_new ())
		{
		}

		internal EventTrigger (IntPtr raw) : base (raw)
		{
		}


		public TriggerActionCollection Actions {
			get { return (TriggerActionCollection) GetValue(ActionsProperty); }
			set { SetValue(ActionsProperty, value);
		}

		public string RoutedEvent {
			get { return (string) GetValue(RoutedEventProperty); }
			set { SetValue(RoutedEventProperty, value);
		}


		protected internal override Kind()
		{
			return Kind.EVENTTRIGGER;
		}
	}
}