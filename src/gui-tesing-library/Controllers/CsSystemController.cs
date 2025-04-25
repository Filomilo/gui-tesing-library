using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using gui_tesing_library.Components;
using gui_tesing_library.Controllers;
using gui_tesing_library.Directives;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;

namespace gui_tesing_library
{
    public class CsSystemController : IGTSystem
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

        static IGTSystem _gtSystem = null;

        public static IGTSystem Instance
        {
            get
            {
                if (_gtSystem == null)
                {
                    _gtSystem = new CsSystemController();
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
            int handle = this._SystemCalls.FindWindowByName(name);
            if (handle <= 0)
                return null;
            IGTWindow window = new GTWindow(handle);
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
            return this._SystemCalls.GetClipBoardData();
        }

        [Log]
        public IGTProcess StartProcess(string commandString)
        {
            throw new NotImplementedException();
            //Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);
            //IGTProcess gtProcess = new GTProcess_CS(_SystemCalls.CreateProcess(commandString));
            //return gtProcess;
        }

        public GTSystemVersion OsVersion
        {
            get { return new GTSystemVersion(Environment.OSVersion); }
        }

        public Vector2i MaximizedWindowSize { get; }

        public GTSystemVersion GetOsVersion()
        {
            throw new NotImplementedException();
        }

        public Vector2i GetMaximizedWindowSize()
        {
            throw new NotImplementedException();
        }

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

        public Vector2i GetScreenSize()
        {
            return this._SystemCalls.GetScreenSize();
        }
    }
}
