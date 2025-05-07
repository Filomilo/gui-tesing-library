#include "pch.h"
#include "GTScreenshot.h"
#include "GTScreenshot.h"

#define STB_IMAGE_WRITE_IMPLEMENTATION

#include "stb_image_write.h"


GTScreenshot::GTScreenshot(const std::string& bitmapFilePath) {
}

int GTScreenshot::GetWidth() const {
    return  pixels.empty() ? 0 : pixels[0].size();
}

int GTScreenshot::GetHeight() const {
    return pixels.size();
}

Color GTScreenshot::GetPixelColorAt(const Vector2i& pos) const {
    return pixels[pos.x][pos.y];
}

void GTScreenshot::SaveAsBitmap(const std::string& file) const {
    int height = pixels.size();
    int width = pixels[0].size();
    std::vector<uint8_t> data(width * height * 3);

    for (int y = 0; y < height; ++y) {
        for (int x = 0; x < width; ++x) {
            int idx = ((height - 1 - y) * width + x) * 3;
            data[idx + 0] = pixels[height-y -1][x].r;
            data[idx + 1] = pixels[height - y-1 ][x].g;
            data[idx + 2] = pixels[height - y-1][x].b;
        }
    }
    stbi_write_bmp(file.c_str(), width, height, 3, data.data());
}

double GTScreenshot::CompareToImage(const std::string& filePathToComparingImage) const {
    return 0.0;
}

void GTScreenshot::SimmilarityBetweenImagesShouldBe(const std::string& imagePath, double similarity) const {
}
