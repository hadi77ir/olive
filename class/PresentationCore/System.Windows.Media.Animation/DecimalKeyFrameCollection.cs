
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class DecimalKeyFrameCollection : Freezable, IList, ICollection, IEnumerable
{
	public DecimalKeyFrameCollection ()
	{
	}

	public int Count {
		get { throw new NotImplementedException (); }
	}

	public static DecimalKeyFrameCollection Empty {
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

	public DecimalKeyFrame this[int index] {
		get { throw new NotImplementedException (); }
		set { throw new NotImplementedException (); }
	}

	object IList.this[int index] {
		get { return this[index]; }
		set { this[index] = (DecimalKeyFrame)value; }
	}

	public int Add (DecimalKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	int IList.Add (object value)
	{
		return Add ((DecimalKeyFrame) value);
	}

	public void Clear ()
	{
		throw new NotImplementedException ();
	}

	public new DecimalKeyFrameCollection Clone ()
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

	public bool Contains (DecimalKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	bool IList.Contains (object value)
	{
		return Contains ((DecimalKeyFrame)value);
	}

	public void CopyTo (DecimalKeyFrame[] array, int index)
	{
		throw new NotImplementedException ();
	}

	void ICollection.CopyTo (Array array, int index)
	{
		CopyTo ((DecimalKeyFrame[])array, index);
	}

	protected override Freezable CreateInstanceCore ()
	{
		return new DecimalKeyFrameCollection ();
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

	public int IndexOf (DecimalKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	int IList.IndexOf (object value)
	{
		return IndexOf ((DecimalKeyFrame) value);
	}

	public void Insert (int index, DecimalKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	void IList.Insert (int index, object value)
	{
		Insert (index, (DecimalKeyFrame)value);
	}

	public void Remove (DecimalKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	void IList.Remove (object value)
	{
		Remove ((DecimalKeyFrame) value);
	}

	public void RemoveAt (int index)
	{
		throw new NotImplementedException ();
	}
}


}
