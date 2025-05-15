#pragma once
#include "AbstractImageComparer.h"
class PixelByPixelImageComparer: public AbstractImageComparer
{
public: 
	 double CompareImages(GTScreenshot* scrren, std::string fileImageToCopamre) override;
};

