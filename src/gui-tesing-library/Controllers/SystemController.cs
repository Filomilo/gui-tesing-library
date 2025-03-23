using gui_tesing_library.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gui_tesing_library
{
     public class SystemController
    {
        private static readonly SystemController _instance = new SystemController();
        private SystemController() { }
        public static SystemController Instance => _instance;

        public static Vector2 MaximizedWindowSize
        {
            get
            {
                return new Vector2(
                    WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXMAXIMIZED),
                    WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYMAXIMIZED)
                    );
            }
        }

        public OperatingSystem GetOSVersion()
        {
            return Environment.OSVersion;
        }

        public GTProcess StartProcess(string v)
        {
            Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);
            GTProcess gtProcess = new GTProcess(WinApiWrapper.CreateProcess(v));
            return gtProcess;
        }

        public GTWindow GetWindowByName(string name)
        {
            try
            {
                Helpers.AwaitTrue(() => { return (long)WinApiWrapper.FindWindowA(null, name) > 0; });
                IntPtr winId = (IntPtr)WinApiWrapper.FindWindowA(null, name);

                return new GTWindow((long)winId);
            }
            catch (TimeoutException ex)
            {
                return null;
            }
        }

        
    }
}
