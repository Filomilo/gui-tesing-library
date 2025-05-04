#pragma once
#pragma once
#include <string>
#include "Key.h"

class GTKeyboard {
public:
     ~GTKeyboard() = default;

     void PressKey(GTKey key);
     void ReleaseKey(GTKey key);
     void ClickKey(GTKey key);
     void Type(const std::wstring& text);
};