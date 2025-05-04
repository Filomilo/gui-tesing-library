#include "pch.h"
#include "GTKeyboad.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"

void GTKeyboard::PressKey(GTKey key) {
	SystemCallsFactory::GetSystemCalls()->PressKey(key);
}
void  GTKeyboard::ReleaseKey(GTKey key) {
	SystemCallsFactory::GetSystemCalls()->ReleaseKey(key);
}
void  GTKeyboard::ClickKey(GTKey key) {
	SystemCallsFactory::GetSystemCalls()->ClickKey(key);
}
void  GTKeyboard::Type(const std::wstring& text) {
	SystemCallsFactory::GetSystemCalls()->TypeText(text);
}