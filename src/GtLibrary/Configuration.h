#pragma once
class Configuration
{
	static long timeout;

	static Configuration* instance;
public:
	static Configuration* GetInstance()
	{
		if (instance == nullptr)
		{
			instance = new Configuration();
			instance->SetDefaultTimeout();
		}
		return instance;
	}
	static void SetTimeout(long newTimeout)
	{
		timeout = newTimeout;
	}
	static long GetTimeout()
	{
		return timeout;
	}
	static void SetDefaultTimeout()
	{
		timeout = 1000;
	}



};

