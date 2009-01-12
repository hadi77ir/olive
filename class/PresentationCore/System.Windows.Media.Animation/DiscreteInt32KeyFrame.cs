
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class DiscreteInt32KeyFrame : Int32KeyFrame
{
	int value;
	KeyTime keyTime;

	public DiscreteInt32KeyFrame ()
	{
	}

	public DiscreteInt32KeyFrame (int value)
	{
		this.value = value;
		// XXX keytime?
	}

	public DiscreteInt32KeyFrame (int value, KeyTime keyTime)
	{
		this.value = value;
		this.keyTime = keyTime;
	}

	protected override Freezable CreateInstanceCore ()
	{
		return new DiscreteInt32KeyFrame ();
	}

	protected override int InterpolateValueCore (int baseValue, double keyFrameProgress)
	{
		return keyFrameProgress == 1.0 ? value : baseValue;
	}
}


}
