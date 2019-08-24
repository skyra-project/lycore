using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ryana.ImageGeneration;

namespace LyCore.Controllers
{
    [Route("[Controller]")]
    public class ImageController : Controller
    {
        [HttpGet("profile")]
        public async Task<ActionResult<byte[]>> TestProfile([FromQuery] string avatarUrl, [FromQuery] string name,
            [FromQuery] string discrim, [FromQuery] string level, [FromQuery] string rep, [FromQuery] string credits,
            [FromQuery] string rank, [FromQuery] string exp, [FromQuery] float percentage, [FromQuery] string profileColour)
        {
            return new FileContentResult(await ImageGeneration.GenerateProfileAsync(avatarUrl, name, 
                    discrim, level, rep, credits, rank, exp, percentage, profileColour),
                "image/png");
        }
    }
}