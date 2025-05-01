#include "pch.h"
#include "GTKeyboad.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"

void GTKeyboard::PressKey(Key key) {
	SystemCallsFactory::GetSystemCalls()->PressKey(key);
}
void  GTKeyboard::ReleaseKey(Key key) {
	SystemCallsFactory::GetSystemCalls()->ReleaseKey(key);
}
void  GTKeyboard::ClickKey(Key key) {
	SystemCallsFactory::GetSystemCalls()->ClickKey(key);
}
void  GTKeyboard::Type(const std::string& text) {
	SystemCallsFactory::GetSystemCalls()->TypeText(text);
}