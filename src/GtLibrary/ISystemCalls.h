#pragma once
#include "pch.h"
#include <string>
#include <vector>
#include <memory>
#include "GTSystemVersion.h"
#include "Vector2i.h"
#include "Color.h"
#include "Key.h"
class GTWindow;
class GTProcess;
class GTScreenshot;
class ISystemCalls {
public:
    virtual ~ISystemCalls() = default;

    virtual GTSystemVersion GetOsVersion() = 0;
    virtual Vector2i GetMaximizedWindowSize() = 0;
    virtual GTSystemVersion GetSystemVersion() = 0;
    virtual int StartProcess(const std::string& commandString) = 0;
    virtual std::string GetClipBoardContent() = 0;

    virtual std::vector<int> GetActiveWindows() = 0;
    virtual std::vector<int> FindWindowByName(const std::string& name) = 0;
    virtual std::vector<int> FindProcessByName(const std::string& name) = 0;
    virtual std::vector<int> GetActiveProcesses() = 0;
    virtual int FindTopWindowByName(const std::string& name) = 0;

    virtual void WindowOfNameShouldExist(const std::string& name) = 0;

    virtual int GetWindowTitleBarHeight() = 0;
    virtual int GetWindowBorderWidth() = 0;
    virtual int GetWindowBorderHeight() = 0;
    virtual int GetWindowPadding() = 0;
    virtual Vector2i GetScreenSize() = 0;
    virtual long GetRamUsageOfProcess(int handle) = 0;
	virtual void KillProcess(int handle) = 0;
    virtual bool IsProcesAlive(int handle) = 0;
	virtual Vector2i GetWindowPostion(int handle) = 0;
	virtual bool DoesWindowExist(int handle) = 0;
	virtual std::string GetWindowName(int handle) = 0;
	virtual bool IsWindowMinimized(int handle) = 0;
	virtual void SetWindowPosition(int handle, const Vector2i& position) = 0;
	virtual void MinizmizeWindow(int handle) = 0;
    virtual void MaximizeWindow(int handle) = 0;
	virtual int GetProcessOfWindow(int handle) = 0;
	virtual void CloseWindow(int handle) = 0;
	virtual void SetWindowSize(int handle, const Vector2i& size) = 0;
	virtual void BringWindowUpFront(int handle) = 0;
    virtual Color GetPixelColorAt(int handle, const Vector2i& position) = 0;
    virtual	void TypeText(const std::string& text) = 0;
	virtual void PressKey(Key key) = 0;
	virtual void ReleaseKey(Key key) = 0;
	virtual void ClickKey(Key key) = 0;

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

};

