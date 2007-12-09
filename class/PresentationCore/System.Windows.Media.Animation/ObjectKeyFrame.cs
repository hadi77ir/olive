
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public abstract class ObjectKeyFrame : Freezable, IKeyFrame
{
	public static readonly DependencyProperty KeyTimeProperty
				= DependencyProperty.Register ("KeyTime", typeof (KeyTime), typeof (ObjectKeyFrame));

	public static readonly DependencyProperty ValueProperty
				= DependencyProperty.Register ("Value", typeof (object), typeof (ObjectKeyFrame));

	protected ObjectKeyFrame ()
	{
	}

	protected ObjectKeyFrame (object value)
	{
	}

	protected ObjectKeyFrame (object value, KeyTime keyTime)
	{
	}

	public KeyTime KeyTime {
		get { return (KeyTime)GetValue (KeyTimeProperty); }
		set { SetValue (KeyTimeProperty, value); }
	}

	public object Value {
		get { return (object)GetValue (ValueProperty); }
		set { SetValue (ValueProperty, value); }
	}

	object IKeyFrame.Value {
		get { return Value; }
		set { Value = (object)value; }
	}

	public object InterpolateValue (object baseValue, double keyFrameProgress)
	{
		throw new NotImplementedException ();
	}

	protected abstract object InterpolateValueCore (object baseValue, double keyFrameProgress);
}


}
