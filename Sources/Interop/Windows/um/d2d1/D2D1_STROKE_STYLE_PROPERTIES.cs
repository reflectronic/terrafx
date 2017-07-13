// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\d2d1.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop
{
    /// <summary>Properties, aside from the width, that allow geometric penning to be specified.</summary>
    public /* blittable */ struct D2D1_STROKE_STYLE_PROPERTIES
    {
        #region Fields
        public D2D1_CAP_STYLE startCap;

        public D2D1_CAP_STYLE endCap;

        public D2D1_CAP_STYLE dashCap;

        public D2D1_LINE_JOIN lineJoin;

        public FLOAT miterLimit;

        public D2D1_DASH_STYLE dashStyle;

        public FLOAT dashOffset;
        #endregion
    }
}