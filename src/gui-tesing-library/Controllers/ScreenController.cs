using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;

namespace gui_tesing_library.Controllers
{
    public class ScreenController: IGTScreen
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

        public Vector2i Size { get; }

        public Vector2i MaximizedWindowSize
        {
            get
            {
                return _SystemCalls.GetMaximizedWindowSize();;
            }
        }
        private static IGTScreen _gtScreen;

        public static IGTScreen Instance
        {
            get
            {
                if (_gtScreen == null)
                {
                    _gtScreen = new ScreenController();
                }

                return _gtScreen;
            }
        }

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
