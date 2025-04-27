#include "pch.h"
#include "GTScreen.h"

Vector2i GTScreen::GetSize() const {
    return Vector2i();
}

Vector2i GTScreen::GetMaximizedWindowSize() const {
    return Vector2i();
}

std::shared_ptr<GTScreenshot> GTScreen::GetScreenshot() const {
    return std::make_shared<GTScreenshot>(0, 0);
}

std::shared_ptr<GTScreenshot> GTScreen::GetScreenshotRect(const Vector2i& position, const Vector2i& size) const {
    return std::make_shared<GTScreenshot>(0, 0);
}

Color GTScreen::GetPixelColorAt(const Vector2i& position) const {
    return Color();
}

std::shared_ptr<GTScreen> GTScreen::PixelAtShouldBeColor(const Vector2i& position, const Color& color) {
    return std::make_shared<GTScreen>();
}
