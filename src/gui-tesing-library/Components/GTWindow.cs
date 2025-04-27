using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;

namespace gui_tesing_library.Components
{
    internal class GTWindow : IGTWindow
    {
        private GTWindow_CS _windowCS;
        public Vector2i Size { get; }
        public Vector2i MaximizedWindowSize { get; }

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

        public IGTScreen PixelAtShouldBeColor(Vector2i position, Color colorColor)
        {
            throw new NotImplementedException();
        }

        public Vector2i Position { get; }
        public bool DoesExist { get; }
        public string Name { get; }
        public bool IsMinimized { get; }

        public IGTWindow MoveWindow(Vector2i offset)
        {
            throw new NotImplementedException();
        }

        public IGTWindow Minimize()
        {
            throw new NotImplementedException();
        }

        public IGTWindow Maximize()
        {
            throw new NotImplementedException();
        }

        public IGTProcess GetProcessOfWindow()
        {
            throw new NotImplementedException();
        }

        public IGTWindow Close()
        {
            throw new NotImplementedException();
        }

        public IGTWindow SetWindowSize(int x, int y)
        {
            throw new NotImplementedException();
        }

        public IGTWindow SetPostion(int x, int y)
        {
            throw new NotImplementedException();
        }

        public IGTWindow BringUpFront()
        {
            throw new NotImplementedException();
        }

        public IGTWindow SizeShouldBe(Vector2i vector2I)
        {
            throw new NotImplementedException();
        }

        public IGTWindow ShouldWindowExist(bool v)
        {
            throw new NotImplementedException();
        }

        public IGTWindow KillProcess()
        {
            throw new NotImplementedException();
        }

        public IGTWindow ShouldBeMinimized(bool state)
        {
            throw new NotImplementedException();
        }

        public string GetWindowName()
        {
            throw new NotImplementedException();
        }

        public Vector2i GetWindowContentPosition()
        {
            throw new NotImplementedException();
        }

        public Vector2i GetWindowContentSize()
        {
            throw new NotImplementedException();
        }

        public Color GetContentPixelColorAt(Vector2i postion)
        {
            throw new NotImplementedException();
        }

        public Color GetContentPixelColorAt(Vector2f realtivePostion)
        {
            throw new NotImplementedException();
        }

        public IGTWindow ContentPixelAtShouldBeColor(Vector2i position, Color color)
        {
            throw new NotImplementedException();
        }

        public IGTWindow CenterWindow()
        {
            throw new NotImplementedException();
        }

        public IGTWindow WindowNameShouldBe(string title)
        {
            throw new NotImplementedException();
        }

        public IGTWindow ContentPixelAtShouldBeColor(
            Vector2f sliderColorCheckPostion,
            Color colorshouldbe,
            int errorPass
        )
        {
            throw new NotImplementedException();
        }
    }
}
