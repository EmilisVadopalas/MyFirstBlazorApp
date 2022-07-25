using Microsoft.AspNetCore.Mvc;
using MyFirstServerSideBlazor.Servises.Contracts;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyFirstServerSideBlazor
{
    [Route("[controller]")]
    [ApiController]
    public class ImageAPI : ControllerBase
    {
        private readonly IBookCoverGeneratorServise _coverServise;

        public ImageAPI(IBookCoverGeneratorServise coverServise)
        {
            _coverServise = coverServise;
        }

        [Route("Cover/{title}")]
        [HttpGet]
        public IActionResult Get(string title)
        {
            var cover = _coverServise.CreateCover(title);

            using (var _memorystream = new MemoryStream())
            {
                cover.Save(_memorystream, ImageFormat.Jpeg);
                return File(_memorystream.ToArray(), "image/jpeg");
            }
        }
    }
}
