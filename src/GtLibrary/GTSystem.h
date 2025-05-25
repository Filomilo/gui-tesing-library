#pragma once
#include "pch.h"
#include "SystemCalls.h"
#include <vector>
#include <string>
#include "GTWindow.h"
#include "GTProcess.h"
#include "GTSystemVersion.h"
#include "Vector2i.h"
#include <optional>
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

    std::vector<GTWindow> FindWindowByName(const std::wstring& name);
    std::vector<GTProcess> FindProcessByName(const std::string& name);
    std::optional<GTWindow>  FindTopWindowByName(const std::string& name);
   void WindowOfNameShouldExist(const std::string& name);
    std::vector<GTProcess> GetActiveProcesses();
    std::vector<GTWindow> GetActiveWindows();
    std::wstring GetClipBoardContent();
    GTProcess StartProcess(const std::string& commandString);
    GTSystemVersion GetOsVersion() const;
    GTSystemVersion GetSystemVersion();

    int GetWindowTitleBarHeight();
    int GetWindowBorderWidth();
    int GetWindowBorderHeight();
    int GetWindowPadding();
    Vector2i GetScreenSize();

    Vector2i GetMaximizedWindowSize();
};

