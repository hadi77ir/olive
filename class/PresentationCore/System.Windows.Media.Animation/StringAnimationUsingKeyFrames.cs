
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


[ContentProperty ("KeyFrames")]
public class StringAnimationUsingKeyFrames : StringAnimationBase, IKeyFrameAnimation, IAddChild
{
	public StringAnimationUsingKeyFrames ()
	{
	}

	public StringKeyFrameCollection KeyFrames {
		get { throw new NotImplementedException (); }
		set { throw new NotImplementedException (); }
	}

	IList IKeyFrameAnimation.KeyFrames {
		get { return (IList)KeyFrames; }
		set { KeyFrames = (StringKeyFrameCollection)value; }
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void AddChild (object child)
	{
		throw new NotImplementedException ();
	}

	void IAddChild.AddChild (object child)
	{
		AddChild (child);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void AddText (string childText)
	{
		throw new NotImplementedException ();
	}

	void IAddChild.AddText (string childText)
	{
		AddText (childText);
	}

	public new StringAnimationUsingKeyFrames Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override void CloneCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	public new StringAnimationUsingKeyFrames CloneCurrentValue ()
	{
		throw new NotImplementedException ();
	}

	protected override void CloneCurrentValueCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	protected override Freezable CreateInstanceCore ()
	{
		return new StringAnimationUsingKeyFrames ();
	}

	protected override bool FreezeCore (bool isChecking)
	{
		throw new NotImplementedException ();
	}

	protected override void GetAsFrozenCore (Freezable source)
	{
		throw new NotImplementedException ();
	}

	protected override void GetCurrentValueAsFrozenCore (Freezable source)
	{
		throw new NotImplementedException ();
	}

	protected override sealed String GetCurrentValueCore (String defaultOriginValue, String defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}

	protected override sealed Duration GetNaturalDurationCore (Clock clock)
	{
		throw new NotImplementedException ();
	}

	protected override void OnChanged ()
	{
		throw new NotImplementedException ();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeKeyFrames()
	{
		throw new NotImplementedException ();
	}



}


}
