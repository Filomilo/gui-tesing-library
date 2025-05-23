using System;
using System.Diagnostics;
using System.Threading;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public static class Helpers
    {
        public static Key_CS keyToKeyCs(Key key)
        {
            return key switch
            {
                Key.RSHIFT => Key_CS.RSHIFT,
                Key.LCONTROL => Key_CS.LCONTROL,
                Key.RCONTROL => Key_CS.RCONTROL,
                Key.LSHIFT => Key_CS.LSHIFT,
                Key.NUMLOCK => Key_CS.NUMLOCK,
                Key.F24 => Key_CS.F24,
                Key.BACK => Key_CS.BACK,
                Key.F23 => Key_CS.F23,
                Key.F22 => Key_CS.F22,
                Key.F21 => Key_CS.F21,
                Key.F20 => Key_CS.F20,
                Key.F19 => Key_CS.F19,
                Key.F18 => Key_CS.F18,
                Key.F17 => Key_CS.F17,
                Key.F16 => Key_CS.F16,
                Key.F15 => Key_CS.F15,
                Key.F14 => Key_CS.F14,
                Key.F13 => Key_CS.F13,
                Key.F12 => Key_CS.F12,
                Key.F11 => Key_CS.F11,
                Key.F10 => Key_CS.F10,
                Key.F9 => Key_CS.F9,
                Key.F8 => Key_CS.F8,
                Key.F7 => Key_CS.F7,
                Key.F6 => Key_CS.F6,
                Key.F5 => Key_CS.F5,
                Key.F4 => Key_CS.F4,
                Key.F3 => Key_CS.F3,
                Key.F2 => Key_CS.F2,
                Key.F1 => Key_CS.F1,
                Key.DIVIDE => Key_CS.DIVIDE,
                Key.DECIMAL => Key_CS.DECIMAL,
                Key.SUBTRACT => Key_CS.SUBTRACT,
                Key.SEPARATOR => Key_CS.SEPARATOR,
                Key.ADD => Key_CS.ADD,
                Key.MULTIPLY => Key_CS.MULTIPLY,
                Key.NUMPAD_9 => Key_CS.NUMPAD_9,
                Key.NUMPAD_8 => Key_CS.NUMPAD_8,
                Key.NUMPAD_7 => Key_CS.NUMPAD_7,
                Key.NUMPAD_5 => Key_CS.NUMPAD_5,
                Key.NUMPAD_6 => Key_CS.NUMPAD_6,
                Key.NUMPAD_4 => Key_CS.NUMPAD_4,
                Key.NUMPAD_3 => Key_CS.NUMPAD_3,
                Key.NUMPAD_2 => Key_CS.NUMPAD_2,
                Key.NUMPAD_1 => Key_CS.NUMPAD_1,
                Key.NUMPAD_0 => Key_CS.NUMPAD_0,
                Key.KEY_Z => Key_CS.KEY_Z,
                Key.KEY_Y => Key_CS.KEY_Y,
                Key.KEY_X => Key_CS.KEY_X,
                Key.KEY_W => Key_CS.KEY_W,
                Key.KEY_V => Key_CS.KEY_V,
                Key.KEY_U => Key_CS.KEY_U,
                Key.KEY_T => Key_CS.KEY_T,
                Key.KEY_S => Key_CS.KEY_S,
                Key.KEY_R => Key_CS.KEY_R,
                Key.KEY_Q => Key_CS.KEY_Q,
                Key.KEY_O => Key_CS.KEY_O,
                Key.KEY_P => Key_CS.KEY_P,
                Key.KEY_N => Key_CS.KEY_N,
                Key.KEY_M => Key_CS.KEY_M,
                Key.KEY_L => Key_CS.KEY_L,
                Key.KEY_K => Key_CS.KEY_K,
                Key.KEY_J => Key_CS.KEY_J,
                Key.KEY_I => Key_CS.KEY_I,
                Key.KEY_H => Key_CS.KEY_H,
                Key.KEY_G => Key_CS.KEY_G,
                Key.KEY_F => Key_CS.KEY_F,
                Key.KEY_E => Key_CS.KEY_E,
                Key.KEY_D => Key_CS.KEY_D,
                Key.KEY_C => Key_CS.KEY_C,
                Key.KEY_B => Key_CS.KEY_B,
                Key.KEY_A => Key_CS.KEY_A,
                Key.KEY_9 => Key_CS.KEY_9,
                Key.KEY_8 => Key_CS.KEY_8,
                Key.KEY_7 => Key_CS.KEY_7,
                Key.KEY_6 => Key_CS.KEY_6,
                Key.KEY_5 => Key_CS.KEY_5,
                Key.KEY_4 => Key_CS.KEY_4,
                Key.KEY_3 => Key_CS.KEY_3,
                Key.KEY_2 => Key_CS.KEY_2,
                Key.KEY_1 => Key_CS.KEY_1,
                Key.KEY_0 => Key_CS.KEY_0,
                Key.DELETE => Key_CS.KEY_DELETE,
                Key.INSERT => Key_CS.INSERT,
                Key.PRINT => Key_CS.PRINT,
                Key.SELECT => Key_CS.SELECT,
                Key.DOWN => Key_CS.DOWN,
                Key.RIGHT => Key_CS.RIGHT,
                Key.UP => Key_CS.UP,
                Key.LEFT => Key_CS.LEFT,
                Key.HOME => Key_CS.HOME,
                Key.END => Key_CS.END,
                Key.SPACE => Key_CS.SPACE,
                Key.ESCAPE => Key_CS.ESCAPE,
                Key.PAUSE => Key_CS.PAUSE,
                Key.MENU => Key_CS.MENU,
                Key.CONTROL => Key_CS.CONTROL,
                Key.SHIFT => Key_CS.SHIFT,
                Key.RETURN => Key_CS.RETURN,
                Key.CLEAR => Key_CS.CLEAR,
                Key.TAB => Key_CS.TAB,
                _ => throw new ArgumentException($"Unmapped key: {key}"),
            };
        }

        internal static void AwaitTrue(Func<bool> func, string mes = "")
        {
            bool state = false;
            Stopwatch sw = Stopwatch.StartNew();
            while (state == false)
            {
                if (sw.ElapsedMilliseconds > Configuration.ProcesAwaitTime)
                {
                    sw.Stop();
                    throw new TimeoutException("Did not reach state within max time ::: " + mes);
                }
                state = func();
                if (!state)
                    Thread.Sleep(100);
            }

            sw.Stop();
        }

        public static Configuration.IMAGE_COMPARER CSImageComparerToImageComparer(CS_IMAGE_COMPARER_TYPE type)
        {
            switch (type)
            {
                case CS_IMAGE_COMPARER_TYPE.PIXEL_BY_PIXEL: return Configuration.IMAGE_COMPARER.PIEXEL_BY_PIXEL;
            }

            throw new ArgumentException();
        }

        public static CS_IMAGE_COMPARER_TYPE ImageCompaererToCsImageComparer(Configuration.IMAGE_COMPARER type)
        {
            switch (type)
            {
                case Configuration.IMAGE_COMPARER.PIEXEL_BY_PIXEL: return CS_IMAGE_COMPARER_TYPE.PIXEL_BY_PIXEL;
            }
            throw new ArgumentException();

        }
    }
}
