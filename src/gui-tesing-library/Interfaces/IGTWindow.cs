using System.ComponentModel.Design;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public interface IGTWindow : IGTScreen
    {
        Vector2i Position { get; }
        bool DoesExist { get; }
        string Name { get; }
        bool IsMinimized { get; }

        IGTWindow MoveWindow(Vector2i offset);
        IGTWindow Minimize();
        IGTWindow Maximize();
        IGTProcess GetProcessOfWindow();
        IGTWindow Close();
        IGTWindow SetWindowSize(int x, int y);
        IGTWindow SetPostion(int x, int y);
        IGTWindow BringUpFront();
        IGTWindow SizeShouldBe(Vector2i vector2I);
        IGTWindow ShouldWindowExist(bool v);
        IGTWindow KillProcess();

        IGTWindow ShouldBeMinimized(bool state);
        string GetWindowName();

        Vector2i GetWindowContentPosition();
        Vector2i GetWindowContentSize();

        Color GetContentPixelColorAt(Vector2i postion);
        IGTWindow ContentPixelAtShouldBeColor(Vector2i position, Color color);
        IGTWindow CenterWindow();
        IGTWindow WindowNameShouldBe(string title);
    }
}
