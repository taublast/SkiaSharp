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
		[return: MarshalAs (UnmanagedType.I1)]
		internal static partial bool sk_paint_can_compute_fast_bounds (IntPtr cpaint);

		[LibraryImport (SKIA)]
		internal static partial void sk_paint_compute_fast_bounds (IntPtr cpaint, SKRect* orig, SKRect* storage);
#else
		[DllImport (SKIA, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs (UnmanagedType.I1)]
		internal static extern bool sk_paint_can_compute_fast_bounds (IntPtr cpaint);

		[DllImport (SKIA, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void sk_paint_compute_fast_bounds (IntPtr cpaint, SKRect* orig, SKRect* storage);
#endif
#else
		private partial class Delegates
		{
			[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
			[return: MarshalAs (UnmanagedType.I1)]
			internal delegate bool sk_paint_can_compute_fast_bounds (IntPtr cpaint);

			[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
			internal delegate void sk_paint_compute_fast_bounds (IntPtr cpaint, SKRect* orig, SKRect* storage);
		}

		private static Delegates.sk_paint_can_compute_fast_bounds sk_paint_can_compute_fast_bounds_delegate;
		internal static bool sk_paint_can_compute_fast_bounds (IntPtr cpaint) =>
			(sk_paint_can_compute_fast_bounds_delegate ??= GetSymbol<Delegates.sk_paint_can_compute_fast_bounds> ("sk_paint_can_compute_fast_bounds")).Invoke (cpaint);

		private static Delegates.sk_paint_compute_fast_bounds sk_paint_compute_fast_bounds_delegate;
		internal static void sk_paint_compute_fast_bounds (IntPtr cpaint, SKRect* orig, SKRect* storage) =>
			(sk_paint_compute_fast_bounds_delegate ??= GetSymbol<Delegates.sk_paint_compute_fast_bounds> ("sk_paint_compute_fast_bounds")).Invoke (cpaint, orig, storage);
#endif
	}
}
