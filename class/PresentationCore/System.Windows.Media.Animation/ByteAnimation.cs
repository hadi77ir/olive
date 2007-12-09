
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class ByteAnimation : ByteAnimationBase
{
	public static readonly DependencyProperty ByProperty
				= DependencyProperty.Register ("By", typeof (byte), typeof (ByteKeyFrame));
	public static readonly DependencyProperty FromProperty
				= DependencyProperty.Register ("From", typeof (byte), typeof (ByteKeyFrame));
	public static readonly DependencyProperty ToProperty
				= DependencyProperty.Register ("To", typeof (byte), typeof (ByteKeyFrame));

	public ByteAnimation ()
	{
	}

	public ByteAnimation (byte toValue, Duration duration)
	{
	}

	public ByteAnimation (byte toValue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public ByteAnimation (byte fromValue, byte toValue, Duration duration)
	{
	}

	public ByteAnimation (byte fromValue, byte tovalue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public byte? By {
		get { return (byte?) GetValue (ByProperty); }
		set { SetValue (ByProperty, value); }
	}

	public byte? From {
		get { return (byte?) GetValue (FromProperty); }
		set { SetValue (FromProperty, value); }
	}

	public byte? To {
		get { return (byte?) GetValue (ToProperty); }
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

	public new ByteAnimation Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override Freezable CreateInstanceCore ()
	{
		throw new NotImplementedException ();
	}

	protected override byte GetCurrentValueCore (byte defaultOriginValue, byte defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}
}


}
