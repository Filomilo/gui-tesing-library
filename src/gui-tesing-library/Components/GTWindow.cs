using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using static gui_tesing_library.WinApiWrapper;

namespace gui_tesing_library.Components
{
    public class GTWindow
    {
        private long _HWnd;

        public GTWindow(long hWnd)
        {
            _HWnd = hWnd;
        }

        public GTProcess Process
        {
            get
            {
                GetWindowThreadProcessId(new IntPtr(this._HWnd),out uint lpdwProcess);
                return new GTProcess(System.Diagnostics.Process.GetProcessById(
                     (int)   lpdwProcess
                  )
                    );
               
            }
        }


        public Vector2 Size{
            get
            {
                WinApiWrapper.GetWindowRect( new IntPtr(this._HWnd) , out RECT lpRect);
                return new Vector2(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
            }
        }

        public bool IsMinimized
        {
            get
            {
                return WinApiWrapper.IsIconic(new IntPtr(this._HWnd) );
            }
        }

        public Vector2 Postion
        {
            get
            {
                WinApiWrapper.GetWindowRect(new IntPtr(this._HWnd), out RECT lpRect);
                return new Vector2(lpRect.Left, lpRect.Top);
            }
        }

        public bool DoesExist()
        {
            return WinApiWrapper.IsWindow(new IntPtr(this._HWnd));


        }

        public void SetPostion(int x, int y)
        {
            WinApiWrapper.SetWindowPos(new IntPtr(this._HWnd), 0, x, y, 0, 0, UFlags.SWP_NOSIZE);

        }

        public void KillProces()
        {
            this.Process.kill();
            Helpers.AwaitTrue(() =>
            {
                return this.DoesExist() == false;
            });
        }

        public void SetWindowSize(int x, int y)
        {
            WinApiWrapper.SetWindowPos(new IntPtr(this._HWnd), 0, 0, 0, x, y, UFlags.SWP_NOMOVE);
        }

        public void Minimize()
        {
            WinApiWrapper.ShowWindow(new IntPtr(this._HWnd),
                NCmdShow.SW_MINIMIZE
            );
        }

        public void Maximize()
        {
            WinApiWrapper.ShowWindow(new IntPtr(this._HWnd),
                NCmdShow.SW_SHOWMAXIMIZED
            );
        }

        public void BringUpFront()
        {
             WinApiWrapper.ShowWindow(new IntPtr(this._HWnd),
                NCmdShow.SW_RESTORE
            );
            bool returnVal= WinApiWrapper.ShowWindow(new IntPtr(this._HWnd),
                NCmdShow.SW_SHOW
            );
            WinApiWrapper.BringWindowToTop(new IntPtr(this._HWnd));
            int error = WinApiWrapper.GetLastError();
            Console.WriteLine($"Last Error: {error}");
        }

        public void Destroy()
        {
            WinApiWrapper.DestroyWindow(new IntPtr(this._HWnd));
            Helpers.AwaitTrue(() =>
            {
                return this.DoesExist() == false;
            });
        }




    }
}
