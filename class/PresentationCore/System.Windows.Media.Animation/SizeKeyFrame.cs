
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public abstract class SizeKeyFrame : Freezable, IKeyFrame
{
	public static readonly DependencyProperty KeyTimeProperty
				= DependencyProperty.Register ("KeyTime", typeof (KeyTime), typeof (SizeKeyFrame));

	public static readonly DependencyProperty ValueProperty
				= DependencyProperty.Register ("Value", typeof (Size), typeof (SizeKeyFrame));

	protected SizeKeyFrame ()
	{
	}

	protected SizeKeyFrame (Size value)
	{
	}

	protected SizeKeyFrame (Size value, KeyTime keyTime)
	{
	}

	public KeyTime KeyTime {
		get { return (KeyTime)GetValue (KeyTimeProperty); }
		set { SetValue (KeyTimeProperty, value); }
	}

	public Size Value {
		get { return (Size)GetValue (ValueProperty); }
		set { SetValue (ValueProperty, value); }
	}

	object IKeyFrame.Value {
		get { return Value; }
		set { Value = (Size)value; }
	}

	public Size InterpolateValue (Size baseValue, double keyFrameProgress)
	{
		throw new NotImplementedException ();
	}

	protected abstract Size InterpolateValueCore (Size baseValue, double keyFrameProgress);
}


}
