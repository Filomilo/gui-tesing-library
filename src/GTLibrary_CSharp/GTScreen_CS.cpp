#include "GTScreen_CS.h"
#include "Converters.h"

Vector2i_CS^ GTScreen_CS::GetSize()
{
    return Converters::Vector2iToVector2iCS(native->GetSize());
}
Vector2i_CS^ GTScreen_CS::GetMaximizedWindowSize()
{
    return Converters::Vector2iToVector2iCS(native->GetMaximizedWindowSize());
}

ScreenShot_CS^ GTScreen_CS::GetScreenshot()
{
    return Converters::ScreenShotTOScreenShotCs(native->GetScreenshot());
}

ScreenShot_CS^ GTScreen_CS::GetScreenshotRect(Vector2i_CS^ position, Vector2i_CS^ size)
{
    return Converters::ScreenShotTOScreenShotCs(native->GetScreenshotRect(Converters::Vector2iCSToVector2i(position), Converters::Vector2iCSToVector2i(size)));
}

Color_CS^ GTScreen_CS::GetPixelColorAt(Vector2i_CS^ position)
{
    return Converters::ColorToColorCS(native->GetPixelColorAt(Converters::Vector2iCSToVector2i(position)));
}

void GTScreen_CS::PixelAtShouldBeColor(Vector2i_CS^ position, Color_CS^ colorColor)
{
    native->PixelAtShouldBeColor(Converters::Vector2iCSToVector2i(position), Converters::ColorCSToColor(colorColor));
}
