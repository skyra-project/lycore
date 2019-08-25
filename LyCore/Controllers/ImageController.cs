using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ryana.ImageGeneration;

namespace LyCore.Controllers
{
	[Route("[Controller]")]
	public class ImageController : Controller
	{
		[HttpGet("profile")]
		public async Task<ActionResult<byte[]>> TestProfile([FromQuery] string avatarUrl, [FromQuery] string username,
			[FromQuery] string discriminator, [FromQuery] string level, [FromQuery] string reputation,
			[FromQuery] string credits, [FromQuery] string rank, [FromQuery] string experience,
			[FromQuery] float percentage, [FromQuery] string themeColor)
		{
			return new FileContentResult(await ImageGeneration.GenerateProfileAsync(avatarUrl, username,
					discriminator, level, reputation, credits, rank, experience, percentage, themeColor),
				"image/png");
		}
	}
}