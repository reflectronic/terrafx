// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace TerraFX.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="D2D1_LAYER_PARAMETERS" /> struct.</summary>
    public static class D2D1_LAYER_PARAMETERSTests
    {
        /// <summary>Validates that the layout of the <see cref="D2D1_LAYER_PARAMETERS" /> struct is <see cref="LayoutKind.Sequential" />.</summary>
        [Test]
        public static void IsLayoutSequentialTest()
        {
            Assert.That(typeof(D2D1_LAYER_PARAMETERS).IsLayoutSequential, Is.True);
        }

        /// <summary>Validates that the size of the <see cref="D2D1_LAYER_PARAMETERS" /> struct is correct.</summary>
        [Test]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.That(Marshal.SizeOf<D2D1_LAYER_PARAMETERS>(), Is.EqualTo(72));
            }
            else
            {
                Assert.That(Marshal.SizeOf<D2D1_LAYER_PARAMETERS>(), Is.EqualTo(60));
            }
        }
    }
}