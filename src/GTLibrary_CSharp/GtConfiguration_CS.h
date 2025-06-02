#pragma once
using namespace System;
#include "../GtLibrary/Configuration.h"

public enum class CS_IMAGE_COMPARER_TYPE
{
	PIXEL_BY_PIXEL
};

public ref class GtConfiguration_CS
{
public:


	void SetTimeout(long newTimeout);
	long GetTimeout();
	void SetDefaultTimeout();
	void DefaultSleep();
	void setActioNDelay(long time);
	void setDeafultActioNDelay();
	long getActionDelay();
	CS_IMAGE_COMPARER_TYPE GetImageComparerType();
	void setImageCompareType(CS_IMAGE_COMPARER_TYPE type);
};

