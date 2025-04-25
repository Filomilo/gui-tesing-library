#pragma once
#include <memory>
#include <vector>
#include <string>
#include "GTProcess_CS.h"
#include "GTWindow_CS.h"
#include "Vector2i_CS.h"
#include "GTSystemVersion_CS.h"
#include "../GtLibrary/GTSystem.h"

using namespace System;
using namespace System::Collections::Generic;

public ref class GTSystemControler_CS
{
    private:
        GTSystem* nativeSystem;
        static GTSystemControler_CS^ _Instance;
        GTSystemControler_CS() {
			nativeSystem = GTSystem::Instance().get();
        }
    public:

        static GTSystemControler_CS^ Instance()
        {
            if (_Instance == nullptr)
            {
                _Instance = gcnew GTSystemControler_CS();
            }
            return _Instance;
        }

        List<GTWindow_CS^>^ FindWindowByName(String^ name);
        List<GTProcess_CS^>^ FindProcessByName(String^ name);
        GTWindow_CS^ FindTopWindowByName(String^ name);
        GTSystemControler_CS^ WindowOfNameShouldExist(String^ name);
        List<GTProcess_CS^>^ GetActiveProcesses();
        List<GTWindow_CS^>^ GetActiveWindows();
        std::string GetClipBoardContent();
        GTProcess_CS^ StartProcess(String^ commandString);
        GTSystemVersion_CS^ GetOsVersion() ;
        GTSystemVersion_CS^ GetSystemVersion();

        int GetWindowTitleBarHeight();
        int GetWindowBorderWidth();
        int GetWindowBorderHeight();
        int GetWindowPadding();
        Vector2i_CS^ GetScreenSize();

        Vector2i_CS^ GetMaximizedWindowSize();
   };

