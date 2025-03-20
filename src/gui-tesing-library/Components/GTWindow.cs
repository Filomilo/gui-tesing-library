using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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


        public Vector2 Size{
            get
            {
                WinApiWrapper.GetWindowRect( new IntPtr(this._HWnd) , out RECT lpRect);
                return new Vector2(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
            }
        }



    }
}
