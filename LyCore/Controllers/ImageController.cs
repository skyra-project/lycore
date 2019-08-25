using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ryana.ImageGeneration;

namespace LyCore.Controllers
{
	[Route("[Controller]")]
	public class ImageController : Controller
	{
		/// <summary>
		///     Generates a premium avatar profile.
		/// </summary>
		/// <param name="avatarUrl">The avatar URL.</param>
		/// <param name="username">The username value.</param>
		/// <param name="discriminator">The discriminator value.</param>
		/// <param name="level">The level value.</param>
		/// <param name="reputation">The reputation value.</param>
		/// <param name="credits">The credits value.</param>
		/// <param name="rank">The rank value.</param>
		/// <param name="experience">The experience value.</param>
		/// <param name="percentage">The percentage value, must be a float.</param>
		/// <param name="themeColor">The hexadecimal color string.</param>
		/// <returns>The action result from this profile.</returns>
		/// <example>
		///     curl 'http://localhost:8990/image/profile'                                                                \
		///     -d avatarUrl=https://cdn.discordapp.com/avatars/242043489611808769/a_adcd82c10a4d7241ca876b7920e4d357.png \
		///     -d username=kyra                                                                                          \
		///     -d discriminator=0001                                                                                     \
		///     -d level=188                                                                                              \
		///     -d reputation=165                                                                                         \
		///     -d credits=174628                                                                                         \
		///     -d rank=2                                                                                                 \
		///     -d experience=890388                                                                                      \
		///     -d percentage=0.85                                                                                        \
		///     -d themeColor=00cdff
		/// </example>
		[HttpGet("profile")]
		public async Task<ActionResult<byte[]>> PremiumProfileController([FromQuery] string avatarUrl,
			[FromQuery] string username, [FromQuery] string discriminator, [FromQuery] string level,
			[FromQuery] string reputation, [FromQuery] string credits, [FromQuery] string rank,
			[FromQuery] string experience, [FromQuery] float percentage, [FromQuery] string themeColor)
		{
			return new FileContentResult(await PremiumProfile.GenerateAsync(avatarUrl, username,
					discriminator, level, reputation, credits, rank, experience, percentage, themeColor),
				"image/png");
		}
	}
}