#pragma once
#include "GTSystemVersion.h"
#include "Vector2I.h"
#include "IGTProcess.h"
#include <string>
#include <vector>
#include "IGTWindow.h"
class IGTSystem
{
private: 
public:
        virtual GTSystemVersion GetOsVersion() = 0;
        virtual Vector2I GetMaximizedWindowSize() = 0;
        virtual void SetMaximizedWindowSize(Vector2I vec) = 0;

        GTSystemVersion GetSystemVersion();
        IGTProcess StartProcess(std::string commandString);
        std::string GetClipBoardContent();

        std::vector<IGTWindow> GetActiveWindows();
        std::vector<IGTWindow> FindWindowByName(std::string name);
        std::vector<IGTProcess> FindProcessByName(std::string name);
        std::vector<IGTProcess> GetActiveProcesses();
        IGTWindow FindTopWindowByName(std::string name);
        IGTSystem WindowOfNameShouldExist(std::string name);

        int GetWindowTitleBarHeight();
        int GetWindowBorderWidth();
        int GetWindowBorderHeight();
        int GetWindowPadding();
        Vector2I GetScreenSize();
    
};

