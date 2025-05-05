#pragma once
#include "../GtLibrary/GTScreenshot.h"
public ref class ScreenShot_CS
{
private:
    GTScreenshot* native;
public:
	ScreenShot_CS(GTScreenshot* screen)
	{
        native = (screen);

	}
    ~ScreenShot_CS()
    {
        this->!ScreenShot_CS();
    }

    !ScreenShot_CS() 
    {
        delete native;
        native = nullptr;
    }

};

