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
		instance->DefaultSleep();
		instance->type = IMMAGE_COMPARPER_TYPE::PIXELBYPIXEL;
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

void Configuration::setActioNDelay(long time) {
	this->defaultSleep = time;
}
long Configuration::getActionDelay() {
	return this->defaultSleep;
}

void Configuration::setDeafultActioNDelay() {
	this->defaultSleep = 1000;
}
IMMAGE_COMPARPER_TYPE Configuration::GetImageComparerType() {
	return this->type;
}
void Configuration::setImageCompareType(IMMAGE_COMPARPER_TYPE type) {
	this->type = type;
}