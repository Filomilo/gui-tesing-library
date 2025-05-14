#pragma once
#pragma once
#define _CRT_SECURE_NO_WARNINGS

#include "Color.h"
#include "Vector2i.h"
#include <string>
#include <vector>
#include <memory>

class GTScreenshot {
private:
    std::vector<std::vector<Color>> pixels;

public:
    void resize(Vector2i newSize);
    GTScreenshot()=default;
     GTScreenshot(std::vector<std::vector<Color>> pixels) {
         this->pixels = pixels;
     }

    int GetWidth() const;
    int GetHeight() const;

    Color GetPixelColorAt(const Vector2i& pos) const;
    void SaveAsBitmap(const std::string& file) const;
    double CompareToImage(const std::string& filePathToComparingImage) const;
    void SimmilarityBetweenImagesShouldBe(const std::string& imagePath, double similarity) const;
    static GTScreenshot loadBMP(const std::string& filepath);

};

