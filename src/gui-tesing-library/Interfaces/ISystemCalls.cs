using gui_tesing_library.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Interfaces
{
    public interface ISystemCalls
    {
        int CreateProcess(string startCommand);
        bool GetDoesProcessExist(int handle);
         void TerminateProcess(int handle);
         int FindWindowByName(string name);
        Vector2i GetWindowPositon(int handle);
        Vector2i GetWindowSize(int handle);
        void CloseWindow(int handle);
        bool DoesWindowExist(int handle);
        int GetWindowThreadProcessId(int handle);
        int GetProcessHandleFromId(int id);
        void MinimizeWindow(int handle);
        bool IsWindowsMinimized(int handle);
        void BringWindowUpFront(int handle);
        void MaximizeWindow(int handle);
        Vector2i GetMaximizedWindowSize();
        void SetWindowPostion(int handle, Vector2i vector2i);
        void SetWindowSize(int handle, Vector2i vector2i);
        void SetMousePostion(Vector2i position);
        Vector2i GetMousePosition();
    }
}
