using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using gui_tesing_library.Components;
using gui_tesing_library.Controllers;
using gui_tesing_library.Directives;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;

namespace gui_tesing_library
{
    public class SystemController : IGTSystem
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

        //private static readonly SystemController _instance = new SystemController();
        //private SystemController() { }
        //public static SystemController Instance => _instance;

        //public static Vector2 MaximizedWindowSize
        //{
        //    get
        //    {
        //        return new Vector2(
        //            WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXMAXIMIZED),
        //            WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYMAXIMIZED)
        //            );
        //    }
        //}

        //public OperatingSystem GetOSVersion()
        //{
        //    return Environment.OSVersion;
        //}


        //public GTWindow GetWindowByName(string name)
        //{
        //    try
        //    {
        //        Helpers.AwaitTrue(() => { return (long)WinApiWrapper.FindWindowA(null, name) > 0; });
        //        IntPtr winId = (IntPtr)WinApiWrapper.FindWindowA(null, name);

        //        return new GTWindow((long)winId);
        //    }
        //    catch (TimeoutException ex)
        //    {
        //        return null;
        //    }
        //}

        static IGTSystem _gtSystem = null;

        public static IGTSystem Instance
        {
            get
            {
                if (_gtSystem == null)
                {
                    _gtSystem = new SystemController();
                }

                return _gtSystem;
            }
        }

        public IEnumerable<IGTWindow> FindWindowByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTProcess> FindProcessByName(string name)
        {
            throw new NotImplementedException();
        }

        [Log]
        public IGTWindow FindTopWindowByName(string name)
        {
            IGTWindow window = new GTWindow(this._SystemCalls.FindWindowByName(name));
            return window;
        }

        public IGTSystem WindowOfNameShouldExist(string name)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return this._SystemCalls.FindWindowByName(name) != 0;
                },
                $"No window of name [{name}]"
            );
            return this;
        }

        public IEnumerable<IGTProcess> GetActiveProcesses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTWindow> GetActiveWindows()
        {
            throw new NotImplementedException();
        }

        public string GetClipBoardContent()
        {
            throw new NotImplementedException();
        }

        [Log]
        public IGTProcess StartProcess(string commandString)
        {
            Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);
            IGTProcess gtProcess = new GTProcess(_SystemCalls.CreateProcess(commandString));
            return gtProcess;
        }

        public GTSystemVersion OsVersion
        {
            get { return new GTSystemVersion(Environment.OSVersion); }
        }

        public Vector2 MaximizedWindowSize { get; set; }

        GTSystemVersion IGTSystem.GetSystemVersion()
        {
            throw new NotImplementedException();
        }

        public int GetWindowTitleBarHeight()
        {
            return this._SystemCalls.GetWindowTitleBarHeight();
        }

        public int GetWindowBorderWidth()
        {
            return this._SystemCalls.GetWindowBorderWidth();
        }

        public int GetWindowBorderHeight()
        {
            return this._SystemCalls.GetWindowBorderHeight();
        }

        public int GetWindowPadding()
        {
            return this._SystemCalls.GetWindowPadding();
        }
    }
}
