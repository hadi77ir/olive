
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class SplineSizeKeyFrame : SizeKeyFrame
{

	public static readonly DependencyProperty KeySplineProperty =
		DependencyProperty.Register ("KeySpline", typeof (KeySpline), typeof (SplineSizeKeyFrame));

	Size value;
	KeyTime keyTime;

	public SplineSizeKeyFrame ()
	{
	}

	public SplineSizeKeyFrame (Size value)
	{
		this.value = value;
		// XX keytime?
	}

	public SplineSizeKeyFrame (Size value, KeyTime keyTime)
	{
		this.value = value;
		this.keyTime = keyTime;
	}

	public SplineSizeKeyFrame (Size value, KeyTime keyTime, KeySpline keySpline)
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
		return new SplineSizeKeyFrame ();
	}

	protected override Size InterpolateValueCore (Size baseValue, double keyFrameProgress)
	{
		double splineProgress = KeySpline.GetSplineProgress (keyFrameProgress);

		return new Size (baseValue.Width + (value.Width - baseValue.Width) * splineProgress, baseValue.Height + (value.Height - baseValue.Height) * splineProgress);
	}
}


}
