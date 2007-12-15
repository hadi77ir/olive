
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using NUnit.Framework;

namespace MonoTests.System.Windows.Media.Animation {


[TestFixture]
public class ByteKeyFrameTest
{
	[Test]
	public void Properties ()
	{
		Assert.AreEqual ("KeyTime", ByteKeyFrame.KeyTimeProperty.Name, "1");
		Assert.AreEqual (typeof (ByteKeyFrame), ByteKeyFrame.KeyTimeProperty.OwnerType, "2");
		Assert.AreEqual (typeof (KeyTime), ByteKeyFrame.KeyTimeProperty.PropertyType, "3");

		Assert.AreEqual ("Value", ByteKeyFrame.ValueProperty.Name, "4");
		Assert.AreEqual (typeof (ByteKeyFrame), ByteKeyFrame.ValueProperty.OwnerType, "5");
		Assert.AreEqual (typeof (byte), ByteKeyFrame.ValueProperty.PropertyType, "6");
	}
}


}