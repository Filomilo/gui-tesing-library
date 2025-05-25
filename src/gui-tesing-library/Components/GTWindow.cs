using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;

namespace gui_tesing_library.Components
{
    internal class GTWindow : IGTWindow
    {
        private GTWindow_CS _windowCS;

        public GTWindow(GTWindow_CS windowCS)
        {
            _windowCS = windowCS;
        }

        public Vector2i Size
        {
            get { return new Vector2i(_windowCS.GetWindowSize()); }
        }



        public IScreenShot GetScreenshot()
        {
            return new ScreenShot(_windowCS.GetScreenshot());
        }

        public IScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
        {
            return new ScreenShot(_windowCS.GetScreenshotRect(position.Native(), size.Native()));
        }

        public Color GetPixelColorAt(Vector2i postion)
        {
            return new Color(_windowCS.GetPixelColorAt(postion.Native()));
        }

        public IGTScreen PixelAtShouldBeColor(Vector2i position, Color colorColor)
        {
            _windowCS.PixelAtShouldBeColor(position.Native(), colorColor.Native());
            return this;
        }

        public Vector2i Position
        {
            get { return new Vector2i(_windowCS.GetPosition()); }
        }

        public bool DoesExist
        {
            get { return _windowCS.DoesExist(); }
        }

        public string Name
        {
            get { return _windowCS.GetWindowName(); }
        }

        public bool IsMinimized
        {
            get { return _windowCS.IsMinimized(); }
        }

        public IGTWindow MoveWindow(Vector2i offset)
        {
            _windowCS.MoveWindow(offset.Native());
            return this;
        }

        public IGTWindow Minimize()
        {
            _windowCS.Minimize();
            return this;
        }

        public IGTWindow Maximize()
        {
            _windowCS.Maximize();
            return this;
        }

        public IGTProcess GetProcessOfWindow()
        {
            return new GTProcess(_windowCS.GetProcessOfWindow());
        }

        public IGTWindow Close()
        {
            _windowCS.Close();
            return this;
        }

        public IGTWindow SetWindowSize(int x, int y)
        {
            _windowCS.SetWindowSize(x, y);
            return this;
        }

        public IGTWindow SetPostion(int x, int y)
        {
            _windowCS.SetPosition(x, y);
            return this;
        }

        public IGTWindow BringUpFront()
        {
            _windowCS.BringUpFront();
            return this;
        }

        public IGTWindow SizeShouldBe(Vector2i vector2I)
        {
            _windowCS.SizeShouldBe(vector2I.Native());
            return this;
        }

        public IGTWindow ShouldWindowExist(bool v)
        {
            _windowCS.ShouldWindowExist(v);
            return this;
        }

        public IGTWindow KillProcess()
        {
            _windowCS.KillProcess();
            return this;
        }

        public IGTWindow ShouldBeMinimized(bool state)
        {
            _windowCS.ShouldBeMinimized(state);
            return this;
        }

        public string GetWindowName()
        {
            return _windowCS.GetWindowName();
        }

        public Vector2i GetWindowContentPosition()
        {
            return new Vector2i(_windowCS.GetWindowContentPosition());
        }

        public Vector2i GetWindowContentSize()
        {
            return new Vector2i(_windowCS.GetWindowContentSize());
        }

        public Color GetContentPixelColorAt(Vector2i postion)
        {
            return new Color(_windowCS.GetContentPixelColorAt(postion.Native()));
        }

        public Color GetContentPixelColorAt(Vector2f realtivePostion)
        {
            return new Color(_windowCS.GetContentPixelColorAt(realtivePostion.Native()));
        }

        public IGTWindow ContentPixelAtShouldBeColor(Vector2i position, Color color)
        {
            _windowCS.ContentPixelAtShouldBeColor(position.Native(), color.Native());
            return this;
        }

        public IGTWindow CenterWindow()
        {
            _windowCS.CenterWindow();
            return this;
        }

        public IGTWindow WindowNameShouldBe(string title)
        {
            _windowCS.WindowNameShouldBe(title);
            return this;
        }

        public IGTWindow ContentPixelAtShouldBeColor(
            Vector2f sliderColorCheckPostion,
            Color colorshouldbe,
            int errorPass
        )
        {
            _windowCS.ContentPixelAtShouldBeColor(
                sliderColorCheckPostion.Native(),
                colorshouldbe.Native(),
                errorPass
            );
            return this;
        }

        internal GTWindow_CS native()
        {
            return this._windowCS;
        }
    }
}
