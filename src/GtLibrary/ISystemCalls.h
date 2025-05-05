#pragma once
#include "pch.h"
#include <string>
#include <vector>
#include <memory>
#include "GTSystemVersion.h"
#include "Vector2i.h"
#include "Color.h"
#include "Key.h"
#include <string>
#include "Windows.h"
class GTWindow;
class GTProcess;
class GTScreenshot;
class ISystemCalls {
public:
    virtual ~ISystemCalls() = default;

    virtual GTSystemVersion GetOsVersion() = 0;
    virtual Vector2i GetMaximizedWindowSize() = 0;
    virtual GTSystemVersion GetSystemVersion() = 0;
    virtual HANDLE StartProcess(const std::string& commandString) = 0;
    virtual std::wstring GetClipBoardContent() = 0;

    virtual std::vector<HWND> GetActiveWindows() = 0;
    virtual std::vector<HWND> FindWindowByName(const std::wstring& name) = 0;
    virtual std::vector<HANDLE> FindProcessByName(const std::wstring& name) = 0;
    virtual std::vector<HANDLE> GetActiveProcesses() = 0;
    virtual HWND FindTopWindowByName(const std::wstring& name) = 0;


    virtual int GetWindowTitleBarHeight() = 0;
    virtual int GetWindowBorderWidth() = 0;
    virtual int GetWindowBorderHeight() = 0;
    virtual int GetWindowPadding() = 0;
    virtual Vector2i GetScreenSize() = 0;
    virtual long GetRamUsageOfProcess(HANDLE handle) = 0;
	virtual void KillProcess(HANDLE handle) = 0;
    virtual bool IsProcesAlive(HANDLE handle) = 0;
	virtual Vector2i GetWindowPostion(HWND handle) = 0;
	virtual bool DoesWindowExist(HWND handle) = 0;
	virtual std::wstring GetWindowName(HWND handle) = 0;
	virtual bool IsWindowMinimized(HWND handle) = 0;
	virtual void SetWindowPosition(HWND handle, const Vector2i& position) = 0;
	virtual void MinizmizeWindow(HWND handle) = 0;
    virtual void MaximizeWindow(HWND handle) = 0;
	virtual HANDLE GetProcessOfWindow(HWND handle) = 0;
	virtual void TerminateWindow(HWND handle) = 0;
	virtual void SetWindowSize(HWND handle, const Vector2i& size) = 0;
	virtual void BringWindowUpFront(HWND handle) = 0;
    virtual Color GetPixelColorAt(HWND handle, const Vector2i& position) = 0;
    virtual	void TypeText(const std::wstring& text) = 0;
	virtual void PressKey(GTKey key) = 0;
	virtual void ReleaseKey(GTKey key) = 0;
	virtual void ClickKey(GTKey key) = 0;

    virtual Vector2i GetMousePosition() = 0;
    virtual void MoveMouse(const Vector2i& offset) = 0;
    virtual void SetMousePosition(const Vector2i& position) = 0;
    virtual void ClickLeftMouse() = 0;
    virtual void ClickRightMouse() = 0;
    virtual void ClickMiddleMouse() = 0;
    virtual void PressLeftMouse() = 0;
    virtual void PressMiddleMouse() = 0;
    virtual void PressRightMouse() = 0;
    virtual void ReleaseLeftMouse() = 0;
    virtual void ReleaseMiddleMouse() = 0;
    virtual void ReleaseRightMouse() = 0;
    virtual void ScrollMouse(int scrollValue) = 0;
    virtual void MoveMouseTo(const Vector2i& position) = 0;
    
    virtual GTScreenshot GetScreenshot()=0;
    virtual GTScreenshot GetScreenshotRect(Vector2i postion, Vector2i size)=0;
    virtual Vector2i GetSizeOfWindow(HWND handle)=0;
    virtual std::wstring GetProcesName(HANDLE handle) = 0;
    virtual std::vector<HWND> GetWindowsOfProcess(HANDLE handle) = 0;

};

