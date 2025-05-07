#include "pch.h"
#include "GTKeyboad.h"
#include "SystemCalls.h"
#include "Configuration.h"
#include "SystemCallsFactory.h"

void GTKeyboard::PressKey(GTKey key) {
	SystemCallsFactory::GetSystemCalls()->PressKey(key);
	Configuration::GetInstance()-> DefaultSleep();
}
void  GTKeyboard::ReleaseKey(GTKey key) {
	SystemCallsFactory::GetSystemCalls()->ReleaseKey(key);
	Configuration::GetInstance()->DefaultSleep();
}
void  GTKeyboard::ClickKey(GTKey key) {
	SystemCallsFactory::GetSystemCalls()->ClickKey(key);
	Configuration::GetInstance()->DefaultSleep();
}
void  GTKeyboard::Type(const std::wstring& text) {
	SystemCallsFactory::GetSystemCalls()->TypeText(text);
	Configuration::GetInstance()->DefaultSleep();
}