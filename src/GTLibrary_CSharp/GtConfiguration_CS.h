#pragma once
using namespace System;
#include "../GtLibrary/Configuration.h"
ref class GtConfiguration_CS
{
public:


	void SetTimeout(long newTimeout);
	long GetTimeout();
	void SetDefaultTimeout();
	void DefaultSleep();
	void setActioNDelay(long time);
	void setDeafultActioNDelay();
	long getActionDelay();
	IMMAGE_COMPARPER_TYPE GetImageComparerType();
	void setImageCompareType(IMMAGE_COMPARPER_TYPE type);
};

