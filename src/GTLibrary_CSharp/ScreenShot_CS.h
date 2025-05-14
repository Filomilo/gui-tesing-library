#pragma once
using namespace System;

#include "../GtLibrary/GTScreenshot.h"
#include "Color_CS.h"
#include "Vector2i_CS.h"
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


    int GetWidth();
    int GetHeight();
    double CompareToImage(String^ filePathToCompare);
    Color_CS^ GetPixelColorAt(Vector2i_CS^ pos);
    void SaveAsBitmap(String^ file);
    void SimmilarityBetweenImagesShouldBe(String^ ImagePath, double simmilarity);
};

