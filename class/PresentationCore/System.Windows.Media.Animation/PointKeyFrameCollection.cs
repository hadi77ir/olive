
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class PointKeyFrameCollection : Freezable, IList, ICollection, IEnumerable
{
	public PointKeyFrameCollection ()
	{
	}

	public int Count {
		get { throw new NotImplementedException (); }
	}

	public static PointKeyFrameCollection Empty {
		get { throw new NotImplementedException (); }
	}

	public bool IsFixedSize {
		get { throw new NotImplementedException (); }
	}

	public bool IsReadOnly {
		get { throw new NotImplementedException (); }
	}

	public bool IsSynchronized {
		get { throw new NotImplementedException (); }
	}

	public object SyncRoot {
		get { throw new NotImplementedException (); }
	}

	public PointKeyFrame this[int index] {
		get { throw new NotImplementedException (); }
		set { throw new NotImplementedException (); }
	}

	object IList.this[int index] {
		get { return this[index]; }
		set { this[index] = (PointKeyFrame)value; }
	}

	public int Add (PointKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	int IList.Add (object value)
	{
		return Add ((PointKeyFrame) value);
	}

	public void Clear ()
	{
		throw new NotImplementedException ();
	}

	public new PointKeyFrameCollection Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override void CloneCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	protected override void CloneCurrentValueCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	public bool Contains (PointKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	bool IList.Contains (object value)
	{
		return Contains ((PointKeyFrame)value);
	}

	public void CopyTo (PointKeyFrame[] array, int index)
	{
		throw new NotImplementedException ();
	}

	void ICollection.CopyTo (Array array, int index)
	{
		CopyTo ((PointKeyFrame[])array, index);
	}

	protected override Freezable CreateInstanceCore ()
	{
		return new PointKeyFrameCollection ();
	}

	protected override bool FreezeCore (bool isChecking)
	{
		throw new NotImplementedException ();
	}

	protected override void GetAsFrozenCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	protected override void GetCurrentValueAsFrozenCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	public IEnumerator GetEnumerator()
	{
		throw new NotImplementedException ();
	}

	public int IndexOf (PointKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	int IList.IndexOf (object value)
	{
		return IndexOf ((PointKeyFrame) value);
	}

	public void Insert (int index, PointKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	void IList.Insert (int index, object value)
	{
		Insert (index, (PointKeyFrame)value);
	}

	public void Remove (PointKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	void IList.Remove (object value)
	{
		Remove ((PointKeyFrame) value);
	}

	public void RemoveAt (int index)
	{
		throw new NotImplementedException ();
	}
}


}
