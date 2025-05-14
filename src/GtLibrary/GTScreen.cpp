#include "pch.h"
#include "GTScreen.h"
#include "SystemCallsFactory.h"
#include "SystemCalls.h"
#include "GTWindow.h"
#include "Helpers.h"

Vector2i GTScreen::GetSize() const {
	return SystemCallsFactory::GetSystemCalls()->GetScreenSize();
}

Vector2i GTScreen::GetMaximizedWindowSize() const {
	return SystemCallsFactory::GetSystemCalls()->GetMaximizedWindowSize();
}

GTScreenshot* GTScreen::GetScreenshot() const {

	return SystemCallsFactory::GetSystemCalls()->GetScreenshot(NULL, Vector2i(0,0),GetSize());
}

GTScreenshot* GTScreen::GetScreenshotRect(const Vector2i& position, const Vector2i& size) const {

	return SystemCallsFactory::GetSystemCalls()->GetScreenshot(NULL,position, size);
}

Color GTScreen::GetPixelColorAt(const Vector2i& position) const {
	return SystemCallsFactory::GetSystemCalls()->GetPixelColorAt(0,position);
}

void GTScreen::PixelAtShouldBeColor(const Vector2i& position, const Color& color) {
	Helpers::ensureTrue([&]() {
		Color pixelColor = this->GetPixelColorAt(position);
		return pixelColor.Equals(color);
		});
}
