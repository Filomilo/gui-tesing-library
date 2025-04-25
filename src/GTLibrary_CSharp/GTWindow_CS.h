#pragma once
#include "../GtLibrary/GTWindow.h"
ref class GTWindow_CS
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
};

