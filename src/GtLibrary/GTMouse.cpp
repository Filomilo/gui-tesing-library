#include "pch.h"
#include "GTMouse.h"

Vector2i GTMouse::GetPosition() const {
    return Vector2i();
}

void GTMouse::MoveMouse(const Vector2i& offset) {
}

void GTMouse::SetPosition(const Vector2i& position) {
}

void GTMouse::ClickLeft() {
}

void GTMouse::ClickRight() {
}

void GTMouse::ClickMiddle() {
}

void GTMouse::PressLeft() {
}

void GTMouse::PressMiddle() {
}

void GTMouse::PressRight() {
}

void GTMouse::ReleaseLeft() {
}

void GTMouse::ReleaseMiddle() {
}

void GTMouse::ReleaseRight() {
}

void GTMouse::Scroll(int scrollValue) {
}

void GTMouse::SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2i& position) {
}

void GTMouse::SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2f& position) {
}

void GTMouse::PositionShouldBe(const Vector2i& pos, int errorDistance) {
}

void GTMouse::MoveMouseTo(const Vector2i& newRedSliderPosition) {
}

void GTMouse::MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2i& position) {
}

void GTMouse::MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f) {
}

Vector2f GTMouse::GetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window) const {
    return Vector2f();
}

void GTMouse::PositionRelativeToWindowShouldBe(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f, float errorDistance) {
}
