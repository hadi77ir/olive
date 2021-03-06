
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public abstract class ByteAnimationBase : AnimationTimeline
{
	protected ByteAnimationBase () { }

	public override sealed Type TargetPropertyType { get { return typeof (byte); } }

	public new ByteAnimationBase Clone ()
	{
		throw new NotImplementedException ();
	} 

	public override sealed object GetCurrentValue (object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
	{
		return GetCurrentValue ((byte)defaultOriginValue, (byte) defaultDestinationValue, animationClock);
	}

	protected abstract byte GetCurrentValueCore (byte defaultOriginValue, byte defaultDestinationValue, AnimationClock animationClock);


	public byte GetCurrentValue (byte defaultOriginValue, byte defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}


}


}
