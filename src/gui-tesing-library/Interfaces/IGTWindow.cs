﻿using System.ComponentModel.Design;
using gui_tesing_library.Controllers;
using gui_tesing_library;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public interface IGTWindow: IGTScreen
    {
        Vector2i Position { get; }
        bool DoesExist { get; }
        string Name { get; }
        bool IsMinimized { get; }

        IGTWindow MoveWindow(Vector2i offset);
        IGTWindow Minimize();
        IGTWindow Maximize();
        IGTWindow GetProcessOfWindow();
        IGTWindow Close();
        IGTWindow SetWindowSize(int x, int y);
        IGTWindow SetPostion(int x, int y);
        IGTWindow BringUpFront();
        IGTWindow SizeShouldBe(Vector2i vector2I);
        IGTWindow ShouldWindowExist(bool v);
        IGTWindow KillProcess();

        IGTWindow ShouldBeMinimized(bool state);
    }
}