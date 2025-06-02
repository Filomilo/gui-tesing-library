#include "pch.h"
#include "Configuration.h"
#include <chrono>
#include <thread>

GtConfiguration* GtConfiguration::instance = nullptr;
GtConfiguration* GtConfiguration::GetInstance()
{
	if (instance == nullptr)
	{
		instance = new GtConfiguration();
		instance->SetDefaultTimeout();
		instance->DefaultSleep();
		instance->type = IMMAGE_COMPARPER_TYPE::PIXELBYPIXEL;
	}
	return instance;
}

void GtConfiguration::SetTimeout(long newTimeout)
{
	timeout = newTimeout;
}
long GtConfiguration::GetTimeout()
{
	return timeout;
}
void GtConfiguration::SetDefaultTimeout()
{
	timeout = 10000;
}

void GtConfiguration::DefaultSleep() {
	std::this_thread::sleep_for(std::chrono::milliseconds(this->defaultSleep));
}

void GtConfiguration::setActioNDelay(long time) {
	this->defaultSleep = time;
}
long GtConfiguration::getActionDelay() {
	return this->defaultSleep;
}

void GtConfiguration::setDeafultActioNDelay() {
	this->defaultSleep = 1000;
}
IMMAGE_COMPARPER_TYPE GtConfiguration::GetImageComparerType() {
	return this->type;
}
void GtConfiguration::setImageCompareType(IMMAGE_COMPARPER_TYPE type) {
	this->type = type;
}