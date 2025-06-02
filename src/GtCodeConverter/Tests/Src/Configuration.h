#pragma once
enum IMMAGE_COMPARPER_TYPE {
	PIXELBYPIXEL
};
class GtConfiguration
{
	long timeout=1000;
	long defaultSleep = 500;
	static GtConfiguration* instance;
	IMMAGE_COMPARPER_TYPE type;
public:

	static GtConfiguration* GetInstance();
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

