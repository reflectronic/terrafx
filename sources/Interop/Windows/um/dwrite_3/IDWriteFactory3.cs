// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\dwrite_3.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Security;
using static TerraFX.Interop.Windows;
using static TerraFX.Utilities.InteropUtilities;

namespace TerraFX.Interop
{
    /// <summary>The root factory interface for all DWrite objects.</summary>
    [Guid("9A1B41C3-D3BB-466A-87FC-FE67556A3B65")]
    public /* blittable */ unsafe struct IDWriteFactory3
    {
        #region Fields
        public readonly Vtbl* lpVtbl;
        #endregion

        #region IUnknown Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _QueryInterface(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _AddRef(
            [In] IDWriteFactory3* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _Release(
            [In] IDWriteFactory3* This
        );
        #endregion

        #region IDWriteFactory Delegates
        /// <summary>Gets a font collection representing the set of installed fonts.</summary>
        /// <param name="fontCollection">Receives a pointer to the system font collection object, or NULL in case of failure.</param>
        /// <param name="checkForUpdates">If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this parameter is FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example, an application might specify TRUE if it has itself just installed a font and wants to be sure the font collection contains that font.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetSystemFontCollection(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontCollection** fontCollection,
            [In, ComAliasName("BOOL")] int checkForUpdates = FALSE
        );

        /// <summary>Creates a font collection using a custom font collection loader.</summary>
        /// <param name="collectionLoader">Application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</param>
        /// <param name="collectionKey">Key used by the loader to identify a collection of font files.</param>
        /// <param name="collectionKeySize">Size in bytes of the collection key.</param>
        /// <param name="fontCollection">Receives a pointer to the system font collection object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateCustomFontCollection(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontCollectionLoader* collectionLoader,
            [In] void* collectionKey,
            [In, ComAliasName("UINT32")] uint collectionKeySize,
            [Out] IDWriteFontCollection** fontCollection
        );

        /// <summary>Registers a custom font collection loader with the factory object.</summary>
        /// <param name="fontCollectionLoader">Application-defined font collection loader.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _RegisterFontCollectionLoader(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontCollectionLoader* fontCollectionLoader
        );

        /// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
        /// <param name="fontCollectionLoader">Application-defined font collection loader.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _UnregisterFontCollectionLoader(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontCollectionLoader* fontCollectionLoader
        );

        /// <summary>CreateFontFileReference creates a font file reference object from a local font file.</summary>
        /// <param name="filePath">Absolute file path. Subsequent operations on the conpublic /* blittable */ structed object may fail if the user provided filePath doesn't correspond to a valid file on the disk.</param>
        /// <param name="lastWriteTime">Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the conpublic /* blittable */ structed object may fail if the user provided lastWriteTime doesn't match the file on the disk.</param>
        /// <param name="fontFile">Contains newly created font file reference object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontFileReference(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("WCHAR[]")] char* filePath,
            [In, Optional] FILETIME* lastWriteTime,
            [Out] IDWriteFontFile** fontFile
        );

        /// <summary>CreateCustomFontFileReference creates a reference to an application specific font file resource. This function enables an application or a document to use a font without having to install it on the system. The fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.</summary>
        /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</param>
        /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        /// <param name="fontFileLoader">Font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</param>
        /// <param name="fontFile">Contains the newly created font file object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        /// <remarks> This function is provided for cases when an application or a document needs to use a font without having to install it on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.</remarks>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateCustomFontFileReference(
            [In] IDWriteFactory3* This,
            [In] void* fontFileReferenceKey,
            [In, ComAliasName("UINT32")] uint fontFileReferenceKeySize,
            [In] IDWriteFontFileLoader* fontFileLoader,
            [Out] IDWriteFontFile** fontFile
        );

        /// <summary>Creates a font face object.</summary>
        /// <param name="fontFaceType">The file format of the font face.</param>
        /// <param name="numberOfFiles">The number of font files required to represent the font face.</param>
        /// <param name="fontFiles">Font files representing the font face. Since IDWriteFontFace maintains its own references to the input font file objects, it's OK to release them after this call.</param>
        /// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a single face, this value should be zero.</param>
        /// <param name="fontFaceSimulationFlags">Font face simulation flags for algorithmic emboldening and italicization.</param>
        /// <param name="fontFace">Contains the newly created font face object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontFace(
            [In] IDWriteFactory3* This,
            [In] DWRITE_FONT_FACE_TYPE fontFaceType,
            [In, ComAliasName("UINT32")] uint numberOfFiles,
            [In, ComAliasName("IDWriteFontFile*[]")] IDWriteFontFile** fontFiles,
            [In, ComAliasName("UINT32")] uint faceIndex,
            [In] DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags,
            [Out] IDWriteFontFace** fontFace
        );

        /// <summary>Creates a rendering parameters object with default settings for the primary monitor.</summary>
        /// <param name="renderingParams">Holds the newly created rendering parameters object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateRenderingParams(
            [In] IDWriteFactory3* This,
            [Out] IDWriteRenderingParams** renderingParams
        );

        /// <summary>Creates a rendering parameters object with default settings for the specified monitor.</summary>
        /// <param name="monitor">The monitor to read the default values from.</param>
        /// <param name="renderingParams">Holds the newly created rendering parameters object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateMonitorRenderingParams(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("HMONITOR")] IntPtr monitor,
            [Out] IDWriteRenderingParams** renderingParams
        );

        /// <summary>Creates a rendering parameters object with the specified properties.</summary>
        /// <param name="gamma">The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</param>
        /// <param name="enhancedContrast">The amount of contrast enhancement, zero or greater.</param>
        /// <param name="clearTypeLevel">The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</param>
        /// <param name="pixelGeometry">The geometry of a device pixel.</param>
        /// <param name="renderingMode">Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.</param>
        /// <param name="renderingParams">Holds the newly created rendering parameters object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateCustomRenderingParams(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [Out] IDWriteRenderingParams** renderingParams
        );

        /// <summary>Registers a font file loader with DirectWrite.</summary>
        /// <param name="fontFileLoader">Pointer to the implementation of the IDWriteFontFileLoader for a particular file resource type.</param>
        /// <returns>Standard HRESULT error code.</returns>
        /// <remarks> This function registers a font file loader with DirectWrite. Font file loader interface handles loading font file resources of a particular type from a key. The font file loader interface is recommended to be implemented by a singleton object. A given instance can only be registered once. Succeeding attempts will return an error that it has already been registered. IMPORTANT: font file loader implementations must not register themselves with DirectWrite inside their conpublic /* blittable */ structors and must not unregister themselves in their depublic /* blittable */ structors, because registration and unregistration operations increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders with DirectWrite should be performed outside of the font file loader implementation as a separate step.</remarks>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _RegisterFontFileLoader(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontFileLoader* fontFileLoader
        );

        /// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
        /// <param name="fontFileLoader">Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</param>
        /// <returns>This function will succeed if the user loader is requested to be removed. It will fail if the pointer to the file loader identifies a standard DirectWrite loader, or a loader that is never registered or has already been unregistered.</returns>
        /// <remarks> This function unregisters font file loader callbacks with the DirectWrite font system. The font file loader interface is recommended to be implemented by a singleton object. IMPORTANT: font file loader implementations must not register themselves with DirectWrite inside their conpublic /* blittable */ structors and must not unregister themselves in their depublic /* blittable */ structors, because registration and unregistration operations increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders with DirectWrite should be performed outside of the font file loader implementation as a separate step.</remarks>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _UnregisterFontFileLoader(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontFileLoader* fontFileLoader
        );

        /// <summary>Create a text format object used for text layout.</summary>
        /// <param name="fontFamilyName">Name of the font family</param>
        /// <param name="fontCollection">Font collection. NULL indicates the system font collection.</param>
        /// <param name="fontWeight">Font weight</param>
        /// <param name="fontStyle">Font style</param>
        /// <param name="fontStretch">Font stretch</param>
        /// <param name="fontSize">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
        /// <param name="localeName">Locale name</param>
        /// <param name="textFormat">Contains newly created text format object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateTextFormat(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("WCHAR[]")] char* fontFamilyName,
            [In, Optional] IDWriteFontCollection* fontCollection,
            [In] DWRITE_FONT_WEIGHT fontWeight,
            [In] DWRITE_FONT_STYLE fontStyle,
            [In] DWRITE_FONT_STRETCH fontStretch,
            [In, ComAliasName("FLOAT")] float fontSize,
            [In, ComAliasName("WCHAR[]")] char* localeName,
            [Out] IDWriteTextFormat** textFormat
        );

        /// <summary>Create a typography object used in conjunction with text format for text layout.</summary>
        /// <param name="typography">Contains newly created typography object, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateTypography(
            [In] IDWriteFactory3* This,
            [Out] IDWriteTypography** typography
        );

        /// <summary>Create an object used for interoperability with GDI.</summary>
        /// <param name="gdiInterop">Receives the GDI interop object if successful, or NULL in case of failure.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetGdiInterop(
            [In] IDWriteFactory3* This,
            [Out] IDWriteGdiInterop** gdiInterop
        );

        /// <summary>CreateTextLayout takes a string, format, and associated constraints and produces an object representing the fully analyzed and formatted result.</summary>
        /// <param name="string">The string to layout.</param>
        /// <param name="stringLength">The length of the string.</param>
        /// <param name="textFormat">The format to apply to the string.</param>
        /// <param name="maxWidth">Width of the layout box.</param>
        /// <param name="maxHeight">Height of the layout box.</param>
        /// <param name="textLayout">The resultant object.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateTextLayout(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("WCHAR[]")] char* @string,
            [In, ComAliasName("UINT32")] uint stringLength,
            [In] IDWriteTextFormat* textFormat,
            [In, ComAliasName("FLOAT")] float maxWidth,
            [In, ComAliasName("FLOAT")] float maxHeight,
            [Out] IDWriteTextLayout** textLayout
        );

        /// <summary>CreateGdiCompatibleTextLayout takes a string, format, and associated constraints and produces and object representing the result formatted for a particular display resolution and measuring mode. The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired, CreateTextLayout should be used instead.</summary>
        /// <param name="string">The string to layout.</param>
        /// <param name="stringLength">The length of the string.</param>
        /// <param name="textFormat">The format to apply to the string.</param>
        /// <param name="layoutWidth">Width of the layout box.</param>
        /// <param name="layoutHeight">Height of the layout box.</param>
        /// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if rendering onto a 96 DPI device then pixelsPerDip is 1. If rendering onto a 120 DPI device then pixelsPerDip is 120/96.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the font size and pixelsPerDip.</param>
        /// <param name="useGdiNatural"> When set to FALSE, inpublic /* blittable */ structs the text layout to use the same metrics as GDI aliased text. When set to TRUE, inpublic /* blittable */ structs the text layout to use the same metrics as text measured by GDI using a font created with CLEARTYPE_NATURAL_QUALITY.</param>
        /// <param name="textLayout">The resultant object.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateGdiCompatibleTextLayout(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("WCHAR[]")] char* @string,
            [In, ComAliasName("UINT32")] uint stringLength,
            [In] IDWriteTextFormat* textFormat,
            [In, ComAliasName("FLOAT")] float layoutWidth,
            [In, ComAliasName("FLOAT")] float layoutHeight,
            [In, ComAliasName("FLOAT")] float pixelsPerDip,
            [In, Optional] DWRITE_MATRIX* transform,
            [In, ComAliasName("BOOL")] int useGdiNatural,
            [Out] IDWriteTextLayout** textLayout
        );

        /// <summary>The application may call this function to create an inline object for trimming, using an ellipsis as the omission sign. The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate omission signs can be created by the application by implementing IDWriteInlineObject.</summary>
        /// <param name="textFormat">Text format used as a template for the omission sign.</param>
        /// <param name="trimmingSign">Created omission sign.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateEllipsisTrimmingSign(
            [In] IDWriteFactory3* This,
            [In] IDWriteTextFormat* textFormat,
            [Out] IDWriteInlineObject** trimmingSign
        );

        /// <summary>Return an interface to perform text analysis with.</summary>
        /// <param name="textAnalyzer">The resultant object.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateTextAnalyzer(
            [In] IDWriteFactory3* This,
            [Out] IDWriteTextAnalyzer** textAnalyzer
        );

        /// <summary>Creates a number substitution object using a locale name, substitution method, and whether to ignore user overrides (uses NLS defaults for the given culture instead).</summary>
        /// <param name="substitutionMethod">Method of number substitution to use.</param>
        /// <param name="localeName">Which locale to obtain the digits from.</param>
        /// <param name="ignoreUserOverride">Ignore the user's settings and use the locale defaults</param>
        /// <param name="numberSubstitution">Receives a pointer to the newly created object.</param>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateNumberSubstitution(
            [In] IDWriteFactory3* This,
            [In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod,
            [In, ComAliasName("WCHAR[]")] char* localeName,
            [In, ComAliasName("BOOL")] int ignoreUserOverride,
            [Out] IDWriteNumberSubstitution** numberSubstitution
        );

        /// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
        /// <param name="glyphRun">Structure specifying the properties of the glyph run.</param>
        /// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if rendering onto a 96 DPI bitmap then pixelsPerDip is 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 120/96.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the emSize and pixelsPerDip.</param>
        /// <param name="renderingMode">Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</param>
        /// <param name="measuringMode">Specifies the method to measure glyphs.</param>
        /// <param name="baselineOriginX">Horizontal position of the baseline origin, in DIPs.</param>
        /// <param name="baselineOriginY">Vertical position of the baseline origin, in DIPs.</param>
        /// <param name="glyphRunAnalysis">Receives a pointer to the newly created object.</param>
        /// <returns>Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateGlyphRunAnalysis(
            [In] IDWriteFactory3* This,
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, ComAliasName("FLOAT")] float pixelsPerDip,
            [In, Optional] DWRITE_MATRIX* transform,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [Out] IDWriteGlyphRunAnalysis** glyphRunAnalysis
        );
        #endregion

        #region IDWriteFactory1 Delegates
        /// <summary>Gets a font collection representing the set of end-user defined custom fonts.</summary>
        /// <param name="fontCollection">Receives a pointer to the EUDC font collection object, or NULL in case of failure.</param>
        /// <param name="checkForUpdates">If this parameter is nonzero, the function performs an immediate check for changes to the set of EUDC fonts. If this parameter is FALSE, the function will still detect changes, but there may be some latency. For example, an application might specify TRUE if it has itself just modified a font and wants to be sure the font collection contains that font.</param>
        /// <returns> Standard HRESULT error code. Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but GetFontFamilyCount will be zero.</returns>
        /// <remarks> Querying via IDWriteFontCollection::FindFamilyName for a specific family (like MS Gothic) will return the matching family-specific EUDC font if one exists. Querying for "" will return the global EUDC font. For example, if you were matching an EUDC character within a run of the base font PMingLiu, you would retrieve the corresponding EUDC font face using GetEudcFontCollection, then FindFamilyName with "PMingLiu", followed by GetFontFamily and CreateFontFace.
        /// Be aware that eudcedit.exe can create placeholder empty glyphs that have zero advance width and no glyph outline. Although they are present in the font (HasCharacter returns true), you are best to ignore these and continue on with font fallback in your layout if the metrics for the glyph are zero.</remarks>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetEudcFontCollection(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontCollection** fontCollection,
            [In, ComAliasName("BOOL")] int checkForUpdates = FALSE
    );

        /// <summary>Creates a rendering parameters object with the specified properties.</summary>
        /// <param name="gamma">The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</param>
        /// <param name="enhancedContrast">The amount of contrast enhancement, zero or greater.</param>
        /// <param name="enhancedContrastGrayscale">The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</param>
        /// <param name="clearTypeLevel">The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</param>
        /// <param name="pixelGeometry">The geometry of a device pixel.</param>
        /// <param name="renderingMode">Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.</param>
        /// <param name="renderingParams">Holds the newly created rendering parameters object, or NULL in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateCustomRenderingParams1(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float enhancedContrastGrayscale,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [Out] IDWriteRenderingParams1** renderingParams
        );
        #endregion

        #region IDWriteFactory2 Delegates
        /// <summary>Get the system-appropriate font fallback mapping list.</summary>
        /// <param name="fontFallback">The system fallback list.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetSystemFontFallback(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontFallback** fontFallback
        );

        /// <summary>Create a custom font fallback builder.</summary>
        /// <param name="fontFallbackBuilder">Empty font fallback builder.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontFallbackBuilder(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontFallbackBuilder** fontFallbackBuilder
        );

        /// <summary>Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the original "base" run.</summary>
        /// <param name="baselineOriginX">Horizontal origin of the base glyph run in pre-transform coordinates.</param>
        /// <param name="baselineOriginY">Vertical origin of the base glyph run in pre-transform coordinates.</param>
        /// <param name="glyphRun">Pointer to the original "base" glyph run.</param>
        /// <param name="glyphRunDescription">Optional glyph run description.</param>
        /// <param name="measuringMode">Measuring mode, needed to compute the origins of each glyph.</param>
        /// <param name="worldToDeviceTransform">Matrix converting from the client's coordinate space to device coordinates (pixels), i.e., the world transform multiplied by any DPI scaling.</param>
        /// <param name="colorPaletteIndex">Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by IDWriteFontFace2::GetColorPaletteCount.</param>
        /// <param name="colorLayers">If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the base run has no color glyphs, then the output pointer is NULL and the method returns DWRITE_E_NOCOLOR.</param>
        /// <returns> Returns DWRITE_E_NOCOLOR if the font has no color information, the base glyph run does not contain any color glyphs, or the specified color palette index is out of range. In this case, the client should render the base glyph run. Otherwise, returns a standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _TranslateColorGlyphRun(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, Optional] DWRITE_GLYPH_RUN_DESCRIPTION* glyphRunDescription,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In, Optional] DWRITE_MATRIX* worldToDeviceTransform,
            [In, ComAliasName("UINT32")] uint colorPaletteIndex,
            [Out] IDWriteColorGlyphRunEnumerator** colorLayers
        );

        /// <summary>Creates a rendering parameters object with the specified properties.</summary>
        /// <param name="gamma">The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</param>
        /// <param name="enhancedContrast">The amount of contrast enhancement, zero or greater.</param>
        /// <param name="clearTypeLevel">The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</param>
        /// <param name="pixelGeometry">The geometry of a device pixel.</param>
        /// <param name="renderingMode">Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.</param>
        /// <param name="gridFitMode">How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.</param>
        /// <param name="renderingParams">Holds the newly created rendering parameters object, or NULL in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateCustomRenderingParams2(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float grayscaleEnhancedContrast,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [Out] IDWriteRenderingParams2** renderingParams
        );

        /// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
        /// <param name="glyphRun">Structure specifying the properties of the glyph run.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the emSize and pixelsPerDip.</param>
        /// <param name="renderingMode">Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</param>
        /// <param name="measuringMode">Specifies the method to measure glyphs.</param>
        /// <param name="gridFitMode">How to grid-fit glyph outlines. This must be non-default.</param>
        /// <param name="baselineOriginX">Horizontal position of the baseline origin, in DIPs.</param>
        /// <param name="baselineOriginY">Vertical position of the baseline origin, in DIPs.</param>
        /// <param name="glyphRunAnalysis">Receives a pointer to the newly created object.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateGlyphRunAnalysis1(
            [In] IDWriteFactory3* This,
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, Optional] DWRITE_MATRIX* transform,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [In] DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [Out] IDWriteGlyphRunAnalysis** glyphRunAnalysis
        );
        #endregion

        #region Delegates
        /// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
        /// <param name="glyphRun">Structure specifying the properties of the glyph run.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the emSize.</param>
        /// <param name="renderingMode">Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</param>
        /// <param name="measuringMode">Specifies the method to measure glyphs.</param>
        /// <param name="gridFitMode">How to grid-fit glyph outlines. This must be non-default.</param>
        /// <param name="baselineOriginX">Horizontal position of the baseline origin, in DIPs.</param>
        /// <param name="baselineOriginY">Vertical position of the baseline origin, in DIPs.</param>
        /// <param name="glyphRunAnalysis">Receives a pointer to the newly created object.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateGlyphRunAnalysis2(
            [In] IDWriteFactory3* This,
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, Optional] DWRITE_MATRIX* transform,
            [In] DWRITE_RENDERING_MODE1 renderingMode,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [In] DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [Out] IDWriteGlyphRunAnalysis** glyphRunAnalysis
        );

        /// <summary>Creates a rendering parameters object with the specified properties.</summary>
        /// <param name="gamma">The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</param>
        /// <param name="enhancedContrast">The amount of contrast enhancement, zero or greater.</param>
        /// <param name="grayscaleEnhancedContrast">The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</param>
        /// <param name="clearTypeLevel">The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</param>
        /// <param name="pixelGeometry">The geometry of a device pixel.</param>
        /// <param name="renderingMode">Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.</param>
        /// <param name="gridFitMode">How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.</param>
        /// <param name="renderingParams">Holds the newly created rendering parameters object, or NULL in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateCustomRenderingParams3(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float grayscaleEnhancedContrast,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE1 renderingMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [Out] IDWriteRenderingParams3** renderingParams
        );

        /// <summary>Creates a reference to a font given a full path.</summary>
        /// <param name="filePath">Absolute file path. Subsequent operations on the conpublic /* blittable */ structed object may fail if the user provided filePath doesn't correspond to a valid file on the disk.</param>
        /// <param name="lastWriteTime">Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the conpublic /* blittable */ structed object may fail if the user provided lastWriteTime doesn't match the file on the disk.</param>
        /// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a single face, this value should be zero.</param>
        /// <param name="fontSimulations">Font face simulation flags for algorithmic emboldening and italicization.</param>
        /// <param name="fontFaceReference">Contains newly created font face reference object, or nullptr in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontFaceReference(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("WCHAR[]")] char* filePath,
            [In, Optional] FILETIME* lastWriteTime,
            [In, ComAliasName("UINT32")] uint faceIndex,
            [In] DWRITE_FONT_SIMULATIONS fontSimulations,
            [Out] IDWriteFontFaceReference** fontFaceReference
        );

        /// <summary>Creates a reference to a font given a file.</summary>
        /// <param name="fontFile">User provided font file representing the font face.</param>
        /// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a single face, this value should be zero.</param>
        /// <param name="fontSimulations">Font face simulation flags for algorithmic emboldening and italicization.</param>
        /// <param name="fontFaceReference">Contains newly created font face reference object, or nullptr in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontFaceReference1(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontFile* fontFile,
            [In, ComAliasName("UINT32")] uint faceIndex,
            [In] DWRITE_FONT_SIMULATIONS fontSimulations,
            [Out] IDWriteFontFaceReference** fontFaceReference
        );

        /// <summary>Retrieves the list of system fonts.</summary>
        /// <param name="fontSet">Holds the newly created font set object, or NULL in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetSystemFontSet(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontSet** fontSet
        );

        /// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
        /// <param name="fontSetBuilder">Holds the newly created font set builder object, or NULL in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontSetBuilder(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontSetBuilder** fontSetBuilder
        );

        /// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
        /// <param name="fontSet">A set of fonts to use to build the collection.</param>
        /// <param name="fontCollection">Holds the newly created font collection object, or NULL in case of failure.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateFontCollectionFromFontSet(
            [In] IDWriteFactory3* This,
            [In] IDWriteFontSet* fontSet,
            [Out] IDWriteFontCollection1** fontCollection
        );

        /// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
        /// <param name="includeDownloadableFonts">Include cloud fonts or only locally installed ones.</param>
        /// <param name="fontCollection">Holds the newly created font collection object, or NULL in case of failure.</param>
        /// <param name="checkForUpdates">If this parameter is nonzero, the function performs an immediate check for changes to the set of system fonts. If this parameter is FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example, an application might specify TRUE if it has itself just installed a font and wants to be sure the font collection contains that font.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetSystemFontCollection1(
            [In] IDWriteFactory3* This,
            [In, ComAliasName("BOOL")] int includeDownloadableFonts,
            [Out] IDWriteFontCollection1** fontCollection,
            [In, ComAliasName("BOOL")] int checkForUpdates = FALSE
        );

        /// <summary>Gets the font download queue associated with this factory object.</summary>
        /// <param name="fontDownloadQueue">Receives a pointer to the font download queue interface.</param>
        /// <returns> Standard HRESULT error code.</returns>
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetFontDownloadQueue(
            [In] IDWriteFactory3* This,
            [Out] IDWriteFontDownloadQueue** fontDownloadQueue
        );
        #endregion

        #region IUnknown Methods
        [return: ComAliasName("HRESULT")]
        public int QueryInterface(
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_QueryInterface>(lpVtbl->QueryInterface)(
                    This,
                    riid,
                    ppvObject
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint AddRef()
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_AddRef>(lpVtbl->AddRef)(
                    This
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint Release()
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_Release>(lpVtbl->Release)(
                    This
                );
            }
        }
        #endregion

        #region IDWriteFactory Methods
        [return: ComAliasName("HRESULT")]
        public int GetSystemFontCollection(
            [Out] IDWriteFontCollection** fontCollection,
            [In, ComAliasName("BOOL")] int checkForUpdates = FALSE
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetSystemFontCollection>(lpVtbl->GetSystemFontCollection)(
                    This,
                    fontCollection,
                    checkForUpdates
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateCustomFontCollection(
            [In] IDWriteFontCollectionLoader* collectionLoader,
            [In] void* collectionKey,
            [In, ComAliasName("UINT32")] uint collectionKeySize,
            [Out] IDWriteFontCollection** fontCollection
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateCustomFontCollection>(lpVtbl->CreateCustomFontCollection)(
                    This,
                    collectionLoader,
                    collectionKey,
                    collectionKeySize,
                    fontCollection
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int RegisterFontCollectionLoader(
            [In] IDWriteFontCollectionLoader* fontCollectionLoader
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_RegisterFontCollectionLoader>(lpVtbl->RegisterFontCollectionLoader)(
                    This,
                    fontCollectionLoader
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int UnregisterFontCollectionLoader(
            [In] IDWriteFontCollectionLoader* fontCollectionLoader
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_UnregisterFontCollectionLoader>(lpVtbl->UnregisterFontCollectionLoader)(
                    This,
                    fontCollectionLoader
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontFileReference(
            [In, ComAliasName("WCHAR[]")] char* filePath,
            [In, Optional] FILETIME* lastWriteTime,
            [Out] IDWriteFontFile** fontFile
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontFileReference>(lpVtbl->CreateFontFileReference)(
                    This,
                    filePath,
                    lastWriteTime,
                    fontFile
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateCustomFontFileReference(
            [In] void* fontFileReferenceKey,
            [In, ComAliasName("UINT32")] uint fontFileReferenceKeySize,
            [In] IDWriteFontFileLoader* fontFileLoader,
            [Out] IDWriteFontFile** fontFile
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateCustomFontFileReference>(lpVtbl->CreateCustomFontFileReference)(
                    This,
                    fontFileReferenceKey,
                    fontFileReferenceKeySize,
                    fontFileLoader,
                    fontFile
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontFace(
            [In] DWRITE_FONT_FACE_TYPE fontFaceType,
            [In, ComAliasName("UINT32")] uint numberOfFiles,
            [In, ComAliasName("IDWriteFontFile*[]")] IDWriteFontFile** fontFiles,
            [In, ComAliasName("UINT32")] uint faceIndex,
            [In] DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags,
            [Out] IDWriteFontFace** fontFace
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontFace>(lpVtbl->CreateFontFace)(
                    This,
                    fontFaceType,
                    numberOfFiles,
                    fontFiles,
                    faceIndex,
                    fontFaceSimulationFlags,
                    fontFace
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateRenderingParams(
            [Out] IDWriteRenderingParams** renderingParams
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateRenderingParams>(lpVtbl->CreateRenderingParams)(
                    This,
                    renderingParams
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateMonitorRenderingParams(
            [In, ComAliasName("HMONITOR")] IntPtr monitor,
            [Out] IDWriteRenderingParams** renderingParams
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateMonitorRenderingParams>(lpVtbl->CreateMonitorRenderingParams)(
                    This,
                    monitor,
                    renderingParams
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateCustomRenderingParams(
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [Out] IDWriteRenderingParams** renderingParams
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateCustomRenderingParams>(lpVtbl->CreateCustomRenderingParams)(
                    This,
                    gamma,
                    enhancedContrast,
                    clearTypeLevel,
                    pixelGeometry,
                    renderingMode,
                    renderingParams
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int RegisterFontFileLoader(
            [In] IDWriteFontFileLoader* fontFileLoader
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_RegisterFontFileLoader>(lpVtbl->RegisterFontFileLoader)(
                    This,
                    fontFileLoader
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int UnregisterFontFileLoader(
            [In] IDWriteFontFileLoader* fontFileLoader
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_UnregisterFontFileLoader>(lpVtbl->UnregisterFontFileLoader)(
                    This,
                    fontFileLoader
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateTextFormat(
            [In, ComAliasName("WCHAR[]")] char* fontFamilyName,
            [In, Optional] IDWriteFontCollection* fontCollection,
            [In] DWRITE_FONT_WEIGHT fontWeight,
            [In] DWRITE_FONT_STYLE fontStyle,
            [In] DWRITE_FONT_STRETCH fontStretch,
            [In, ComAliasName("FLOAT")] float fontSize,
            [In, ComAliasName("WCHAR[]")] char* localeName,
            [Out] IDWriteTextFormat** textFormat
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateTextFormat>(lpVtbl->CreateTextFormat)(
                    This,
                    fontFamilyName,
                    fontCollection,
                    fontWeight,
                    fontStyle,
                    fontStretch,
                    fontSize,
                    localeName,
                    textFormat
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateTypography(
            [Out] IDWriteTypography** typography
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateTypography>(lpVtbl->CreateTypography)(
                    This,
                    typography
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetGdiInterop(
            [Out] IDWriteGdiInterop** gdiInterop
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetGdiInterop>(lpVtbl->GetGdiInterop)(
                    This,
                    gdiInterop
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateTextLayout(
            [In, ComAliasName("WCHAR[]")] char* @string,
            [In, ComAliasName("UINT32")] uint stringLength,
            [In] IDWriteTextFormat* textFormat,
            [In, ComAliasName("FLOAT")] float maxWidth,
            [In, ComAliasName("FLOAT")] float maxHeight,
            [Out] IDWriteTextLayout** textLayout
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateTextLayout>(lpVtbl->CreateTextLayout)(
                    This,
                    @string,
                    stringLength,
                    textFormat,
                    maxWidth,
                    maxHeight,
                    textLayout
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateGdiCompatibleTextLayout(
            [In, ComAliasName("WCHAR[]")] char* @string,
            [In, ComAliasName("UINT32")] uint stringLength,
            [In] IDWriteTextFormat* textFormat,
            [In, ComAliasName("FLOAT")] float layoutWidth,
            [In, ComAliasName("FLOAT")] float layoutHeight,
            [In, ComAliasName("FLOAT")] float pixelsPerDip,
            [In, Optional] DWRITE_MATRIX* transform,
            [In, ComAliasName("BOOL")] int useGdiNatural,
            [Out] IDWriteTextLayout** textLayout
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateGdiCompatibleTextLayout>(lpVtbl->CreateGdiCompatibleTextLayout)(
                    This,
                    @string,
                    stringLength,
                    textFormat,
                    layoutWidth,
                    layoutHeight,
                    pixelsPerDip,
                    transform,
                    useGdiNatural,
                    textLayout
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateEllipsisTrimmingSign(
            [In] IDWriteTextFormat* textFormat,
            [Out] IDWriteInlineObject** trimmingSign
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateEllipsisTrimmingSign>(lpVtbl->CreateEllipsisTrimmingSign)(
                    This,
                    textFormat,
                    trimmingSign
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateTextAnalyzer(
            [Out] IDWriteTextAnalyzer** textAnalyzer
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateTextAnalyzer>(lpVtbl->CreateTextAnalyzer)(
                    This,
                    textAnalyzer
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateNumberSubstitution(
            [In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod,
            [In, ComAliasName("WCHAR[]")] char* localeName,
            [In, ComAliasName("BOOL")] int ignoreUserOverride,
            [Out] IDWriteNumberSubstitution** numberSubstitution
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateNumberSubstitution>(lpVtbl->CreateNumberSubstitution)(
                    This,
                    substitutionMethod,
                    localeName,
                    ignoreUserOverride,
                    numberSubstitution
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateGlyphRunAnalysis(
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, ComAliasName("FLOAT")] float pixelsPerDip,
            [In, Optional] DWRITE_MATRIX* transform,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [Out] IDWriteGlyphRunAnalysis** glyphRunAnalysis
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateGlyphRunAnalysis>(lpVtbl->CreateGlyphRunAnalysis)(
                    This,
                    glyphRun,
                    pixelsPerDip,
                    transform,
                    renderingMode,
                    measuringMode,
                    baselineOriginX,
                    baselineOriginY,
                    glyphRunAnalysis
                );
            }
        }
        #endregion

        #region IDWriteFactory1 Methods
        [return: ComAliasName("HRESULT")]
        public int GetEudcFontCollection(
            [Out] IDWriteFontCollection** fontCollection,
            [In, ComAliasName("BOOL")] int checkForUpdates = FALSE
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetEudcFontCollection>(lpVtbl->GetEudcFontCollection)(
                    This,
                    fontCollection,
                    checkForUpdates
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateCustomRenderingParams1(
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float enhancedContrastGrayscale,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [Out] IDWriteRenderingParams1** renderingParams
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateCustomRenderingParams1>(lpVtbl->CreateCustomRenderingParams1)(
                    This,
                    gamma,
                    enhancedContrast,
                    enhancedContrastGrayscale,
                    clearTypeLevel,
                    pixelGeometry,
                    renderingMode,
                    renderingParams
                );
            }
        }
        #endregion

        #region IDWriteFactory2 Methods
        [return: ComAliasName("HRESULT")]
        public int GetSystemFontFallback(
            [Out] IDWriteFontFallback** fontFallback
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetSystemFontFallback>(lpVtbl->GetSystemFontFallback)(
                    This,
                    fontFallback
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontFallbackBuilder(
            [Out] IDWriteFontFallbackBuilder** fontFallbackBuilder
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontFallbackBuilder>(lpVtbl->CreateFontFallbackBuilder)(
                    This,
                    fontFallbackBuilder
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int TranslateColorGlyphRun(
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, Optional] DWRITE_GLYPH_RUN_DESCRIPTION* glyphRunDescription,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In, Optional] DWRITE_MATRIX* worldToDeviceTransform,
            [In, ComAliasName("UINT32")] uint colorPaletteIndex,
            [Out] IDWriteColorGlyphRunEnumerator** colorLayers
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_TranslateColorGlyphRun>(lpVtbl->TranslateColorGlyphRun)(
                    This,
                    baselineOriginX,
                    baselineOriginY,
                    glyphRun,
                    glyphRunDescription,
                    measuringMode,
                    worldToDeviceTransform,
                    colorPaletteIndex,
                    colorLayers
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateCustomRenderingParams2(
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float grayscaleEnhancedContrast,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [Out] IDWriteRenderingParams2** renderingParams
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateCustomRenderingParams2>(lpVtbl->CreateCustomRenderingParams2)(
                    This,
                    gamma,
                    enhancedContrast,
                    grayscaleEnhancedContrast,
                    clearTypeLevel,
                    pixelGeometry,
                    renderingMode,
                    gridFitMode,
                    renderingParams
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateGlyphRunAnalysis1(
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, Optional] DWRITE_MATRIX* transform,
            [In] DWRITE_RENDERING_MODE renderingMode,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [In] DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [Out] IDWriteGlyphRunAnalysis** glyphRunAnalysis
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateGlyphRunAnalysis1>(lpVtbl->CreateGlyphRunAnalysis1)(
                    This,
                    glyphRun,
                    transform,
                    renderingMode,
                    measuringMode,
                    gridFitMode,
                    antialiasMode,
                    baselineOriginX,
                    baselineOriginY,
                    glyphRunAnalysis
                );
            }
        }
        #endregion

        #region Methods
        [return: ComAliasName("HRESULT")]
        public int CreateGlyphRunAnalysis2(
            [In] DWRITE_GLYPH_RUN* glyphRun,
            [In, Optional] DWRITE_MATRIX* transform,
            [In] DWRITE_RENDERING_MODE1 renderingMode,
            [In] DWRITE_MEASURING_MODE measuringMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [In] DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
            [In, ComAliasName("FLOAT")] float baselineOriginX,
            [In, ComAliasName("FLOAT")] float baselineOriginY,
            [Out] IDWriteGlyphRunAnalysis** glyphRunAnalysis
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateGlyphRunAnalysis2>(lpVtbl->CreateGlyphRunAnalysis2)(
                    This,
                    glyphRun,
                    transform,
                    renderingMode,
                    measuringMode,
                    gridFitMode,
                    antialiasMode,
                    baselineOriginX,
                    baselineOriginY,
                    glyphRunAnalysis
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateCustomRenderingParams3(
            [In, ComAliasName("FLOAT")] float gamma,
            [In, ComAliasName("FLOAT")] float enhancedContrast,
            [In, ComAliasName("FLOAT")] float grayscaleEnhancedContrast,
            [In, ComAliasName("FLOAT")] float clearTypeLevel,
            [In] DWRITE_PIXEL_GEOMETRY pixelGeometry,
            [In] DWRITE_RENDERING_MODE1 renderingMode,
            [In] DWRITE_GRID_FIT_MODE gridFitMode,
            [Out] IDWriteRenderingParams3** renderingParams
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateCustomRenderingParams3>(lpVtbl->CreateCustomRenderingParams3)(
                    This,
                    gamma,
                    enhancedContrast,
                    grayscaleEnhancedContrast,
                    clearTypeLevel,
                    pixelGeometry,
                    renderingMode,
                    gridFitMode,
                    renderingParams
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontFaceReference(
            [In, ComAliasName("WCHAR[]")] char* filePath,
            [In, Optional] FILETIME* lastWriteTime,
            [In, ComAliasName("UINT32")] uint faceIndex,
            [In] DWRITE_FONT_SIMULATIONS fontSimulations,
            [Out] IDWriteFontFaceReference** fontFaceReference
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontFaceReference>(lpVtbl->CreateFontFaceReference)(
                    This,
                    filePath,
                    lastWriteTime,
                    faceIndex,
                    fontSimulations,
                    fontFaceReference
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontFaceReference1(
            [In] IDWriteFontFile* fontFile,
            [In, ComAliasName("UINT32")] uint faceIndex,
            [In] DWRITE_FONT_SIMULATIONS fontSimulations,
            [Out] IDWriteFontFaceReference** fontFaceReference
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontFaceReference1>(lpVtbl->CreateFontFaceReference1)(
                    This,
                    fontFile,
                    faceIndex,
                    fontSimulations,
                    fontFaceReference
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetSystemFontSet(
            [Out] IDWriteFontSet** fontSet
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetSystemFontSet>(lpVtbl->GetSystemFontSet)(
                    This,
                    fontSet
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontSetBuilder(
            [Out] IDWriteFontSetBuilder** fontSetBuilder
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontSetBuilder>(lpVtbl->CreateFontSetBuilder)(
                    This,
                    fontSetBuilder
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateFontCollectionFromFontSet(
            [In] IDWriteFontSet* fontSet,
            [Out] IDWriteFontCollection1** fontCollection
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_CreateFontCollectionFromFontSet>(lpVtbl->CreateFontCollectionFromFontSet)(
                    This,
                    fontSet,
                    fontCollection
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetSystemFontCollection1(
            [In, ComAliasName("BOOL")] int includeDownloadableFonts,
            [Out] IDWriteFontCollection1** fontCollection,
            [In, ComAliasName("BOOL")] int checkForUpdates = FALSE
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetSystemFontCollection1>(lpVtbl->GetSystemFontCollection1)(
                    This,
                    includeDownloadableFonts,
                    fontCollection,
                    checkForUpdates
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetFontDownloadQueue(
            [Out] IDWriteFontDownloadQueue** fontDownloadQueue
        )
        {
            fixed (IDWriteFactory3* This = &this)
            {
                return MarshalFunction<_GetFontDownloadQueue>(lpVtbl->GetFontDownloadQueue)(
                    This,
                    fontDownloadQueue
                );
            }
        }
        #endregion

        #region Structs
        public /* blittable */ struct Vtbl
        {
            #region IUnknown Fields
            public IntPtr QueryInterface;

            public IntPtr AddRef;

            public IntPtr Release;
            #endregion

            #region IDWriteFactory Fields
            public IntPtr GetSystemFontCollection;

            public IntPtr CreateCustomFontCollection;

            public IntPtr RegisterFontCollectionLoader;

            public IntPtr UnregisterFontCollectionLoader;

            public IntPtr CreateFontFileReference;

            public IntPtr CreateCustomFontFileReference;

            public IntPtr CreateFontFace;

            public IntPtr CreateRenderingParams;

            public IntPtr CreateMonitorRenderingParams;

            public IntPtr CreateCustomRenderingParams;

            public IntPtr RegisterFontFileLoader;

            public IntPtr UnregisterFontFileLoader;

            public IntPtr CreateTextFormat;

            public IntPtr CreateTypography;

            public IntPtr GetGdiInterop;

            public IntPtr CreateTextLayout;

            public IntPtr CreateGdiCompatibleTextLayout;

            public IntPtr CreateEllipsisTrimmingSign;

            public IntPtr CreateTextAnalyzer;

            public IntPtr CreateNumberSubstitution;

            public IntPtr CreateGlyphRunAnalysis;
            #endregion

            #region IDWriteFactory1 Fields
            public IntPtr GetEudcFontCollection;

            public IntPtr CreateCustomRenderingParams1;
            #endregion

            #region IDWriteFactory2 Fields
            public IntPtr GetSystemFontFallback;

            public IntPtr CreateFontFallbackBuilder;

            public IntPtr TranslateColorGlyphRun;

            public IntPtr CreateCustomRenderingParams2;

            public IntPtr CreateGlyphRunAnalysis1;
            #endregion

            #region Fields
            public IntPtr CreateGlyphRunAnalysis2;

            public IntPtr CreateCustomRenderingParams3;

            public IntPtr CreateFontFaceReference;

            public IntPtr CreateFontFaceReference1;

            public IntPtr GetSystemFontSet;

            public IntPtr CreateFontSetBuilder;

            public IntPtr CreateFontCollectionFromFontSet;

            public IntPtr GetSystemFontCollection1;

            public IntPtr GetFontDownloadQueue;
            #endregion
        }
        #endregion
    }
}
