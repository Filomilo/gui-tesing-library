#include "pch.h"
#include "Configuration.h"
#include <chrono>
#include <thread>

Configuration* Configuration::instance = nullptr;
Configuration* Configuration::GetInstance()
{
	if (instance == nullptr)
	{
		instance = new Configuration();
		instance->SetDefaultTimeout();
	}
	return instance;
}

void Configuration::SetTimeout(long newTimeout)
{
	timeout = newTimeout;
}
long Configuration::GetTimeout()
{
	return timeout;
}
void Configuration::SetDefaultTimeout()
{
	timeout = 1000;
}

void Configuration::DefaultSleep() {
	std::this_thread::sleep_for(std::chrono::milliseconds(this->defaultSleep)); 
}