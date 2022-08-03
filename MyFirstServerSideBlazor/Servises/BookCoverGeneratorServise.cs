using MyFirstServerSideBlazor.Servises.Contracts;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace MyFirstServerSideBlazor.Servises
{
    public class BookCoverGeneratorServise : IBookCoverGeneratorServise
    {
        private readonly FontService _fontService;

        public BookCoverGeneratorServise(FontService fontService)
        {
            _fontService = fontService;
        }

        public Image CreateCover(string BookTitle)
        {
            var blankCover = Image.FromFile(@"wwwroot/images/Book-Cover-Empty.png");

            var cover = WriteTextOnImage(blankCover, BookTitle, 
                new Font(_fontService.Font.Families[0], 35), 
                new SolidBrush(Color.Black),
                new Point(10, 10));

            return cover;
        }

        private Image WriteTextOnImage(Image image, string title, Font font, Brush brush, Point position)
        {
            var newImage = image.Clone() as Image;

            using (var gfx = Graphics.FromImage(newImage))
            {
                gfx.DrawString(title, font, brush, position);

                return newImage;
            };
        }
    }
}
