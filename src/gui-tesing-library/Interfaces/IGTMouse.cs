using gui_tesing_library.Controllers;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public interface IGTMouse
    {
        gui_tesing_library.Models.Vector2i Position { get; }
        IGTMouse MoveMouse(gui_tesing_library.Models.Vector2i offset);
        IGTMouse SetPosition(gui_tesing_library.Models.Vector2i position);
        IGTMouse ClickLeft();
        IGTMouse ClickRight();
        IGTMouse ClickMiddle();
        IGTMouse PressLeft();
        IGTMouse PressMiddle();
        IGTMouse PressRight();
        IGTMouse ReleaseLeft();
        IGTMouse ReleaseMiddle();
        IGTMouse ReleaseRight();
        IGTMouse Scroll(int scrollValue);
        IGTMouse SetPositionRelativeToWindow(IGTWindow window, gui_tesing_library.Models.Vector2i positon);
        IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2f positon);
        IGTMouse PositionShouldBe(gui_tesing_library.Models.Vector2i pos, int errorDistance = 0);
        IGTMouse MoveMouseTo(gui_tesing_library.Models.Vector2i newRedSliderPostion);
        IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, gui_tesing_library.Models.Vector2i position);
        IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, Vector2f vector2f);
        Vector2f GetPostionRelativeToWinodw(IGTWindow window);


        IGTMouse PositionRelativeToWindowShouldBe(IGTWindow window, Vector2f vector2f, float errorDistance = 0);

    }
}
