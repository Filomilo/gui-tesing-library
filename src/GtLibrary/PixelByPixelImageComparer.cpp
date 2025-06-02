#include "pch.h"
#include "PixelByPixelImageComparer.h"


double PixelByPixelImageComparer::CompareImages(GTScreenshot* scrren, std::string fileImageToCopamre)
{
    int width = scrren->GetWidth();
    int height = scrren->GetHeight();

    GTScreenshot toCompareTo = GTScreenshot::loadBMP(fileImageToCopamre);
    toCompareTo.resize(Vector2i(width, height));
    long amountOFPixels = width * height;
    long pixelsMatch = 0;
    for (size_t i = 0; i < width; i++)
    {
        for (size_t j = 0; j < height; j++)
        {
            Color pixelOrigin = scrren->GetPixelColorAt(Vector2i(i, j));
            Color pixelTocompare = toCompareTo.GetPixelColorAt(Vector2i(i, j));
            if (pixelOrigin.Equals(pixelTocompare))
            {
                pixelsMatch++;
            }
            else {
                //printf("Tset");
            }
        }
    }
    return ((double)pixelsMatch) / (amountOFPixels);
}