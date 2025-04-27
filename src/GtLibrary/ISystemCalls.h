#pragma once
#include "pch.h"
#include <string>
#include <vector>
#include <memory>
#include "GTSystemVersion.h"
#include "Vector2i.h"
class GTWindow;
class GTProcess;
class ISystemCalls {
public:
    virtual ~ISystemCalls() = default;

    virtual GTSystemVersion GetOsVersion() = 0;
    virtual Vector2i GetMaximizedWindowSize() = 0;
    virtual GTSystemVersion GetSystemVersion() = 0;
    virtual std::shared_ptr<GTProcess> StartProcess(const std::string& commandString) = 0;
    virtual std::string GetClipBoardContent() = 0;

    virtual std::vector<std::shared_ptr<GTWindow>> GetActiveWindows() = 0;
    virtual std::vector<std::shared_ptr<GTWindow>> FindWindowByName(const std::string& name) = 0;
    virtual std::vector<std::shared_ptr<GTProcess>> FindProcessByName(const std::string& name) = 0;
    virtual std::vector<std::shared_ptr<GTProcess>> GetActiveProcesses() = 0;
    virtual std::shared_ptr<GTWindow> FindTopWindowByName(const std::string& name) = 0;

    virtual void WindowOfNameShouldExist(const std::string& name) = 0;

    virtual int GetWindowTitleBarHeight() = 0;
    virtual int GetWindowBorderWidth() = 0;
    virtual int GetWindowBorderHeight() = 0;
    virtual int GetWindowPadding() = 0;
    virtual Vector2i GetScreenSize() = 0;
};

