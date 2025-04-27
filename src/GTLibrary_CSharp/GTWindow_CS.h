#pragma once
#include <memory>
#include <vector>
#include <string>
#include "GTProcess_CS.h"
#include "GTWindow_CS.h"
#include "Vector2i_CS.h"
#include "Vector2f_CS.h"
#include "GTSystemVersion_CS.h"
#include "../GtLibrary/GTWindow.h"
#include "Color_CS.h"
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
        bool^ DoesExist() ;
        String^ GetName() ;
        bool^ IsMinimized() ;

        
        GTWindow_CS^ MoveWindow(const Vector2i_CS^ offset);
        GTWindow_CS^ Minimize();
        GTWindow_CS^ Maximize();
        GTProcess_CS^ GetProcessOfWindow();
        GTWindow_CS^ Close();
        GTWindow_CS^ SetWindowSize(int x, int y);
        GTWindow_CS^ SetPosition(int x, int y);
        GTWindow_CS^ BringUpFront();
        GTWindow_CS^ SizeShouldBe(const Vector2i_CS^ size);
        GTWindow_CS^ ShouldWindowExist(bool exists);
        GTWindow_CS^ KillProcess();

        GTWindow_CS^ ShouldBeMinimized(bool state);
        String^ GetWindowName() ;

        Vector2i_CS^ GetWindowContentPosition() ;
        Vector2i_CS^ GetWindowContentSize();

        Color_CS^ GetContentPixelColorAt(const Vector2i_CS^ position) ;
        Color_CS^ GetContentPixelColorAt(const Vector2f_CS^ relativePosition) ;
        GTWindow_CS^ ContentPixelAtShouldBeColor(const Vector2i_CS^ position, const Color_CS^ color);
        GTWindow_CS^ CenterWindow();
        GTWindow_CS^ WindowNameShouldBe(const String^ title);
        GTWindow_CS^ ContentPixelAtShouldBeColor(const Vector2f_CS^ sliderColorCheckPosition, const Color_CS^ colorShouldBe, int errorPass);

};

