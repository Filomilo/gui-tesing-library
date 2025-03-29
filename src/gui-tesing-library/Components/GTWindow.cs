using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Directives;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;
using Microsoft.Win32.SafeHandles;
using static gui_tesing_library.WinApiWrapper;

namespace gui_tesing_library.Components
{
    public class GTWindow : IGTWindow
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();
        private int _handle;
        public GTWindow(int handle)
        {
            if (handle == 0)
                throw new ArgumentException("Window cannot have handle 0");
            _handle=handle;
        }
        //private long _HWnd;

        //public GTWindow(long hWnd)
        //{
        //    _HWnd = hWnd;
        //}

        //public GTProcess Process
        //{
        //    get
        //    {
        //        GetWindowThreadProcessId(new IntPtr(this._HWnd),out uint lpdwProcess);
        //        return new GTProcess(System.Diagnostics.Process.GetProcessById(
        //             (int)   lpdwProcess
        //          )
        //            );

        //    }
        //}


        //public Vector2 Size{
        //    get
        //    {
        //        WinApiWrapper.GetWindowRect( new IntPtr(this._HWnd) , out RECT lpRect);
        //        return new Vector2(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
        //    }
        //}

        //public bool IsMinimized
        //{
        //    get
        //    {
        //        return WinApiWrapper.IsIconic(new IntPtr(this._HWnd) );
        //    }
        //}

        //public Vector2 Postion
        //{
        //    get
        //    {
        //        WinApiWrapper.GetWindowRect(new IntPtr(this._HWnd), out RECT lpRect);
        //        return new Vector2(lpRect.Left, lpRect.Top);
        //    }
        //}

        //public bool DoesExist()
        //{

        //    return WinApiWrapper.IsWindow(new IntPtr(this._HWnd));


        //}

        //public void SetPostion(int x, int y)
        //{
        //    Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);
        //    WinApiWrapper.SetWindowPos(new IntPtr(this._HWnd), 0, x, y, 0, 0, UFlags.SWP_NOSIZE);

        //}

        //public void KillProces()
        //{
        //    Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);

        //    this.Process.kill();
        //    Helpers.AwaitTrue(() =>
        //    {
        //        return this.DoesExist() == false;
        //    });
        //}

        //public void SetWindowSize(int x, int y)
        //{
        //    Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);

        //    WinApiWrapper.SetWindowPos(new IntPtr(this._HWnd), 0, 0, 0, x, y, UFlags.SWP_NOMOVE);
        //}

        //public void Minimize()
        //{
        //    Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);

       
        //}

        //public void Maximize()
        //{
        //    Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);

        //    WinApiWrapper.ShowWindow(new IntPtr(this._HWnd),
        //        NCmdShow.SW_SHOWMAXIMIZED
        //    );
        //}

        //public void BringUpFront()
        //{

        //}

        //public void Destroy()
        //{
        //    Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);
        //    WinApiWrapper.DestroyWindow(new IntPtr(this._HWnd));
        //    Helpers.AwaitTrue(() =>
        //    {
        //        return this.DoesExist() == false;
        //    });
        //}
        public Vector2i Position
        {
            get
            {
                return this._SystemCalls.GetWindowPositon(this._handle);
            }
        }

        public bool DoesExist
        {
            get
            {
                return this._SystemCalls.DoesWindowExist(this._handle);
            }
        }

        public string Name => throw new NotImplementedException();
        public bool IsMinimized
        {       get
                {
                    return this._SystemCalls.IsWindowsMinimized(this._handle);
                }
        }

        public Vector2i Size
        {
            get
            {
                return this._SystemCalls.GetWindowSize(this._handle);
            }
        }
        public Vector2i MaximizedWindowSize { get; }
        [Log]
        IGTWindow IGTWindow.GetProcessOfWindow()
        {
            throw new NotImplementedException();
        }

        [Log]
        IGTWindow IGTWindow.Close()
        {
            this._SystemCalls.CloseWindow(this._handle);
            return this;
        }
        [Log]
        public IGTWindow SetWindowSize(int x, int y)
        {
            this._SystemCalls.SetWindowSize(this._handle, new Vector2i(x, y));
            return this;
        }
        [Log]
        public IGTWindow SetPostion(int x, int y)
        {
            this._SystemCalls.SetWindowPostion(this._handle, new Vector2i(x, y));
            return this;
        }
        [Log]
        public IGTWindow BringUpFront()
        {
            this._SystemCalls.BringWindowUpFront(this._handle);
            return this;
        }

        [Log]
        public IGTProcess Close()
        {
            throw new NotImplementedException();
        }
        [Log]
        public Color GetPixelColorAt(Vector2i postion)
        {
            throw new NotImplementedException();
        }
        [Log]
        IGTWindow IGTWindow.Maximize()
        {
            this._SystemCalls.MaximizeWindow(this._handle);
            return this;
        }
        [Log]
        public IGTProcess GetProcessOfWindow()
        {
            int processHandle =
                this._SystemCalls.GetProcessHandleFromId(this._SystemCalls.GetWindowThreadProcessId(this._handle));
             return new GTProcess(processHandle);

        }
        [Log]
        public ScreenShot GetScreenshot()
        {
            throw new NotImplementedException();
        }
        [Log]
        public ScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
        {
            throw new NotImplementedException();
        }
        [Log]
        IGTWindow IGTWindow.Minimize()
        {
            this._SystemCalls.MinimizeWindow(this._handle);
            return this;
        }
        [Log]
        public IGTProcess Maximize()
        {
            throw new NotImplementedException();
        }
        [Log]
        IGTWindow IGTWindow.MoveWindow(Vector2i offset)
        {
            throw new NotImplementedException();
        }
        [Log]
        public IGTProcess Minimize()
        {
            throw new NotImplementedException();
        }
        [Log]
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
            Helpers.AwaitTrue((() => this.DoesExist == v));
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
                return this.IsMinimized==state;
            });
            return this;
        }
    }
}
