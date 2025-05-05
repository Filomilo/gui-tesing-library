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


     Vector2i GetMaximizedWindowSize();
     GTSystemVersion GetSystemVersion();
     HANDLE StartProcess(const std::string& commandString);
     std::wstring GetClipBoardContent();

     std::vector<HWND> GetActiveWindows();
     std::vector<HWND> FindWindowByName(const std::wstring& name);
     std::vector<HANDLE> FindProcessByName(const std::wstring& name);
     std::vector<HANDLE> GetActiveProcesses();
     HWND FindTopWindowByName(const std::wstring& name);

     int GetWindowTitleBarHeight();
     int GetWindowBorderWidth();
     int GetWindowBorderHeight();
     int GetWindowPadding();
     Vector2i GetScreenSize();
     long GetRamUsageOfProcess(HANDLE handle);
     void KillProcess(HANDLE handle);
     bool IsProcesAlive(HANDLE handle);
     Vector2i GetWindowPostion(HWND handle);
     bool DoesWindowExist(HWND handle);
     std::wstring GetWindowName(HWND handle);
     bool IsWindowMinimized(HWND handle);
     void SetWindowPosition(HWND handle, const Vector2i& position);
     void MinizmizeWindow(HWND handle);
     void MaximizeWindow(HWND handle);
     HANDLE GetProcessOfWindow(HWND handle);
     void TerminateWindow(HWND handle);
     void SetWindowSize(HWND handle, const Vector2i& size);
     void BringWindowUpFront(HWND handle);
     Color GetPixelColorAt(HWND handle, const Vector2i& position);
    	void TypeText(const std::wstring& text);
     void PressKey(GTKey key);
     void ReleaseKey(GTKey key);
     void ClickKey(GTKey key);

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

     GTScreenshot* GetScreenshot(HWND handle, Vector2i startPos, Vector2i size);
     Vector2i GetSizeOfWindow(HWND handle);
     std::wstring GetProcesName(HANDLE handle);
     std::vector<HWND> GetWindowsOfProcess(HANDLE handle);

};

