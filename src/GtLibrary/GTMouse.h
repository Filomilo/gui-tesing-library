#pragma once
#include "Vector2i.h"
#include "Vector2f.h"
#include "GTWindow.h"
#include <memory>

class GTMouse {
public:
    GTMouse() = default;

    virtual Vector2i GetPosition() const = 0;
    virtual void MoveMouse(const Vector2i& offset) = 0;
    virtual void SetPosition(const Vector2i& position) = 0;
    virtual void ClickLeft() = 0;
    virtual void ClickRight() = 0;
    virtual void ClickMiddle() = 0;
    virtual void PressLeft() = 0;
    virtual void PressMiddle() = 0;
    virtual void PressRight() = 0;
    virtual void ReleaseLeft() = 0;
    virtual void ReleaseMiddle() = 0;
    virtual void ReleaseRight() = 0;
    virtual void Scroll(int scrollValue) = 0;
    virtual void SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2i& position) = 0;
    virtual void SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2f& position) = 0;
    virtual void PositionShouldBe(const Vector2i& pos, int errorDistance = 0) = 0;
    virtual void MoveMouseTo(const Vector2i& newRedSliderPosition) = 0;
    virtual void MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2i& position) = 0;
    virtual void MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f) = 0;
    virtual Vector2f GetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window) const = 0;
    virtual void PositionRelativeToWindowShouldBe(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f, float errorDistance = 0) = 0;
};

