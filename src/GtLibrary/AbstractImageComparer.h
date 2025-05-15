#pragma once
#include "GTScreen.h"
#include "GTScreenshot.h"
class AbstractImageComparer
{
public :
	virtual double CompareImages(GTScreenshot* scrren, std::string fileImageToCopamre) = 0;
};

