﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Components;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public interface IGTSystem
    {
        GTSystemVersion OsVersion
        {
            get;
        }

        Vector2 MaximizedWindowSize { get; set; }

        GTSystemVersion GetSystemVersion();
        IGTProcess StartProcess(string commandString);
        string GetClipBoardContent();

        IEnumerable<IGTWindow> GetActiveWindows();
        IEnumerable<IGTWindow> FindWindowByName(string name);
        IEnumerable<IGTProcess> FindProcessByName(string name);
        IEnumerable<IGTProcess> GetActiveProcesses();
        IGTWindow FindTopWindowByName(string name);

        IGTSystem WindowOfNameShouldExist(string name);
    }
}
