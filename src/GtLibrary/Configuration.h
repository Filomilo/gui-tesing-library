#pragma once
enum IMMAGE_COMPARPER_TYPE {
	PIXELBYPIXEL
};
class Configuration
{
	long timeout=1000;
	long defaultSleep = 500;
	static Configuration* instance;
	IMMAGE_COMPARPER_TYPE type;
public:

	static Configuration* GetInstance();
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

