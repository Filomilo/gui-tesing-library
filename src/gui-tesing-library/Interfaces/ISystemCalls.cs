using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;

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
        string GetWindowName(int handle);
        void ClickLeft();
        void ClickMiddle();
        void ClickRight();
        void PressLeft();
        void PressMiddle();
        void PressRight();
        void ReleaseLeft();
        void ReleaseMiddle();
        void ReleaseRight();
        void Scroll(int scrollValue);
        int GetWindowTitleBarHeight();
        int GetWindowBorderWidth();
        int GetWindowBorderHeight();
        int GetWindowPadding();
        ScreenShot GetScreenShotFromHandle(int handle, Vector2i StartPosition, Vector2i Size);
        Vector2i GetScreenSize();
        Color GetPixelColorAt(Vector2i postion, int handle);
        void MoveMouse(Vector2i offset);
        void MoveMouseTo(Vector2i newPos);
        void TypeText(string text);
        void ClickKey(Key key);
        void ReleaseKey(Key key);
        void PressKey(Key key);
    }
}
