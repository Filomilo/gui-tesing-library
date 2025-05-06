#pragma once
class Configuration
{
	long timeout=1000;
	long defaultSleep = 2000;
	static Configuration* instance;
public:
	static Configuration* GetInstance();
	void SetTimeout(long newTimeout);
	long GetTimeout();
	void SetDefaultTimeout();
	void DefaultSleep();


};

