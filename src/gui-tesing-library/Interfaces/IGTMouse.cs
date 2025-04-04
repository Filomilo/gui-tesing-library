﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;

namespace gui_tesing_library
{
    public interface IGTMouse
    {
        Vector2i Position { get; }
        IGTMouse MoveMouse(Vector2i offset);
        IGTMouse SetPosition(Vector2i position);
        IGTMouse ClickLeft();
        IGTMouse ClickRight();
        IGTMouse ClickMiddle();
        IGTMouse PressLeft();
        IGTMouse PressMiddle();
        IGTMouse PressRight();
        IGTMouse ReleaseLeft();
        IGTMouse ReleaseMiddle();
        IGTMouse ReleaseRight();
        IGTMouse ScrollUp(int scrollValue);
        IGTMouse ScrollDown(int scrollValue);
        IGTMouse MoveRelativeToWindow(IGTWindow window, Vector2i offset);
        IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2i positon);

    }
}
