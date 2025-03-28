using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Models;

namespace gui_tesing_library.Controllers
{
    class ScreenController: IGTScreen
    {
        public Vector2i Size { get; }
        public ScreenShot GetScreenshot()
        {
            throw new NotImplementedException();
        }

        public ScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
        {
            throw new NotImplementedException();
        }

        public Color GetPixelColorAt(Vector2i postion)
        {
            throw new NotImplementedException();
        }
    }
}
