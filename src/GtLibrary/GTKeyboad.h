#pragma once
#pragma once
#include <string>
#include "Key.h"

class IGTKeyboard {
public:
    virtual ~IGTKeyboard() = default;

    virtual IGTKeyboard* PressKey(Key key) = 0;
    virtual IGTKeyboard* ReleaseKey(Key key) = 0;
    virtual IGTKeyboard* ClickKey(Key key) = 0;
    virtual IGTKeyboard* Type(const std::string& text) = 0;
};