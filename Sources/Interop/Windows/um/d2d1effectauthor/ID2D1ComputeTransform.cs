// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\d2d1effectauthor.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System.Runtime.InteropServices;
using System.Security;

namespace TerraFX.Interop
{
    /// <summary>The interface implemented by a transform author to provide a Compute Shader based effect.</summary>
    [Guid("0D85573C-01E3-4F7D-BFD9-0D60608BF3C3")]
    unsafe public /* blittable */ struct ID2D1ComputeTransform
    {
        #region Fields
        public readonly void* /* Vtbl* */ lpVtbl;
        #endregion

        #region Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate HRESULT SetComputeInfo(
            [In] ID2D1ComputeTransform* This,
            [In] ID2D1ComputeInfo* computeInfo
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate HRESULT CalculateThreadgroups(
            [In] ID2D1ComputeTransform* This,
            [In] /* readonly */ D2D1_RECT_L* outputRect,
            [Out] UINT32* dimensionX,
            [Out] UINT32* dimensionY,
            [Out] UINT32* dimensionZ
        );
        #endregion

        #region Structs
        public /* blittable */ struct Vtbl
        {
            #region Fields
            public ID2D1Transform.Vtbl BaseVtbl;

            public SetComputeInfo SetComputeInfo;

            public CalculateThreadgroups CalculateThreadgroups;
            #endregion
        }
        #endregion
    }
}