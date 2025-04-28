#pragma once
#pragma once
#include <string>
#include "Key.h"

class GTKeyboard {
public:
     ~GTKeyboard() = default;

     void PressKey(Key key);
     void ReleaseKey(Key key);
     void ClickKey(Key key);
     void Type(const std::string& text);
};