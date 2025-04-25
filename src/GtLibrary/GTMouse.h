#pragma once
#include "Vector2i.h"
#include "Vector2f.h"
#include "GTWindow.h"
#include <memory>

class GTMouse {
public:
    GTMouse() = default;

    virtual Vector2i GetPosition() const = 0;
    virtual std::shared_ptr<GTMouse> MoveMouse(const Vector2i& offset) = 0;
    virtual std::shared_ptr<GTMouse> SetPosition(const Vector2i& position) = 0;
    virtual std::shared_ptr<GTMouse> ClickLeft() = 0;
    virtual std::shared_ptr<GTMouse> ClickRight() = 0;
    virtual std::shared_ptr<GTMouse> ClickMiddle() = 0;
    virtual std::shared_ptr<GTMouse> PressLeft() = 0;
    virtual std::shared_ptr<GTMouse> PressMiddle() = 0;
    virtual std::shared_ptr<GTMouse> PressRight() = 0;
    virtual std::shared_ptr<GTMouse> ReleaseLeft() = 0;
    virtual std::shared_ptr<GTMouse> ReleaseMiddle() = 0;
    virtual std::shared_ptr<GTMouse> ReleaseRight() = 0;
    virtual std::shared_ptr<GTMouse> Scroll(int scrollValue) = 0;
    virtual std::shared_ptr<GTMouse> SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2i& position) = 0;
    virtual std::shared_ptr<GTMouse> SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2f& position) = 0;
    virtual std::shared_ptr<GTMouse> PositionShouldBe(const Vector2i& pos, int errorDistance = 0) = 0;
    virtual std::shared_ptr<GTMouse> MoveMouseTo(const Vector2i& newRedSliderPosition) = 0;
    virtual std::shared_ptr<GTMouse> MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2i& position) = 0;
    virtual std::shared_ptr<GTMouse> MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f) = 0;
    virtual Vector2f GetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window) const = 0;
    virtual std::shared_ptr<GTMouse> PositionRelativeToWindowShouldBe(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f, float errorDistance = 0) = 0;
};

