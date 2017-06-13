// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License MIT. See License.md in the repository root for more information.

// Ported from um\d3d12sdklayers.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;

namespace TerraFX.Interop.D3D12
{
    [Flags]
    public enum D3D12_GPU_BASED_VALIDATION_PIPELINE_STATE_CREATE_FLAGS
    {
        NONE = 0,

        FRONT_LOAD_CREATE_TRACKING_ONLY_SHADERS = 1,

        FRONT_LOAD_CREATE_UNGUARDED_VALIDATION_SHADERS = 2,

        FRONT_LOAD_CREATE_GUARDED_VALIDATION_SHADERS = 4,

        VALID_MASK = 7
    }
}