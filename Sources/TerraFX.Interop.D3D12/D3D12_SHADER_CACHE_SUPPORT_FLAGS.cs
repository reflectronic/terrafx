// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License MIT. See License.md in the repository root for more information.

// Ported from um\d3d12.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;

namespace TerraFX.Interop.D3D12
{
    [Flags]
    public enum D3D12_SHADER_CACHE_SUPPORT_FLAGS
    {
        NONE = 0,

        SINGLE_PSO = 1,

        LIBRARY = 2,

        AUTOMATIC_INPROC_CACHE = 4,

        AUTOMATIC_DISK_CACHE = 8
    }
}