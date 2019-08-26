using System.Threading.Tasks;
using ImageMagick;

namespace Ryana.ImageGeneration
{
	public static class BasicProfile
	{
		private const int Width = 640;
		private const int Height = 391;
		private static readonly byte[] Template = Init();

		private static readonly PixelReadSettings PixelReadSettings =
			new PixelReadSettings(Width, Height, StorageType.Char, PixelMapping.RGBA);

		public static async Task<byte[]> GenerateAsync(
			string avatarUrl, string username, string discriminator,
			string level, string reputation, string credits,
			string rank, string experience, float percentage,
			string themeColor)
		{
			using var avatar = new MagickImage(await ImageGeneration.Client.GetByteArrayAsync(avatarUrl));
			using var image = new MagickImage(Template, PixelReadSettings);
			avatar.Resize(142, 142);
			ImageGeneration.CircularCrop(avatar);
			image.Composite(avatar, 32, 32, CompositeOperator.Over, Channels.RGB);

			return image.ToByteArray(MagickFormat.Png);
		}

		private static byte[] Init()
		{
			using var image = new MagickImage(MagickColors.Transparent, Width, Height);

			return image.ToByteArray(MagickFormat.Rgba);
		}
	}
}