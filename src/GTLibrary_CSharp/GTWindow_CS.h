#pragma once
using namespace System;

#include <memory>
#include <vector>
#include <string>
#include "GTProcess_CS.h"
#include "Vector2i_CS.h"
#include "Vector2f_CS.h"
#include "GTSystemVersion_CS.h"
#include "../GtLibrary/GTWindow.h"
#include "Color_CS.h"
#include "ScreenShot_CS.h"

ref class Vector2i_CS;
ref class Vector2f_CS;
ref class GTProcess_CS;
ref class Color_CS;
public ref class GTWindow_CS
{
private:
	
    GTWindow* _nativeWindow;
public:
		GTWindow_CS(GTWindow* nativeWindow) : _nativeWindow(nativeWindow) {}
		GTWindow_CS(std::shared_ptr<GTWindow> nativeWindow) : _nativeWindow(nativeWindow.get()) {}
		~GTWindow_CS() {
			delete _nativeWindow;
		}
		!GTWindow_CS() {
			delete _nativeWindow;
		}

    

        
        Vector2i_CS^ GetPosition() ;
        bool DoesExist() ;
        String^ GetName() ;
        bool IsMinimized() ;

        
        void MoveWindow(Vector2i_CS^ offset);
        void Minimize();
        void Maximize();
        GTProcess_CS^ GetProcessOfWindow();
        void Close();
        void SetWindowSize(int x, int y);
        void SetPosition(int x, int y);
        void BringUpFront();
        void SizeShouldBe( Vector2i_CS^ size);
        void ShouldWindowExist(bool exists);
        void KillProcess();

        void ShouldBeMinimized(bool state);
        String^ GetWindowName() ;

        Vector2i_CS^ GetWindowContentPosition() ;
        Vector2i_CS^ GetWindowContentSize();

        Color_CS^ GetContentPixelColorAt(const Vector2i_CS^ position) ;
        Color_CS^ GetContentPixelColorAt(const Vector2f_CS^ relativePosition) ;
        void ContentPixelAtShouldBeColor(const Vector2i_CS^ position, const Color_CS^ color);
        void CenterWindow();
        void WindowNameShouldBe(const String^ title);
        void ContentPixelAtShouldBeColor(const Vector2f_CS^ sliderColorCheckPosition, const Color_CS^ colorShouldBe, int errorPass);
		Vector2i_CS^ GetWindowSize();
		Vector2i_CS^ GetMaximizedWindowSize();
        ScreenShot_CS^ GetScreenshot();
        ScreenShot_CS^ GetScreenshotRect(const Vector2i_CS^ position, const Vector2i_CS^ size);
        Color_CS^ GetPixelColorAt(const Vector2i_CS^ position);
        void PixelAtShouldBeColor(const Vector2i_CS^ position, const Color_CS^ color);
		Vector2i_CS^ GetWindowPosition();
        GTWindow* GetNative();
};

