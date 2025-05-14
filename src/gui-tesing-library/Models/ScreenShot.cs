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
        private ScreenShot_CS screenShot;

        public ScreenShot(ScreenShot_CS screenShot_CS)
        {
            this.screenShot = screenShot_CS;
        }

        public int Width
        {
            get { return screenShot.GetWidth(); }
        }

        public int Height
        {
            get { return screenShot.GetHeight(); }
        }

        public double CompareToImage(string filePathToComparingImage)
        {
            return screenShot.CompareToImage(filePathToComparingImage);
        }

        public Color GetPixelColorAt(Vector2i pos)
        {
            return new Color(screenShot.GetPixelColorAt(pos.Native()));
        }

        public void SaveAsBitmap(string file)
        {
            this.screenShot.SaveAsBitmap(file);
        }

        public IScreenShot SimmilarityBetweenImagesShouldBe(string ImagePath, double simmilarity)
        {
            this.screenShot.SimmilarityBetweenImagesShouldBe(ImagePath, simmilarity);
            return this;
        }
    }
}
