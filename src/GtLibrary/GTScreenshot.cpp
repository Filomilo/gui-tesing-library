#include "pch.h"
#include "GTScreenshot.h"
#include "GTScreenshot.h"

GTScreenshot::GTScreenshot(int width, int height) : pixels(width, std::vector<Color>(height)) {
}

GTScreenshot::GTScreenshot(const std::string& bitmapFilePath) {
}

int GTScreenshot::GetWidth() const {
    return pixels.size();
}

int GTScreenshot::GetHeight() const {
    return pixels.empty() ? 0 : pixels[0].size();
}

Color GTScreenshot::GetPixelColorAt(const Vector2i& pos) const {
    return pixels[pos.x][pos.y];
}

void GTScreenshot::SaveAsBitmap(const std::string& file) const {
}

double GTScreenshot::CompareToImage(const std::string& filePathToComparingImage) const {
    return 0.0;
}

void GTScreenshot::SimmilarityBetweenImagesShouldBe(const std::string& imagePath, double similarity) const {
}
