// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from shared\dxgi.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System.Runtime.InteropServices;

namespace TerraFX.Interop
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public /* blittable */ unsafe struct DXGI_ADAPTER_DESC
    {
        #region Fields
        [ComAliasName("WCHAR[128]")]
        public fixed char Description[128];

        [ComAliasName("UINT")]
        public uint VendorId;

        [ComAliasName("UINT")]
        public uint DeviceId;

        [ComAliasName("UINT")]
        public uint SubSysId;

        [ComAliasName("UINT")]
        public uint Revision;

        [ComAliasName("SIZE_T")]
        public nuint DedicatedVideoMemory;

        [ComAliasName("SIZE_T")]
        public nuint DedicatedSystemMemory;

        [ComAliasName("SIZE_T")]
        public nuint SharedSystemMemory;

        public LUID AdapterLuid;
        #endregion
    }
}