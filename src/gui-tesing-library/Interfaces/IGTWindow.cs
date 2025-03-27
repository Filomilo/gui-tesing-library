using System.ComponentModel.Design;
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
        IGTProcess MoveWindow(Vector2i offset);
        IGTProcess Minimize();
        IGTProcess Maximize();
        IGTProcess GetProcessOfWindow();
        IGTProcess Close();
    }
}