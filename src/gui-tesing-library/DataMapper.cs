﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Models;
using WindowsInput.Native;

namespace gui_tesing_library
{
    public static class DataMapper
    {
        public static VirtualKeyCode KeyToVirtualKey(Key key)
        {
            switch (key)
            {
                case Key.BACK:
                    return VirtualKeyCode.BACK;
                case Key.TAB:
                    return VirtualKeyCode.TAB;
                case Key.CLEAR:
                    return VirtualKeyCode.CLEAR;
                case Key.RETURN:
                    return VirtualKeyCode.RETURN;
                case Key.SHIFT:
                    return VirtualKeyCode.SHIFT;
                case Key.CONTROL:
                    return VirtualKeyCode.CONTROL;
                case Key.MENU:
                    return VirtualKeyCode.MENU;
                case Key.PAUSE:
                    return VirtualKeyCode.PAUSE;
                case Key.ESCAPE:
                    return VirtualKeyCode.ESCAPE;
                case Key.SPACE:
                    return VirtualKeyCode.SPACE;
                case Key.END:
                    return VirtualKeyCode.END;
                case Key.HOME:
                    return VirtualKeyCode.HOME;
                case Key.LEFT:
                    return VirtualKeyCode.LEFT;
                case Key.UP:
                    return VirtualKeyCode.UP;
                case Key.RIGHT:
                    return VirtualKeyCode.RIGHT;
                case Key.DOWN:
                    return VirtualKeyCode.DOWN;
                case Key.SELECT:
                    return VirtualKeyCode.SELECT;
                case Key.PRINT:
                    return VirtualKeyCode.PRINT;
                case Key.INSERT:
                    return VirtualKeyCode.INSERT;
                case Key.DELETE:
                    return VirtualKeyCode.DELETE;
                case Key.KEY_0:
                    return VirtualKeyCode.VK_0;
                case Key.KEY_1:
                    return VirtualKeyCode.VK_1;
                case Key.KEY_2:
                    return VirtualKeyCode.VK_2;
                case Key.KEY_3:
                    return VirtualKeyCode.VK_3;
                case Key.KEY_4:
                    return VirtualKeyCode.VK_4;
                case Key.KEY_5:
                    return VirtualKeyCode.VK_5;
                case Key.KEY_6:
                    return VirtualKeyCode.VK_6;
                case Key.KEY_7:
                    return VirtualKeyCode.VK_7;
                case Key.KEY_8:
                    return VirtualKeyCode.VK_8;
                case Key.KEY_9:
                    return VirtualKeyCode.VK_9;
                case Key.KEY_A:
                    return VirtualKeyCode.VK_A;
                case Key.KEY_B:
                    return VirtualKeyCode.VK_B;
                case Key.KEY_C:
                    return VirtualKeyCode.VK_C;
                case Key.KEY_D:
                    return VirtualKeyCode.VK_D;
                case Key.KEY_E:
                    return VirtualKeyCode.VK_E;
                case Key.KEY_F:
                    return VirtualKeyCode.VK_F;
                case Key.KEY_G:
                    return VirtualKeyCode.VK_G;
                case Key.KEY_H:
                    return VirtualKeyCode.VK_H;
                case Key.KEY_I:
                    return VirtualKeyCode.VK_I;
                case Key.KEY_J:
                    return VirtualKeyCode.VK_J;
                case Key.KEY_K:
                    return VirtualKeyCode.VK_K;
                case Key.KEY_L:
                    return VirtualKeyCode.VK_L;
                case Key.KEY_M:
                    return VirtualKeyCode.VK_M;
                case Key.KEY_N:
                    return VirtualKeyCode.VK_N;
                case Key.KEY_O:
                    return VirtualKeyCode.VK_O;
                case Key.KEY_P:
                    return VirtualKeyCode.VK_P;
                case Key.KEY_Q:
                    return VirtualKeyCode.VK_Q;
                case Key.KEY_R:
                    return VirtualKeyCode.VK_R;
                case Key.KEY_S:
                    return VirtualKeyCode.VK_S;
                case Key.KEY_T:
                    return VirtualKeyCode.VK_T;
                case Key.KEY_U:
                    return VirtualKeyCode.VK_U;
                case Key.KEY_V:
                    return VirtualKeyCode.VK_V;
                case Key.KEY_W:
                    return VirtualKeyCode.VK_W;
                case Key.KEY_X:
                    return VirtualKeyCode.VK_X;
                case Key.KEY_Y:
                    return VirtualKeyCode.VK_Y;
                case Key.KEY_Z:
                    return VirtualKeyCode.VK_Z;
                case Key.NUMPAD_0:
                    return VirtualKeyCode.NUMPAD0;
                case Key.NUMPAD_1:
                    return VirtualKeyCode.NUMPAD1;
                case Key.NUMPAD_2:
                    return VirtualKeyCode.NUMPAD2;
                case Key.NUMPAD_3:
                    return VirtualKeyCode.NUMPAD3;
                case Key.NUMPAD_4:
                    return VirtualKeyCode.NUMPAD4;
                case Key.NUMPAD_5:
                    return VirtualKeyCode.NUMPAD5;
                case Key.NUMPAD_6:
                    return VirtualKeyCode.NUMPAD6;
                case Key.NUMPAD_7:
                    return VirtualKeyCode.NUMPAD7;
                case Key.NUMPAD_8:
                    return VirtualKeyCode.NUMPAD8;
                case Key.NUMPAD_9:
                    return VirtualKeyCode.NUMPAD9;
                case Key.MULTIPLY:
                    return VirtualKeyCode.MULTIPLY;
                case Key.ADD:
                    return VirtualKeyCode.ADD;
                case Key.SEPARATOR:
                    return VirtualKeyCode.SEPARATOR;
                case Key.SUBTRACT:
                    return VirtualKeyCode.SUBTRACT;
                case Key.DECIMAL:
                    return VirtualKeyCode.DECIMAL;
                case Key.DIVIDE:
                    return VirtualKeyCode.DIVIDE;
                case Key.F1:
                    return VirtualKeyCode.F1;
                case Key.F2:
                    return VirtualKeyCode.F2;
                case Key.F3:
                    return VirtualKeyCode.F3;
                case Key.F4:
                    return VirtualKeyCode.F4;
                case Key.F5:
                    return VirtualKeyCode.F5;
                case Key.F6:
                    return VirtualKeyCode.F6;
                case Key.F7:
                    return VirtualKeyCode.F7;
                case Key.F8:
                    return VirtualKeyCode.F8;
                case Key.F9:
                    return VirtualKeyCode.F9;
                case Key.F10:
                    return VirtualKeyCode.F10;
                case Key.F11:
                    return VirtualKeyCode.F11;
                case Key.F12:
                    return VirtualKeyCode.F12;
                case Key.F13:
                    return VirtualKeyCode.F13;
                case Key.F14:
                    return VirtualKeyCode.F14;
                case Key.F15:
                    return VirtualKeyCode.F15;
                case Key.F16:
                    return VirtualKeyCode.F16;
                case Key.F17:
                    return VirtualKeyCode.F17;
                case Key.F18:
                    return VirtualKeyCode.F18;
                case Key.F19:
                    return VirtualKeyCode.F19;
                case Key.F20:
                    return VirtualKeyCode.F20;
                case Key.F21:
                    return VirtualKeyCode.F21;
                case Key.F22:
                    return VirtualKeyCode.F22;
                case Key.F23:
                    return VirtualKeyCode.F23;
                case Key.F24:
                    return VirtualKeyCode.F24;
                case Key.NUMLOCK:
                    return VirtualKeyCode.NUMLOCK;
                case Key.LSHIFT:
                    return VirtualKeyCode.LSHIFT;
                case Key.RSHIFT:
                    return VirtualKeyCode.RSHIFT;
                case Key.LCONTROL:
                    return VirtualKeyCode.LCONTROL;
                case Key.RCONTROL:
                    return VirtualKeyCode.RCONTROL;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
        }

        public static Key VirutalKeyToKey(VirtualKeyCode key)
        {
            switch (key)
            {
                case VirtualKeyCode.BACK:
                    return Key.BACK;
                case VirtualKeyCode.TAB:
                    return Key.TAB;
                case VirtualKeyCode.CLEAR:
                    return Key.CLEAR;
                case VirtualKeyCode.RETURN:
                    return Key.RETURN;
                case VirtualKeyCode.SHIFT:
                    return Key.SHIFT;

                case VirtualKeyCode.CONTROL:
                    return Key.CONTROL;
                case VirtualKeyCode.MENU:
                    return Key.MENU;
                case VirtualKeyCode.PAUSE:
                    return Key.PAUSE;
                case VirtualKeyCode.ESCAPE:
                    return Key.ESCAPE;
                case VirtualKeyCode.SPACE:
                    return Key.SPACE;
                case VirtualKeyCode.END:
                    return Key.END;
                case VirtualKeyCode.HOME:
                    return Key.HOME;
                case VirtualKeyCode.LEFT:
                    return Key.LEFT;
                case VirtualKeyCode.UP:
                    return Key.UP;
                case VirtualKeyCode.RIGHT:
                    return Key.RIGHT;
                case VirtualKeyCode.DOWN:
                    return Key.DOWN;
                case VirtualKeyCode.SELECT:
                    return Key.SELECT;
                case VirtualKeyCode.PRINT:
                    return Key.PRINT;
                case VirtualKeyCode.INSERT:
                    return Key.INSERT;
                case VirtualKeyCode.DELETE:
                    return Key.DELETE;
                case VirtualKeyCode.VK_0:
                    return Key.KEY_0;
                case VirtualKeyCode.VK_1:
                    return Key.KEY_1;
                case VirtualKeyCode.VK_2:
                    return Key.KEY_2;
                case VirtualKeyCode.VK_3:
                    return Key.KEY_3;
                case VirtualKeyCode.VK_4:
                    return Key.KEY_4;
                case VirtualKeyCode.VK_5:
                    return Key.KEY_5;
                case VirtualKeyCode.VK_6:
                    return Key.KEY_6;
                case VirtualKeyCode.VK_7:
                    return Key.KEY_7;
                case VirtualKeyCode.VK_8:
                    return Key.KEY_8;
                case VirtualKeyCode.VK_9:
                    return Key.KEY_9;
                case VirtualKeyCode.VK_A:
                    return Key.KEY_A;
                case VirtualKeyCode.VK_B:
                    return Key.KEY_B;
                case VirtualKeyCode.VK_C:
                    return Key.KEY_C;
                case VirtualKeyCode.VK_D:
                    return Key.KEY_D;
                case VirtualKeyCode.VK_E:
                    return Key.KEY_E;
                case VirtualKeyCode.VK_F:
                    return Key.KEY_F;
                case VirtualKeyCode.VK_G:
                    return Key.KEY_G;
                case VirtualKeyCode.VK_H:
                    return Key.KEY_H;
                case VirtualKeyCode.VK_I:
                    return Key.KEY_I;
                case VirtualKeyCode.VK_J:
                    return Key.KEY_J;
                case VirtualKeyCode.VK_K:
                    return Key.KEY_K;
                case VirtualKeyCode.VK_L:
                    return Key.KEY_L;
                case VirtualKeyCode.VK_M:
                    return Key.KEY_M;
                case VirtualKeyCode.VK_N:
                    return Key.KEY_N;
                case VirtualKeyCode.VK_O:
                    return Key.KEY_O;
                case VirtualKeyCode.VK_P:
                    return Key.KEY_P;
                case VirtualKeyCode.VK_Q:
                    return Key.KEY_Q;
                case VirtualKeyCode.VK_R:
                    return Key.KEY_R;
                case VirtualKeyCode.VK_S:
                    return Key.KEY_S;
                case VirtualKeyCode.VK_T:
                    return Key.KEY_T;
                case VirtualKeyCode.VK_U:
                    return Key.KEY_U;
                case VirtualKeyCode.VK_V:
                    return Key.KEY_V;
                case VirtualKeyCode.VK_W:
                    return Key.KEY_W;
                case VirtualKeyCode.VK_X:
                    return Key.KEY_X;
                case VirtualKeyCode.VK_Y:
                    return Key.KEY_Y;
                case VirtualKeyCode.VK_Z:
                    return Key.KEY_Z;
                case VirtualKeyCode.NUMPAD0:
                    return Key.NUMPAD_0;
                case VirtualKeyCode.NUMPAD1:
                    return Key.NUMPAD_1;
                case VirtualKeyCode.NUMPAD2:
                    return Key.NUMPAD_2;
                case VirtualKeyCode.NUMPAD3:
                    return Key.NUMPAD_3;
                case VirtualKeyCode.NUMPAD4:
                    return Key.NUMPAD_4;
                case VirtualKeyCode.NUMPAD5:
                    return Key.NUMPAD_5;
                case VirtualKeyCode.NUMPAD6:
                    return Key.NUMPAD_6;
                case VirtualKeyCode.NUMPAD7:
                    return Key.NUMPAD_7;
                case VirtualKeyCode.NUMPAD8:
                    return Key.NUMPAD_8;
                case VirtualKeyCode.NUMPAD9:
                    return Key.NUMPAD_9;
                case VirtualKeyCode.MULTIPLY:
                    return Key.MULTIPLY;
                case VirtualKeyCode.ADD:
                    return Key.ADD;
                case VirtualKeyCode.SEPARATOR:
                    return Key.SEPARATOR;
                case VirtualKeyCode.SUBTRACT:
                    return Key.SUBTRACT;
                case VirtualKeyCode.DECIMAL:
                    return Key.DECIMAL;
                case VirtualKeyCode.DIVIDE:
                    return Key.DIVIDE;
                case VirtualKeyCode.F1:
                    return Key.F1;
                case VirtualKeyCode.F2:
                    return Key.F2;
                case VirtualKeyCode.F3:
                    return Key.F3;
                case VirtualKeyCode.F4:
                    return Key.F4;
                case VirtualKeyCode.F5:
                    return Key.F5;
                case VirtualKeyCode.F6:
                    return Key.F6;
                case VirtualKeyCode.F7:
                    return Key.F7;
                case VirtualKeyCode.F8:
                    return Key.F8;
                case VirtualKeyCode.F9:
                    return Key.F9;
                case VirtualKeyCode.F10:
                    return Key.F10;
                case VirtualKeyCode.F11:
                    return Key.F11;
                case VirtualKeyCode.F12:
                    return Key.F12;
                case VirtualKeyCode.F13:
                    return Key.F13;
                case VirtualKeyCode.F14:
                    return Key.F14;
                case VirtualKeyCode.F15:
                    return Key.F15;
                case VirtualKeyCode.F16:
                    return Key.F16;
                case VirtualKeyCode.F17:
                    return Key.F17;
                case VirtualKeyCode.F18:
                    return Key.F18;
                case VirtualKeyCode.F19:
                    return Key.F19;
                case VirtualKeyCode.F20:
                    return Key.F20;
                case VirtualKeyCode.F21:
                    return Key.F21;
                case VirtualKeyCode.F22:
                    return Key.F22;
                case VirtualKeyCode.F23:
                    return Key.F23;
                case VirtualKeyCode.F24:
                    return Key.F24;
                case VirtualKeyCode.NUMLOCK:

                    return Key.NUMLOCK;
                case VirtualKeyCode.LSHIFT:
                    return Key.LSHIFT;
                case VirtualKeyCode.RSHIFT:
                    return Key.RSHIFT;
                case VirtualKeyCode.LCONTROL:
                    return Key.LCONTROL;
                case VirtualKeyCode.RCONTROL:
                    return Key.RCONTROL;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
            throw new ArgumentException($"Key {key} not found");
        }
    }
}
