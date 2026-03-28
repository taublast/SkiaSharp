using System;
using Xunit;

namespace SkiaSharp.Tests
{
	public class SKImageFilterTest : SKTest
	{
		[SkippableFact]
		public void MergeFilterAcceptsNullFilterArray()
		{
			var filter = SKImageFilter.CreateMerge(new SKImageFilter[] { null });
			Assert.NotNull(filter);
		}

		[SkippableFact]
		public void MergeFilterAcceptsNullParams()
		{
			var filter = SKImageFilter.CreateMerge((SKImageFilter)null, null);
			Assert.NotNull(filter);
		}

		[SkippableFact]
		[Trait(Traits.Category.Key, Traits.Category.Values.Smoke)]
		public void ShaderFilterAcceptsNullParams()
		{
			var filter = SKImageFilter.CreateShader(null);
			Assert.NotNull(filter);
		}

		[SkippableFact]
		public void OffsetFilterBoundsMapForward()
		{
			using var filter = SKImageFilter.CreateOffset(5, -3);
			var src = SKRectI.Create(10, 20, 30, 40);

			Assert.Equal(SKRectI.Create(15, 17, 30, 40), filter.FilterBounds(src, SKMatrix.Identity, SKImageFilterMapDirection.Forward));
		}

		[SkippableFact]
		public void OffsetFilterBoundsMapReverse()
		{
			using var filter = SKImageFilter.CreateOffset(5, -3);
			var src = SKRectI.Create(10, 20, 30, 40);
			var dst = filter.FilterBounds(src, SKMatrix.Identity, SKImageFilterMapDirection.Forward);

			Assert.Equal(src, filter.FilterBounds(dst, SKMatrix.Identity, SKImageFilterMapDirection.Reverse, src));
		}

		[SkippableFact]
		public void ForwardFilterBoundsRejectsInputRect()
		{
			using var filter = SKImageFilter.CreateOffset(5, -3);
			var src = SKRectI.Create(10, 20, 30, 40);

			Assert.Throws<ArgumentException>(() => filter.FilterBounds(src, SKMatrix.Identity, SKImageFilterMapDirection.Forward, src));
		}
	}
}
