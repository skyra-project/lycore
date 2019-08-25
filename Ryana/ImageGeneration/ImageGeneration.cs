using System.Net.Http;
using ImageMagick;

namespace Ryana.ImageGeneration
{
	public static class ImageGeneration
	{
		/// <summary>
		///     The HttpClient used for HTTP requests.
		/// </summary>
		internal static readonly HttpClient Client = new HttpClient();

		/// <summary>
		///     Performs a circular crop on an image.
		/// </summary>
		/// <param name="image">The image to crop.</param>
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