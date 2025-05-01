#pragma once
#pragma once
#include "pch.h"
#include "ISystemCalls.h"

class GTWindow;
class GTProcess;
class SystemCalls: public ISystemCalls
{
public:
    SystemCalls() = default;


     GTSystemVersion GetOsVersion();
     Vector2i GetMaximizedWindowSize();
     GTSystemVersion GetSystemVersion();
     int StartProcess(const std::string& commandString);
     std::string GetClipBoardContent();

     std::vector<int> GetActiveWindows();
     std::vector<int> FindWindowByName(const std::string& name);
     std::vector<int> FindProcessByName(const std::string& name);
     std::vector<int> GetActiveProcesses();
     int FindTopWindowByName(const std::string& name);

     void WindowOfNameShouldExist(const std::string& name);

     int GetWindowTitleBarHeight();
     int GetWindowBorderWidth();
     int GetWindowBorderHeight();
     int GetWindowPadding();
     Vector2i GetScreenSize();
     long GetRamUsageOfProcess(int handle);
     void KillProcess(int handle);
     bool IsProcesAlive(int handle);
     Vector2i GetWindowPostion(int handle);
     bool DoesWindowExist(int handle);
     std::string GetWindowName(int handle);
     bool IsWindowMinimized(int handle);
     void SetWindowPosition(int handle, const Vector2i& position);
     void MinizmizeWindow(int handle);
     void MaximizeWindow(int handle);
     int GetProcessOfWindow(int handle);
     void CloseWindow(int handle);
     void SetWindowSize(int handle, const Vector2i& size);
     void BringWindowUpFront(int handle);
     Color GetPixelColorAt(int handle, const Vector2i& position);
    	void TypeText(const std::string& text);
     void PressKey(Key key);
     void ReleaseKey(Key key);
     void ClickKey(Key key);

     Vector2i GetMousePosition();
     void MoveMouse(const Vector2i& offset);
     void SetMousePosition(const Vector2i& position);
     void ClickLeftMouse();
     void ClickRightMouse();
     void ClickMiddleMouse();
     void PressLeftMouse();
     void PressMiddleMouse();
     void PressRightMouse();
     void ReleaseLeftMouse();
     void ReleaseMiddleMouse();
     void ReleaseRightMouse();
     void ScrollMouse(int scrollValue);
     void MoveMouseTo(const Vector2i& position);

     GTScreenshot GetScreenshot();
     GTScreenshot GetScreenshotRect(Vector2i postion, Vector2i size);

   
};

