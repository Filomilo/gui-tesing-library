#pragma once
#include "Vector2i.h"
#include "Vector2f.h"
#include "GTWindow.h"
#include <memory>

class GTMouse {


public:
    GTMouse() = default;

     Vector2i GetPosition() const;
     void MoveMouse(const Vector2i& offset);
     void SetPosition(const Vector2i& position);
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
     void SetPositionRelativeToWindow(GTWindow  window, const Vector2i& position);
     void SetPositionRelativeToWindow(GTWindow window, const Vector2f& position);
     void PositionShouldBe(const Vector2i& pos, int errorDistance = 0);
     void MoveMouseTo(const Vector2i& newRedSliderPosition);
     void MoveMouseRelativeToWindowTo( GTWindow  window, const Vector2i& position);
     void MoveMouseRelativeToWindowTo(  GTWindow window, const Vector2f& vector2f);
     Vector2f GetPositionRelativeToWindow(GTWindow window) const;
     void PositionRelativeToWindowShouldBe(GTWindow window, const Vector2f& vector2f, float errorDistance = 0);
};

