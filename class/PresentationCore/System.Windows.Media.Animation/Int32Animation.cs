
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class Int32Animation : Int32AnimationBase
{
	public static readonly DependencyProperty ByProperty
				= DependencyProperty.Register ("By", typeof (int), typeof (Int32KeyFrame));
	public static readonly DependencyProperty FromProperty
				= DependencyProperty.Register ("From", typeof (int), typeof (Int32KeyFrame));
	public static readonly DependencyProperty ToProperty
				= DependencyProperty.Register ("To", typeof (int), typeof (Int32KeyFrame));

	public Int32Animation ()
	{
	}

	public Int32Animation (int toValue, Duration duration)
	{
	}

	public Int32Animation (int toValue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public Int32Animation (int fromValue, int toValue, Duration duration)
	{
	}

	public Int32Animation (int fromValue, int tovalue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public int? By {
		get { return (int?) GetValue (ByProperty); }
		set { SetValue (ByProperty, value); }
	}

	public int? From {
		get { return (int?) GetValue (FromProperty); }
		set { SetValue (FromProperty, value); }
	}

	public int? To {
		get { return (int?) GetValue (ToProperty); }
		set { SetValue (ToProperty, value); }
	}

	public bool IsAdditive {
		get { return (bool) GetValue (AnimationTimeline.IsAdditiveProperty); }
		set { SetValue (AnimationTimeline.IsAdditiveProperty, value); }
	}

	public bool IsCumulative {
		get { return (bool) GetValue (AnimationTimeline.IsCumulativeProperty); }
		set { SetValue (AnimationTimeline.IsCumulativeProperty, value); }
	}

	public new Int32Animation Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override Freezable CreateInstanceCore ()
	{
		throw new NotImplementedException ();
	}

	protected override int GetCurrentValueCore (int defaultOriginValue, int defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}
}


}
