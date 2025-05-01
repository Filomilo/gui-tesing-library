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
//#include <msclr/marshal_cppstd.h>

ref class Converters
{
public:
    static std::string ConvertStringToStdString(System::String^ managedString) {
        return "asd";
        //return msclr::interop::marshal_as<std::string>(managedString);
    }
    static String^ ConvertStdStringToString(std::string string) {
        return "asd";
        //return msclr::interop::marshal_as<std::string>(managedString);
    }

    static Key KeyCSToKEy(Key_CS key_Cs)
    {
        return Key::RSHIFT;
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
        return std::make_shared<GTWindow>(win->GetNative());
    }

    static ScreenShot_CS^ ScreenShotTOScreenShotCs(GTScreenshot  screen)
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

    static GTProcess_CS^ ProcessToProcessCS(std::shared_ptr<GTProcess> proc)
    {
        return gcnew GTProcess_CS(proc);
    }

};