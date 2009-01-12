
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class LinearColorKeyFrame : ColorKeyFrame
{
	Color value;
	KeyTime keyTime;

	public LinearColorKeyFrame ()
	{
	}

	public LinearColorKeyFrame (Color value)
	{
		this.value = value;
		// XXX keytime?
	}

	public LinearColorKeyFrame (Color value, KeyTime keyTime)
	{
		this.value = value;
		this.keyTime = keyTime;
	}

	protected override Freezable CreateInstanceCore ()
	{
		return new LinearColorKeyFrame ();
	}

	protected override Color InterpolateValueCore (Color baseValue, double keyFrameProgress)
	{
		// standard linear interpolation
		return Color.FromScRgb ((float)(baseValue.ScA + (value.ScA - baseValue.ScA) * keyFrameProgress), (float)(baseValue.ScR + (value.ScR - baseValue.ScR) * keyFrameProgress), (float)(baseValue.ScG + (value.ScG - baseValue.ScG) * keyFrameProgress), (float)(baseValue.ScB + (value.ScB - baseValue.ScB) * keyFrameProgress));
	}
}


}
