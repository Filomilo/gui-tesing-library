#pragma once
using namespace System;
#include <string>
#include "Key_CS.h"
#include <memory>
#include "../GtLibrary/Key.h"
#include "../GtLibrary/GTWindow.h"
#include "Vector2f_CS.h"
#include "GTWindow_CS.h"
#include "../GtLibrary/GTScreenshot.h"
#include <msclr/marshal_cppstd.h>
#include <msclr/marshal.h>
using namespace msclr::interop;
ref class Converters
{
public:
    static std::string ConvertStringToStdString(System::String^ managedString) {
  
        return msclr::interop::marshal_as<std::string>(managedString);
    }
    static String^ ConvertStdStringToString(std::string string) {
        return gcnew System::String(string.c_str());
    }

    static String^ ConvertWStdStringToString(std::wstring string)
    {
        return marshal_as<String^>(string);
    }
    static std::wstring ConvertStringToWStdString(System::String^ managedString) {
        return marshal_as<std::wstring>(managedString);
    }

    static GTKey KeyCSToKEy(Key_CS key_Cs)
    {
        switch (key_Cs) {
        case Key_CS::RSHIFT:     return GTKey::RSHIFT;
        case Key_CS::LCONTROL:   return GTKey::LCONTROL;
        case Key_CS::RCONTROL:   return GTKey::RCONTROL;
        case Key_CS::LSHIFT:     return GTKey::LSHIFT;
        case Key_CS::NUMLOCK:    return GTKey::NUMLOCK;
        case Key_CS::F24:        return GTKey::F24;
        case Key_CS::BACK:       return GTKey::BACK;
        case Key_CS::F23:        return GTKey::F23;
        case Key_CS::F22:        return GTKey::F22;
        case Key_CS::F21:        return GTKey::F21;
        case Key_CS::F20:        return GTKey::F20;
        case Key_CS::F19:        return GTKey::F19;
        case Key_CS::F18:        return GTKey::F18;
        case Key_CS::F17:        return GTKey::F17;
        case Key_CS::F16:        return GTKey::F16;
        case Key_CS::F15:        return GTKey::F15;
        case Key_CS::F14:        return GTKey::F14;
        case Key_CS::F13:        return GTKey::F13;
        case Key_CS::F12:        return GTKey::F12;
        case Key_CS::F11:        return GTKey::F11;
        case Key_CS::F10:        return GTKey::F10;
        case Key_CS::F9:         return GTKey::F9;
        case Key_CS::F8:         return GTKey::F8;
        case Key_CS::F7:         return GTKey::F7;
        case Key_CS::F6:         return GTKey::F6;
        case Key_CS::F5:         return GTKey::F5;
        case Key_CS::F4:         return GTKey::F4;
        case Key_CS::F3:         return GTKey::F3;
        case Key_CS::F2:         return GTKey::F2;
        case Key_CS::F1:         return GTKey::F1;
        case Key_CS::DIVIDE:     return GTKey::DIVIDE;
        case Key_CS::DECIMAL:    return GTKey::DECIMAL;
        case Key_CS::SUBTRACT:   return GTKey::SUBTRACT;
        case Key_CS::SEPARATOR:  return GTKey::SEPARATOR;
        case Key_CS::ADD:        return GTKey::ADD;
        case Key_CS::MULTIPLY:   return GTKey::MULTIPLY;
        case Key_CS::NUMPAD_9:   return GTKey::NUMPAD_9;
        case Key_CS::NUMPAD_8:   return GTKey::NUMPAD_8;
        case Key_CS::NUMPAD_7:   return GTKey::NUMPAD_7;
        case Key_CS::NUMPAD_5:   return GTKey::NUMPAD_5;
        case Key_CS::NUMPAD_6:   return GTKey::NUMPAD_6;
        case Key_CS::NUMPAD_4:   return GTKey::NUMPAD_4;
        case Key_CS::NUMPAD_3:   return GTKey::NUMPAD_3;
        case Key_CS::NUMPAD_2:   return GTKey::NUMPAD_2;
        case Key_CS::NUMPAD_1:   return GTKey::NUMPAD_1;
        case Key_CS::NUMPAD_0:   return GTKey::NUMPAD_0;
        case Key_CS::KEY_Z:      return GTKey::KEY_Z;
        case Key_CS::KEY_Y:      return GTKey::KEY_Y;
        case Key_CS::KEY_X:      return GTKey::KEY_X;
        case Key_CS::KEY_W:      return GTKey::KEY_W;
        case Key_CS::KEY_V:      return GTKey::KEY_V;
        case Key_CS::KEY_U:      return GTKey::KEY_U;
        case Key_CS::KEY_T:      return GTKey::KEY_T;
        case Key_CS::KEY_S:      return GTKey::KEY_S;
        case Key_CS::KEY_R:      return GTKey::KEY_R;
        case Key_CS::KEY_Q:      return GTKey::KEY_Q;
        case Key_CS::KEY_O:      return GTKey::KEY_O;
        case Key_CS::KEY_P:      return GTKey::KEY_P;
        case Key_CS::KEY_N:      return GTKey::KEY_N;
        case Key_CS::KEY_M:      return GTKey::KEY_M;
        case Key_CS::KEY_L:      return GTKey::KEY_L;
        case Key_CS::KEY_K:      return GTKey::KEY_K;
        case Key_CS::KEY_J:      return GTKey::KEY_J;
        case Key_CS::KEY_I:      return GTKey::KEY_I;
        case Key_CS::KEY_H:      return GTKey::KEY_H;
        case Key_CS::KEY_G:      return GTKey::KEY_G;
        case Key_CS::KEY_F:      return GTKey::KEY_F;
        case Key_CS::KEY_E:      return GTKey::KEY_E;
        case Key_CS::KEY_D:      return GTKey::KEY_D;
        case Key_CS::KEY_C:      return GTKey::KEY_C;
        case Key_CS::KEY_B:      return GTKey::KEY_B;
        case Key_CS::KEY_A:      return GTKey::KEY_A;
        case Key_CS::KEY_9:      return GTKey::KEY_9;
        case Key_CS::KEY_8:      return GTKey::KEY_8;
        case Key_CS::KEY_7:      return GTKey::KEY_7;
        case Key_CS::KEY_6:      return GTKey::KEY_6;
        case Key_CS::KEY_5:      return GTKey::KEY_5;
        case Key_CS::KEY_4:      return GTKey::KEY_4;
        case Key_CS::KEY_3:      return GTKey::KEY_3;
        case Key_CS::KEY_2:      return GTKey::KEY_2;
        case Key_CS::KEY_1:      return GTKey::KEY_1;
        case Key_CS::KEY_0:      return GTKey::KEY_0;
        case Key_CS::KEY_DELETE: return GTKey::KEY_DELETE;
        case Key_CS::INSERT:     return GTKey::INSERT;
        case Key_CS::PRINT:      return GTKey::PRINT;
        case Key_CS::SELECT:     return GTKey::SELECT;
        case Key_CS::DOWN:       return GTKey::DOWN;
        case Key_CS::RIGHT:      return GTKey::RIGHT;
        case Key_CS::UP:         return GTKey::UP;
        case Key_CS::LEFT:       return GTKey::LEFT;
        case Key_CS::HOME:       return GTKey::HOME;
        case Key_CS::END:        return GTKey::END;
        case Key_CS::SPACE:      return GTKey::SPACE;
        case Key_CS::ESCAPE:     return GTKey::ESCAPE;
        case Key_CS::PAUSE:      return GTKey::PAUSE;
        case Key_CS::MENU:       return GTKey::MENU;
        case Key_CS::CONTROL:    return GTKey::CONTROL;
        case Key_CS::SHIFT:      return GTKey::SHIFT;
        case Key_CS::RETURN:     return GTKey::RETURN;
        case Key_CS::CLEAR:      return GTKey::CLEAR;
        case Key_CS::TAB:        return GTKey::TAB;
        default: throw std::invalid_argument("Unknown Key_CS value");
        }
    }

    static Vector2i Vector2iCSToVector2i(Vector2i_CS^ vec)
    {
        return Vector2i(vec->X, vec->Y);
    }
    static Vector2f Vector2fCSToVector2f(Vector2f_CS^ vec)
    {
        return Vector2f(vec->x, vec->y);
    }

    static Vector2i_CS^ Vector2iToVector2iCS(Vector2i vec)
    {
        return gcnew Vector2i_CS(vec.x, vec.y);
    }
    static Vector2f_CS^ Vector2fToVector2fCS(Vector2f vec)
    {
        return gcnew Vector2f_CS(vec.x, vec.y);
    }


    static std::shared_ptr<GTWindow> WidnowCsToWindow(GTWindow_CS^ win)
    {
        return std::make_shared<GTWindow>(win->GetNative()->GetHandle());
    }

    static ScreenShot_CS^ ScreenShotTOScreenShotCs(GTScreenshot*  screen)
    {
        return gcnew ScreenShot_CS(screen);
    }


    static Color_CS^ ColorToColorCS(Color col)
    {
        return gcnew Color_CS(col.r, col.g, col.b);

    }
    static Color ColorCSToColor(Color_CS^ col)
    {
        return Color(col->r, col->g, col->b);

    }

    static GTProcess_CS^ ProcessToProcessCS(GTProcess* proc)
    {
        return gcnew GTProcess_CS(proc);
    }

};