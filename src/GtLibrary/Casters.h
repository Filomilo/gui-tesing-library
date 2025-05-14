#pragma once
#include <Windows.h>
#include "Key.h"
class Casters
{
public:
	static HANDLE intToHadnle(int val)
	{
		HANDLE h = reinterpret_cast<HANDLE>(static_cast<uintptr_t>(val));
		return h;
	}
	static HWND intToHWND(int val)
	{
		HWND hWnd = reinterpret_cast<HWND>(static_cast<uintptr_t>(val));	
		return hWnd;
	}

	static int HandleToInt(HANDLE h)
	{
		return reinterpret_cast<intptr_t>(h); ;
	}


    static WORD GTKeyToVK(GTKey key) {
        switch (key) {
        case GTKey::RSHIFT:     return VK_RSHIFT;
        case GTKey::LSHIFT:     return VK_LSHIFT;
        case GTKey::RCONTROL:   return VK_RCONTROL;
        case GTKey::LCONTROL:   return VK_LCONTROL;
        case GTKey::CONTROL:    return VK_CONTROL;
        case GTKey::SHIFT:      return VK_SHIFT;

        case GTKey::NUMLOCK:    return VK_NUMLOCK;
        case GTKey::F1:         return VK_F1;
        case GTKey::F2:         return VK_F2;
        case GTKey::F3:         return VK_F3;
        case GTKey::F4:         return VK_F4;
        case GTKey::F5:         return VK_F5;
        case GTKey::F6:         return VK_F6;
        case GTKey::F7:         return VK_F7;
        case GTKey::F8:         return VK_F8;
        case GTKey::F9:         return VK_F9;
        case GTKey::F10:        return VK_F10;
        case GTKey::F11:        return VK_F11;
        case GTKey::F12:        return VK_F12;
        case GTKey::F13:        return VK_F13;
        case GTKey::F14:        return VK_F14;
        case GTKey::F15:        return VK_F15;
        case GTKey::F16:        return VK_F16;
        case GTKey::F17:        return VK_F17;
        case GTKey::F18:        return VK_F18;
        case GTKey::F19:        return VK_F19;
        case GTKey::F20:        return VK_F20;
        case GTKey::F21:        return VK_F21;
        case GTKey::F22:        return VK_F22;
        case GTKey::F23:        return VK_F23;
        case GTKey::F24:        return VK_F24;

        case GTKey::DIVIDE:     return VK_DIVIDE;
        case GTKey::DECIMAL:    return VK_DECIMAL;
        case GTKey::SUBTRACT:   return VK_SUBTRACT;
        case GTKey::SEPARATOR:  return VK_SEPARATOR;
        case GTKey::ADD:        return VK_ADD;
        case GTKey::MULTIPLY:   return VK_MULTIPLY;

        case GTKey::NUMPAD_0:   return VK_NUMPAD0;
        case GTKey::NUMPAD_1:   return VK_NUMPAD1;
        case GTKey::NUMPAD_2:   return VK_NUMPAD2;
        case GTKey::NUMPAD_3:   return VK_NUMPAD3;
        case GTKey::NUMPAD_4:   return VK_NUMPAD4;
        case GTKey::NUMPAD_5:   return VK_NUMPAD5;
        case GTKey::NUMPAD_6:   return VK_NUMPAD6;
        case GTKey::NUMPAD_7:   return VK_NUMPAD7;
        case GTKey::NUMPAD_8:   return VK_NUMPAD8;
        case GTKey::NUMPAD_9:   return VK_NUMPAD9;

        case GTKey::KEY_0:      return 0x30;
        case GTKey::KEY_1:      return 0x31;
        case GTKey::KEY_2:      return 0x32;
        case GTKey::KEY_3:      return 0x33;
        case GTKey::KEY_4:      return 0x34;
        case GTKey::KEY_5:      return 0x35;
        case GTKey::KEY_6:      return 0x36;
        case GTKey::KEY_7:      return 0x37;
        case GTKey::KEY_8:      return 0x38;
        case GTKey::KEY_9:      return 0x39;

        case GTKey::KEY_A:      return 'A';
        case GTKey::KEY_B:      return 'B';
        case GTKey::KEY_C:      return 'C';
        case GTKey::KEY_D:      return 'D';
        case GTKey::KEY_E:      return 'E';
        case GTKey::KEY_F:      return 'F';
        case GTKey::KEY_G:      return 'G';
        case GTKey::KEY_H:      return 'H';
        case GTKey::KEY_I:      return 'I';
        case GTKey::KEY_J:      return 'J';
        case GTKey::KEY_K:      return 'K';
        case GTKey::KEY_L:      return 'L';
        case GTKey::KEY_M:      return 'M';
        case GTKey::KEY_N:      return 'N';
        case GTKey::KEY_O:      return 'O';
        case GTKey::KEY_P:      return 'P';
        case GTKey::KEY_Q:      return 'Q';
        case GTKey::KEY_R:      return 'R';
        case GTKey::KEY_S:      return 'S';
        case GTKey::KEY_T:      return 'T';
        case GTKey::KEY_U:      return 'U';
        case GTKey::KEY_V:      return 'V';
        case GTKey::KEY_W:      return 'W';
        case GTKey::KEY_X:      return 'X';
        case GTKey::KEY_Y:      return 'Y';
        case GTKey::KEY_Z:      return 'Z';

        case GTKey::KEY_DELETE: return VK_DELETE;
        case GTKey::INSERT:     return VK_INSERT;
        case GTKey::PRINT:      return VK_PRINT;
        case GTKey::SELECT:     return VK_SELECT;
        case GTKey::DOWN:       return VK_DOWN;
        case GTKey::UP:         return VK_UP;
        case GTKey::LEFT:       return VK_LEFT;
        case GTKey::RIGHT:      return VK_RIGHT;
        case GTKey::HOME:       return VK_HOME;
        case GTKey::END:        return VK_END;
        case GTKey::SPACE:      return VK_SPACE;
        case GTKey::ESCAPE:     return VK_ESCAPE;
        case GTKey::PAUSE:      return VK_PAUSE;
        case GTKey::MENU:       return VK_MENU;
        case GTKey::RETURN:     return VK_RETURN;
        case GTKey::CLEAR:      return VK_CLEAR;
        case GTKey::TAB:        return VK_TAB;

        default:                return 0;  
        }
    }
	
};

