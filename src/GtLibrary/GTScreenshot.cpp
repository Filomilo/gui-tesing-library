#include "pch.h"
#include "GTScreenshot.h"
#include "GTScreenshot.h"
#include "Helpers.h"
#include "ImageComparerFactory.h"
#include "AbstractImageComparer.h"
#define STB_IMAGE_WRITE_IMPLEMENTATION

#include "stb_image_write.h"
#define STB_IMAGE_RESIZE_IMPLEMENTATION
#include "stb_image_resize.h"
#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"



int GTScreenshot::GetWidth() const {
    return  pixels.empty() ? 0 : pixels[0].size();
}

int GTScreenshot::GetHeight() const {
    return pixels.size();
}

Color GTScreenshot::GetPixelColorAt(const Vector2i& pos) const {
    return pixels[pos.y][pos.x];
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
    AbstractImageComparer*  comparer= ImageComparerFactory::getImageCompaprer();
    double rs = comparer->CompareImages((GTScreenshot*)this, filePathToComparingImage);
    delete comparer;
    return rs;
}

void GTScreenshot::SimmilarityBetweenImagesShouldBe(const std::string& imagePath, double similarity) const {
    Helpers::ensureTrue([&]()->bool {
        return this->CompareToImage(imagePath) > similarity;
        });
    
}


void GTScreenshot::resize(Vector2i newSize) {
    int oldWidth = pixels[0].size();
    int oldHeight = pixels.size();
    int channels = 3;

    std::vector<uint8_t> inputFlat(oldWidth * oldHeight * channels);
    std::vector<uint8_t> outputFlat(newSize.x * newSize.y * channels);


    for (int y = 0; y < oldHeight; ++y) {
        for (int x = 0; x < oldWidth; ++x) {
            Color& c = pixels[y][x];
            int idx = (y * oldWidth + x) * channels;
            inputFlat[idx + 0] = c.r;
            inputFlat[idx + 1] = c.g;
            inputFlat[idx + 2] = c.b;
        }
    }


    stbir_resize_uint8(
        inputFlat.data(), oldWidth, oldHeight, 0,
        outputFlat.data(), newSize.x, newSize.y, 0,
        channels
    );

    pixels.resize(newSize.y);
    for (int y = 0; y < newSize.y; ++y) {
        pixels[y].resize(newSize.x);
        for (int x = 0; x < newSize.x; ++x) {
            int idx = (y * newSize.x + x) * channels;
            pixels[y][x] = Color{
                outputFlat[idx + 0],
                outputFlat[idx + 1],
                outputFlat[idx + 2]
            };
        }
    }
}


GTScreenshot GTScreenshot::loadBMP(const std::string& filepath) {
    int width, height, channels;
    unsigned char* data = stbi_load(filepath.c_str(), &width, &height, &channels, 3); 
    if (!data) {
        throw std::runtime_error("Failed to load image");
    }

    std::vector<std::vector<Color>> pixels(height, std::vector<Color>(width));
    for (int y = 0; y < height; ++y) {
        for (int x = 0; x < width; ++x) {
            int idx = (y * width + x) * 3;
            pixels[y][x] = Color{
                data[idx + 0], 
                data[idx + 1], 
                data[idx + 2], 
            };
        }
    }

    stbi_image_free(data);
    return GTScreenshot( pixels) ;
}