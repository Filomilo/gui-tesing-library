#pragma once
#pragma once
#include "Vector2i.h"
#include "Color.h"
#include "GTScreenshot.h"
#include <memory>

class GTScreen {
public:
    GTScreen() = default;

    Vector2i GetSize() const;
    Vector2i GetMaximizedWindowSize() const ;
    GTScreenshot GetScreenshot() const;
    GTScreenshot GetScreenshotRect(const Vector2i& position, const Vector2i& size) const;
    Color GetPixelColorAt(const Vector2i& position) const ;
    void PixelAtShouldBeColor(const Vector2i& position, const Color& color) ;
};

