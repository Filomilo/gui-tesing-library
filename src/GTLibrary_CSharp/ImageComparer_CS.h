#pragma once


using namespace System;
using namespace System::IO;

public ref class ImageComparer_CS
{
public:
    double CompareImages(Stream^ image1, Stream^ image2);
};