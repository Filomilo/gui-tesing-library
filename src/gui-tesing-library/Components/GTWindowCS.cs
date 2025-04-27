using System;
using gui_tesing_library.Controllers;
using gui_tesing_library.Directives;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;

namespace gui_tesing_library.Components
{
    public class GTWindowCS : IGTWindow
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();
        private int _handle;

        public GTWindowCS(int handle)
        {
            if (handle == 0)
                throw new ArgumentException("Window cannot have handle 0");
            _handle = handle;
        }

        public Vector2i Position
        {
            get { return this._SystemCalls.GetWindowPositon(this._handle); }
        }

        public bool DoesExist
        {
            get { return this._SystemCalls.DoesWindowExist(this._handle); }
        }

        public string Name => throw new NotImplementedException();
        public bool IsMinimized
        {
            get { return this._SystemCalls.IsWindowsMinimized(this._handle); }
        }

        public Vector2i Size
        {
            get { return this._SystemCalls.GetWindowSize(this._handle); }
        }
        public Vector2i MaximizedWindowSize { get; }

        [Delay]
        [Log]
        IGTWindow IGTWindow.Close()
        {
            this._SystemCalls.CloseWindow(this._handle);
            return this;
        }

        [Log]
        [Delay]
        public IGTWindow SetWindowSize(int x, int y)
        {
            this._SystemCalls.SetWindowSize(this._handle, new Vector2i(x, y));
            return this;
        }

        [Log]
        [Delay]
        public IGTWindow SetPostion(int x, int y)
        {
            this._SystemCalls.SetWindowPostion(this._handle, new Vector2i(x, y));
            return this;
        }

        [Log]
        [Delay]
        public IGTWindow BringUpFront()
        {
            this._SystemCalls.BringWindowUpFront(this._handle);
            return this;
        }

        [Log]
        [Delay]
        public IGTProcess Close()
        {
            throw new NotImplementedException();
        }

        [Log]
        public Color GetPixelColorAt(Vector2i postion)
        {
            return SystemCallsFactory.GetSystemCalls().GetPixelColorAt(postion, this._handle);
        }

        [Log]
        public IGTScreen PixelAtShouldBeColor(Vector2i position, Color color)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return GetPixelColorAt(position).Equals(color);
                },
                $"Pixel color at {position} of window {this.GetWindowName()} was not {color} with in given time"
            );
            return this;
        }

        [Log]
        [Delay]
        IGTWindow IGTWindow.Maximize()
        {
            this._SystemCalls.MaximizeWindow(this._handle);
            return this;
        }

        [Log]
        public IGTProcess GetProcessOfWindow()
        {
            throw new NotImplementedException();
            //int processHandle = this._SystemCalls.GetProcessHandleFromId(
            //    this._SystemCalls.GetWindowThreadProcessId(this._handle)
            //);
            //return new GTProcess_CS(processHandle);
        }

        [Log]
        public ScreenShot GetScreenshot()
        {
            return SystemCallsFactory
                .GetSystemCalls()
                .GetScreenShotFromHandle(
                    this._handle,
                    new Vector2i(0, 0),
                    this.GetWindowContentSize()
                );
        }

        [Log]
        [Delay]
        public ScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
        {
            throw new NotImplementedException();
        }

        [Log]
        [Delay]
        IGTWindow IGTWindow.Minimize()
        {
            this._SystemCalls.MinimizeWindow(this._handle);
            return this;
        }

        [Log]
        [Delay]
        public IGTProcess Maximize()
        {
            throw new NotImplementedException();
        }

        [Log]
        [Delay]
        IGTWindow IGTWindow.MoveWindow(Vector2i offset)
        {
            throw new NotImplementedException();
        }

        [Log]
        [Delay]
        public IGTProcess Minimize()
        {
            throw new NotImplementedException();
        }

        [Log]
        [Delay]
        public IGTProcess MoveWindow(Vector2i offset)
        {
            throw new NotImplementedException();
        }

        [Log]
        IGTWindow IGTWindow.SizeShouldBe(Vector2i vector2I)
        {
            Helpers.AwaitTrue(() =>
            {
                return this.Size.Equals(vector2I);
            });
            return this;
        }

        [Log]
        IGTWindow IGTWindow.ShouldWindowExist(bool v)
        {
            Helpers.AwaitTrue(
                (() => this.DoesExist == v),
                $"Window {this.GetWindowName()} is not {v} within max time"
            );
            return this;
        }

        [Log]
        IGTWindow IGTWindow.KillProcess()
        {
            this.GetProcessOfWindow().kill();
            return this;
        }

        [Log]
        public IGTWindow ShouldBeMinimized(bool state)
        {
            Helpers.AwaitTrue(() =>
            {
                return this.IsMinimized == state;
            });
            return this;
        }

        [Log]
        public string GetWindowName()
        {
            return SystemCallsFactory.GetSystemCalls().GetWindowName(this._handle);
        }

        public Vector2i GetWindowContentPosition()
        {
            Vector2i positon = this.Position;
            return new Vector2i(
                positon.x + SystemController.Instance.GetWindowBorderWidth(),
                positon.y
                    + SystemController.Instance.GetWindowBorderHeight()
                    + SystemController.Instance.GetWindowTitleBarHeight()
            );
        }

        public Vector2i GetWindowContentSize()
        {
            Vector2i size = this.Size;
            int borderWidth = SystemController.Instance.GetWindowBorderWidth();
            int windwopadding = SystemController.Instance.GetWindowPadding();
            int WindowBorderHeight = SystemController.Instance.GetWindowBorderHeight();
            int windowtielebarheight = SystemController.Instance.GetWindowTitleBarHeight();
            return new Vector2i(
                size.x - borderWidth * 2 - windwopadding * 2 - 1,
                size.y - WindowBorderHeight * 2 - windowtielebarheight - windwopadding * 2 - 5
            );
        }

        [Log]
        [Delay]
        public Color GetContentPixelColorAt(Vector2i postion)
        {
            //Vector2i WindowPOsiton = this.Position;
            //Vector2i ContnetPostion = this.GetWindowContentPosition();
            //Vector2i offset = ContnetPostion - WindowPOsiton;
            //Vector2i newPos = postion + offset;
            return this.GetPixelColorAt(postion);
        }

        public Color GetContentPixelColorAt(Vector2f realtivePostion)
        {
            Vector2i contentSize = this.GetWindowContentSize();
            return GetContentPixelColorAt(
                new Vector2i(
                    (int)(contentSize.x * realtivePostion.x),
                    (int)(contentSize.y * realtivePostion.y)
                )
            );
        }

        public IGTWindow ContentPixelAtShouldBeColor(Vector2i position, Color color)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return GetContentPixelColorAt(position).Equals(color);
                },
                $"Content Pixel color at {position} of window {this.GetWindowName()} was not {color} but {GetContentPixelColorAt(position)} with in given time"
            );
            return this;
        }

        public IGTWindow CenterWindow()
        {
            Vector2i screenSize = SystemController.Instance.GetScreenSize();
            Vector2i windowSize = this.Size;
            Vector2i diffrence = screenSize - windowSize;
            this.SetPostion(diffrence.x / 2, diffrence.y / 2);

            return this;
        }

        public IGTWindow WindowNameShouldBe(string title)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return this.GetWindowName() == title;
                },
                $"Window name was not [[{title}]] but [[{this.GetWindowName()}]] within {Configuration.ProcesAwaitTime} ms"
            );
            return this;
        }

        public IGTWindow ContentPixelAtShouldBeColor(
            Vector2f sliderColorCheckPostion,
            Color colorshouldbe,
            int errorPass
        )
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return GetContentPixelColorAt(sliderColorCheckPostion)
                            .getDiffrence(colorshouldbe) < errorPass;
                },
                $"Content Pixel color at {sliderColorCheckPostion} of window {this.GetWindowName()} was not {colorshouldbe} but {GetContentPixelColorAt(sliderColorCheckPostion)} with in given time, difreance: [[{GetContentPixelColorAt(sliderColorCheckPostion).getDiffrence(colorshouldbe)}]], with error pass [[{errorPass}]]"
            );
            return this;
        }
    }
}
