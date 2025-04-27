#pragma once
#pragma once

#include <string>
#include "Vector2i_CS.h"
#include "Vector2f_CS.h"
#include "GTWindow_CS.h"

using namespace System;

public ref class GTMouse_CS
{
public:
    property Vector2i_CS^ Position;

    void MoveMouse(Vector2i_CS^ offset);
    void SetPosition(Vector2i_CS^ position);
    void ClickLeft();
    void ClickRight();
    void ClickMiddle();
    void PressLeft();
    void PressMiddle();
    void PressRight();
    void ReleaseLeft();
    void ReleaseMiddle();
    void ReleaseRight();
    void Scroll(int scrollValue);
    void SetPositionRelativeToWindow(GTWindow_CS^ window, Vector2i_CS^ position);
    void SetPositionRelativeToWindow(GTWindow_CS^ window, Vector2f_CS^ position);
    void PositionShouldBe(Vector2i_CS^ pos, int errorDistance = 0);
    void MoveMouseTo(Vector2i_CS^ newRedSliderPosition);
    void MoveMouseRelativeToWindowTo(GTWindow_CS^ window, Vector2i_CS^ position);
    void MoveMouseRelativeToWindowTo(GTWindow_CS^ window, Vector2f_CS^ position);
    Vector2f_CS^ GetPositionRelativeToWindow(GTWindow_CS^ window);
    void PositionRelativeToWindowShouldBe(GTWindow_CS^ window, Vector2f_CS^ position, float errorDistance = 0);
};
