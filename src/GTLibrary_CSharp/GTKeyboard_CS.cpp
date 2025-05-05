#include "GTKeyboard_CS.h"
#include "Converters.h"

void GTKeyboard_CS::PressKey(Key_CS key) {
	native->PressKey(Converters::KeyCSToKEy(key));
}

void GTKeyboard_CS::ReleaseKey(Key_CS key) {
	native->ReleaseKey(Converters::KeyCSToKEy(key));
}

void GTKeyboard_CS::ClickKey(Key_CS key) {
	native->ClickKey(Converters::KeyCSToKEy(key));
}

void GTKeyboard_CS::Type(String^ text) {
	native->Type(Converters::ConvertStringToWStdString(text));
}
