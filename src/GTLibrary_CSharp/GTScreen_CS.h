#pragma once
#include "Vector2i_CS.h"
#include "Color_CS.h"
#include "ScreenShot_CS.h"
public ref class GTScreen_CS
{
public:

    Vector2i_CS^ GetSize();
    Vector2i_CS^ GetMaximizedWindowSize();


    ScreenShot_CS^ GetScreenshot();
    ScreenShot_CS^ GetScreenshotRect(Vector2i_CS^ position, Vector2i_CS^ size);
    Color_CS^ GetPixelColorAt(Vector2i_CS^ position);
    void PixelAtShouldBeColor(Vector2i_CS^ position, Color_CS^ colorColor);
};

