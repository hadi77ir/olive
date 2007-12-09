
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class SplineColorKeyFrame : ColorKeyFrame
{

	public static readonly DependencyProperty KeySplineProperty =
		DependencyProperty.Register ("KeySpline", typeof (KeySpline), typeof (SplineColorKeyFrame));

	Color value;
	KeyTime keyTime;

	public SplineColorKeyFrame ()
	{
	}

	public SplineColorKeyFrame (Color value)
	{
		this.value = value;
		// XX keytime?
	}

	public SplineColorKeyFrame (Color value, KeyTime keyTime)
	{
		this.value = value;
		this.keyTime = keyTime;
	}

	public SplineColorKeyFrame (Color value, KeyTime keyTime, KeySpline keySpline)
	{
		this.value = value;
		this.keyTime = keyTime;
		KeySpline = keySpline;
	}

	public KeySpline KeySpline {
		get { return (KeySpline)GetValue (KeySplineProperty); }
		set { SetValue (KeySplineProperty, value); }
	}

	protected override Freezable CreateInstanceCore ()
	{
		throw new NotImplementedException ();
	}

	protected override Color InterpolateValueCore (Color baseValue, double keyFrameProgress)
	{
		double splineProgress = KeySpline.GetSplineProgress (keyFrameProgress);

		return Color.FromScRgb ((float)(baseValue.ScA + (value.ScA - baseValue.ScA) * splineProgress), (float)(baseValue.ScR + (value.ScR - baseValue.ScR) * splineProgress), (float)(baseValue.ScG + (value.ScG - baseValue.ScG) * splineProgress), (float)(baseValue.ScB + (value.ScB - baseValue.ScB) * splineProgress));
	}
}


}
