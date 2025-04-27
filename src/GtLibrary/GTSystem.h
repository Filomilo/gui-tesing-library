#pragma once
#include "pch.h"
#include "SystemCalls.h"
#include <vector>
#include <string>
#include "GTWindow.h"
#include "GTProcess.h"
#include "GTSystemVersion.h"
#include "Vector2i.h"

class GTWindow;
class GTProcess;
class GTSystemVersion;
class SystemCalls;

class GTSystem
{
private:
    std::shared_ptr<SystemCalls> _SystemCalls;
    static std::shared_ptr<GTSystem> _gtSystem;
    GTSystem();
public:

    static std::shared_ptr<GTSystem> Instance();

    std::vector<std::shared_ptr<GTWindow>> FindWindowByName(const std::string& name);
    std::vector<std::shared_ptr<GTProcess>> FindProcessByName(const std::string& name);
    std::shared_ptr<GTWindow> FindTopWindowByName(const std::string& name);
    std::shared_ptr<GTSystem> WindowOfNameShouldExist(const std::string& name);
    std::vector<std::shared_ptr<GTProcess>> GetActiveProcesses();
    std::vector<std::shared_ptr<GTWindow>> GetActiveWindows();
    std::string GetClipBoardContent();
    std::shared_ptr<GTProcess> StartProcess(const std::string& commandString);
    GTSystemVersion GetOsVersion() const;
    GTSystemVersion GetSystemVersion();

    int GetWindowTitleBarHeight();
    int GetWindowBorderWidth();
    int GetWindowBorderHeight();
    int GetWindowPadding();
    Vector2i GetScreenSize();

    Vector2i GetMaximizedWindowSize();
};

