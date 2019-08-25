using System.Threading.Tasks;
using ImageMagick;

namespace Ryana.ImageGeneration
{
	public static class PremiumProfile
	{
		private const int Width = 800;
		private const int Height = 548;
		private static readonly byte[] Template = InitAsync();
		private static readonly IDrawable TemplateCircleStrokeWidth = new DrawableStrokeWidth(10);

		private static readonly IDrawable TemplateCircleFillColor =
			new DrawableFillColor(MagickColors.Transparent);

		private static readonly IDrawable TemplateDrawableCircle =
			new DrawableCircle(119, 119, 175, 175);

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
			avatar.Resize(150, 150);
			ImageGeneration.CircularCrop(avatar);
			image.Composite(avatar, 45, 45, CompositeOperator.Over, Channels.RGB);

			var percentagePixels = 501 * percentage;
			var color = new MagickColor($"#{themeColor}");
			var drawables = new Drawables()
				// Set up the font metadata
				.FillColor(new MagickColor(51, 51, 51))
				.TextAlignment(TextAlignment.Left)

				// Draw the discriminator
				.FontPointSize(35)
				.Font("Roboto", FontStyleType.Normal, FontWeight.Light, FontStretch.Normal)
				.Text(273, 155, $"#{discriminator}")

				// Prepare to draw the username
				.FontPointSize(55);

			var metric = drawables.FontTypeMetrics(username);
			if (metric.TextWidth > 385.0) drawables.FontPointSize(385.0 * 55.0 / metric.TextWidth);

			drawables
				// Draw the username
				.Font("Roboto", FontStyleType.Normal, FontWeight.Medium, FontStretch.Normal)
				.Text(273, 107, username)

				// Draw the level
				.FontPointSize(60)
				.TextAlignment(TextAlignment.Center)
				.Text(724, 163, level)

				// Draw the reputation, credits, and rank
				.FontPointSize(32)
				.Text(344, 305, reputation)
				.Text(504, 305, credits)
				.Text(664, 305, rank)

				// Draw the experience
				.TextAlignment(TextAlignment.Right)
				.Text(748, 486, experience)

				// Draw the experience bar
				.FillColor(color)
				.Polygon(
					new PointD(241, 500),
					new PointD(241 + percentagePixels, 500),
					new PointD(241 + percentagePixels + 39, 539),
					new PointD(280, 539)
				)

				// Draw the results
				.Draw(image);

			image.Draw(
				new DrawableStrokeColor(color),
				TemplateCircleStrokeWidth,
				TemplateCircleFillColor,
				TemplateDrawableCircle
			);

			return image.ToByteArray(MagickFormat.Png);
		}

		private static byte[] InitAsync()
		{
			using var image = new MagickImage(MagickColors.Transparent, Width, Height);

			new Drawables()
				// Background
				.FillColor(new MagickColor(51, 51, 51))
				.Rectangle(0, 0, 780, 528)

				// Card
				.FillColor(new MagickColor(250, 250, 250))
				.Polygon(
					new PointD(278, 22),
					new PointD(800, 22),
					new PointD(800, 30),
					new PointD(283, 30),
					new PointD(269, 44),
					new PointD(800, 44),
					new PointD(800, 548),
					new PointD(278, 548),
					new PointD(194, 464),
					new PointD(194, 316),
					new PointD(239, 271),
					new PointD(239, 61)
				)

				// Level Arrow Top
				.FillColor(new MagickColor(217, 217, 217))
				.Polygon(
					new PointD(674, 107),
					new PointD(774, 107),
					new PointD(774, 82),
					new PointD(724, 58),
					new PointD(674, 82)
				)

				// Level Arrow Bottom
				.Polygon(
					new PointD(674, 175),
					new PointD(774, 175),
					new PointD(774, 224),
					new PointD(724, 200),
					new PointD(674, 224)
				)

				// Experience
				.Polygon(
					new PointD(241, 500),
					new PointD(748, 500),
					new PointD(787, 539),
					new PointD(280, 539)
				)

				// Draw the image
				.Draw(image);

			using var reputation = new MagickImage("assets/reputation.png");
			reputation.Resize(90, 90);
			image.Composite(reputation, 300, 316, CompositeOperator.Over, Channels.RGB);

			using var credits = new MagickImage("assets/credits.png", MagickFormat.Png);
			credits.Resize(90, 90);
			image.Composite(credits, 460, 316, CompositeOperator.Over, Channels.RGB);

			using var leaderboard = new MagickImage("assets/leaderboard.png");
			leaderboard.Resize(90, 90);
			image.Composite(leaderboard, 620, 316, CompositeOperator.Over, Channels.RGB);

			return image.ToByteArray(MagickFormat.Rgba);
		}
	}
}