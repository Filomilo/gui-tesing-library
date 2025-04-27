#include "pch.h"
#include "GTKeyboad.h"

IGTKeyboard* IGTKeyboard::PressKey(Key key) {
    return this;
}

IGTKeyboard* IGTKeyboard::ReleaseKey(Key key) {
    return this;
}

IGTKeyboard* IGTKeyboard::ClickKey(Key key) {
    return this;
}

IGTKeyboard* IGTKeyboard::Type(const std::string& text) {
    return this;
}