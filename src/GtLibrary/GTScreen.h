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
    std::shared_ptr<GTScreenshot> GetScreenshot() const;
    std::shared_ptr<GTScreenshot> GetScreenshotRect(const Vector2i& position, const Vector2i& size) const;
    Color GetPixelColorAt(const Vector2i& position) const ;
    std::shared_ptr<GTScreen> PixelAtShouldBeColor(const Vector2i& position, const Color& color) ;
};

