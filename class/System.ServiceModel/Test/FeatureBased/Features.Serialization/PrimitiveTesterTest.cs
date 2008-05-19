﻿

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using MonoTests.Features;
using MonoTests.Features.Contracts;
using NUnit.Framework;
using Proxy.MonoTests.Features.Client;

namespace MonoTests.Features.Serialization
{
	[TestFixture]
    public class PrimitiveTesterTest : TestFixtureBase<PrimitiveTesterContractClient, PrimitiveTester, MonoTests.Features.Contracts.IPrimitiveTesterContract>
	{
		[Test]
		public void TestDoNothing () 
		{
			Client.DoNothing ();
		}

		[Test]
		public void TestDouble () {
			Assert.IsTrue (Client.AddDouble (1, 1) == 2);
		}

		[Test]
		public void TestByte () {
			Assert.IsTrue (Client.AddByte (1, 1) == 2);
		}

		[Test]
		public void TestSByte () {
			Assert.IsTrue (Client.AddSByte (1, 1) == 2);
		}

		[Test]
		public void TestShort () {
			Assert.IsTrue (Client.AddShort (1, 1) == 2);
		}

		[Test]
		public void TestUShort () {
			Assert.IsTrue (Client.AddUShort (1, 1) == 2);
		}

		[Test]
		public void TestInt () {
			Assert.IsTrue (Client.AddInt (1, 1) == 2);
		}

		[Test]
		public void TestUInt () {
			Assert.IsTrue (Client.AddUInt (1, 1) == 2);
		}

		[Test]
		public void TestLong () {
			Assert.AreEqual (2, Client.AddLong (1, 1));
		}

		[Test]
		public void TestULong () {
			Assert.IsTrue (Client.AddULong (1, 1) == 2);
		}

		[Test]
		public void TestFloat () {
			Assert.IsTrue (Client.AddFloat (1, 1) == 2);
		}

		[Test]
		public void TestByRef () {
			double d;
			double res = ClientProxy.AddByRef (out d, 1, 1);
			Assert.IsTrue(d == res);
		}

		[Test]
		[Category ("NotWorking")]
		public void TestNullableInt() {
			int? x1 = Client.NullableInt(3);
			Assert.AreEqual(x1,4,"TestNullableInt(3)==4");
			int? x2 = Client.NullableInt (null);
			Assert.IsNull (x2, "TestNullableInt(null)==null");
		}

		[Test]
		[Category ("NotWorking")]
		public void TestNullableChar () {
			char? x1 = Client.NullableChar ('a');
			Assert.AreEqual (x1, 'b', "TestNullableInt('a')=='b'");
			char? x2 = Client.NullableChar (null);
			Assert.IsNull (x2, "TestNullableChar(null)==null");
		}

	}
}
