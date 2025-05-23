#pragma once
#include "AbstractImageComparer.h"
#include "PixelByPixelImageComparer.h"
#include "Configuration.h"
class ImageComparerFactory
{
public:
	

	static AbstractImageComparer* getImageCompaprer() {
		switch (GtConfiguration::GetInstance()-> GetImageComparerType())
		{
		case IMMAGE_COMPARPER_TYPE::PIXELBYPIXEL:
			return new PixelByPixelImageComparer();
		default:
			break;
		}
	}

};

