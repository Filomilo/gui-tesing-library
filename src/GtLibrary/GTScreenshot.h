#pragma once
#pragma once
#include "Color.h"
#include "Vector2i.h"
#include <string>
#include <vector>
#include <memory>

class GTScreenshot {
private:
    std::vector<std::vector<Color>> pixels;

public:
    GTScreenshot(int width, int height);
    GTScreenshot(const std::string& bitmapFilePath);

    int GetWidth() const;
    int GetHeight() const;

    Color GetPixelColorAt(const Vector2i& pos) const;
    void SaveAsBitmap(const std::string& file) const;
    double CompareToImage(const std::string& filePathToComparingImage) const;
    void SimmilarityBetweenImagesShouldBe(const std::string& imagePath, double similarity) const;
};

