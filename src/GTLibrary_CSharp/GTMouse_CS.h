#pragma once
#pragma once
using namespace System;

#include <string>
#include "Vector2i_CS.h"
#include "Vector2f_CS.h"
#include "GTWindow_CS.h"
#include "../GtLibrary/GTMouse.h"


public ref class GTMouse_CS
{
private:
    GTMouse* native = new GTMouse();
    ~GTMouse_CS()
    {
        this->!GTMouse_CS();
    }
    !GTMouse_CS() {
        delete native;
    }
public:
    Vector2i_CS^ GetPosition();

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
    void PositionShouldBe(Vector2i_CS^ pos, int errorDistance );
    void MoveMouseTo(Vector2i_CS^ newRedSliderPosition);
    void MoveMouseRelativeToWindowTo(GTWindow_CS^ window, Vector2i_CS^ position);
    void MoveMouseRelativeToWindowTo(GTWindow_CS^ window, Vector2f_CS^ position);
    Vector2f_CS^ GetPositionRelativeToWindow(GTWindow_CS^ window);
    void PositionRelativeToWindowShouldBe(GTWindow_CS^ window, Vector2f_CS^ position, float errorDistance );
};
