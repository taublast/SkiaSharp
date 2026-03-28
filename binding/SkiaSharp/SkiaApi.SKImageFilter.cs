#nullable disable

using System;
using System.Runtime.InteropServices;

namespace SkiaSharp
{
	internal unsafe partial class SkiaApi
	{
#if !USE_DELEGATES
#if USE_LIBRARY_IMPORT
		[LibraryImport (SKIA)]
		internal static partial void sk_imagefilter_filter_bounds (IntPtr cfilter, SKRectI* src, SKMatrix* ctm, SKImageFilterMapDirection direction, SKRectI* inputRect, SKRectI* output);
#else
		[DllImport (SKIA, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void sk_imagefilter_filter_bounds (IntPtr cfilter, SKRectI* src, SKMatrix* ctm, SKImageFilterMapDirection direction, SKRectI* inputRect, SKRectI* output);
#endif
#else
		private partial class Delegates
		{
			[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
			internal delegate void sk_imagefilter_filter_bounds (IntPtr cfilter, SKRectI* src, SKMatrix* ctm, SKImageFilterMapDirection direction, SKRectI* inputRect, SKRectI* output);
		}

		private static Delegates.sk_imagefilter_filter_bounds sk_imagefilter_filter_bounds_delegate;
		internal static void sk_imagefilter_filter_bounds (IntPtr cfilter, SKRectI* src, SKMatrix* ctm, SKImageFilterMapDirection direction, SKRectI* inputRect, SKRectI* output) =>
			(sk_imagefilter_filter_bounds_delegate ??= GetSymbol<Delegates.sk_imagefilter_filter_bounds> ("sk_imagefilter_filter_bounds")).Invoke (cfilter, src, ctm, direction, inputRect, output);
#endif
	}
}
