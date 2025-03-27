using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Components;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    interface IGTSystem
    {
        IGTSystem Instance { get; }
        GTSystemVersion GetSystemVersion();
        IGTProcess StartProcess(string commandString);
        string GetClipBoardContent();

        IEnumerable<IGTWindow> GetActiveWindows();
        IEnumerable<IGTWindow> FindWindowByName(string name);
        IEnumerable<IGTProcess> FindProcessByName(string name);
        IEnumerable<IGTProcess> GetActiveProcesses();
    }
}
