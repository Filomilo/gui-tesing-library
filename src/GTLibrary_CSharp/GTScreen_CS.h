#pragma once
#include "Vector2i_CS.h"
#include "Color_CS.h"
#include "ScreenShot_CS.h"
public ref class GTScreen_CS
{
public:
    // Properties
    property Vector2i_CS^ Size;
    property Vector2i_CS^ MaximizedWindowSize;

    // Methods
    ScreenShot_CS^ GetScreenshot();
    ScreenShot_CS^ GetScreenshotRect(Vector2i_CS^ position, Vector2i_CS^ size);
    Color_CS^ GetPixelColorAt(Vector2i_CS^ position);
    GTScreen_CS^ PixelAtShouldBeColor(Vector2i_CS^ position, Color_CS^ colorColor);
};

