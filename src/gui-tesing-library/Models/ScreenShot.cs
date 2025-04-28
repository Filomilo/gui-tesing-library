using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;

namespace gui_tesing_library.Models
{
    public class ScreenShot : IScreenShot
    {
        public ScreenShot(ScreenShot_CS screenShot_CS) { }

        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

        public double CompareToImage(string filePathToComparingImage)
        {
            throw new NotImplementedException();
        }

        public Color GetPixelColorAt(Vector2i pos)
        {
            throw new NotImplementedException();
        }

        public void SaveAsBitmap(string file)
        {
            throw new NotImplementedException();
        }

        public ScreenShotCS SimmilarityBetweenImagesShouldBe(string ImagePath, double simmilarity)
        {
            throw new NotImplementedException();
        }
    }
}
