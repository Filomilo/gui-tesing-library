using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Models;

namespace gui_tesing_library.Controllers
{
    public class SystemController : IGTSystem
    {
        public static SystemController Instance { get; } = null;
        public GTSystemVersion OsVersion
        {
            get { return null; }
        }

        public Vector2 MaximizedWindowSize { get; set; }

        public GTSystemVersion GetSystemVersion()
        {
            throw new NotImplementedException();
        }

        public IGTProcess StartProcess(string commandString)
        {
            throw new NotImplementedException();
        }

        public string GetClipBoardContent()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTWindow> GetActiveWindows()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTWindow> FindWindowByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTProcess> FindProcessByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTProcess> GetActiveProcesses()
        {
            throw new NotImplementedException();
        }

        public IGTWindow FindTopWindowByName(string name)
        {
            throw new NotImplementedException();
        }

        public IGTSystem WindowOfNameShouldExist(string name)
        {
            throw new NotImplementedException();
        }

        public int GetWindowTitleBarHeight()
        {
            throw new NotImplementedException();
        }

        public int GetWindowBorderWidth()
        {
            throw new NotImplementedException();
        }

        public int GetWindowBorderHeight()
        {
            throw new NotImplementedException();
        }

        public int GetWindowPadding()
        {
            throw new NotImplementedException();
        }

        public Vector2i GetScreenSize()
        {
            throw new NotImplementedException();
        }
    }
}
