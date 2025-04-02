using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Directives;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;

namespace gui_tesing_library.Controllers
{
    public class ScreenController : IGTScreen
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

        public Vector2i Size { get; }

        public Vector2i MaximizedWindowSize
        {
            get
            {
                return _SystemCalls.GetMaximizedWindowSize();
                ;
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
            return SystemCallsFactory
                .GetSystemCalls()
                .GetScreenShotFromHandle(
                    0,
                    new Vector2i(0, 0),
                    SystemController.Instance.GetScreenSize()
                );
        }

        public ScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
        {
            throw new NotImplementedException();
        }

        [Log]
        public Color GetPixelColorAt(Vector2i postion)
        {
            //return SystemCallsFactory.GetSystemCalls().GetPixelColorAt(postion, 0);
            return new Color(0, 0, 0);
        }

        [Log]
        public IGTScreen PixelAtShouldBeColor(Vector2i postion, Color color)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return GetPixelColorAt(postion).Equals(color);
                },
                $"Pixel color at {postion} was not {color} with in given time"
            );
            return this;
        }
    }
}
