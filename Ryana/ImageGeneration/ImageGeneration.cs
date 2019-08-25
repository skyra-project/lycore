using System.Net.Http;
using ImageMagick;

namespace Ryana.ImageGeneration
{
	public static class ImageGeneration
	{
		internal static readonly HttpClient Client = new HttpClient();

		internal static void CircularCrop(IMagickImage image)
		{
			using var copy = image.Clone();
			copy.Distort(DistortMethod.DePolar, 0);
			copy.VirtualPixelMethod = VirtualPixelMethod.HorizontalTile;
			copy.BackgroundColor = MagickColors.None;
			copy.Distort(DistortMethod.Polar, 0);

			image.Composite(copy, CompositeOperator.CopyAlpha);
		}
	}
}