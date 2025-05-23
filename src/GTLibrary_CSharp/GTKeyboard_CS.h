#pragma once
using namespace System;
#include "Key_CS.h"
#include <memory>
#include <vector>
#include <string>
#include "GTProcess_CS.h"
#include "GTWindow_CS.h"
#include "Vector2i_CS.h"
#include "GTSystemVersion_CS.h"
#include "../GtLibrary/GTKeyboad.h"
#include "../GtLibrary/GTSystem.h"

public ref class GTKeyboard_CS
{
private:
    static GTKeyboard* native=new GTKeyboard();
    public:
  
        ~GTKeyboard_CS() {
            delete native;
        }

       
        void PressKey(Key_CS key);
        void ReleaseKey(Key_CS key);
        void ClickKey(Key_CS key);
        void Type(String^ text);
    
};

