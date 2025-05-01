#include "pch.h"
#include "GTMouse.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include "Helpers.h"

Vector2i GTMouse::GetPosition() const {
	return SystemCallsFactory::GetSystemCalls()->GetMousePosition();
}

void GTMouse::MoveMouse(const Vector2i& offset) {
	SystemCallsFactory::GetSystemCalls()->MoveMouse(offset);
}

void GTMouse::SetPosition(const Vector2i& position) {
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(position);
}

void GTMouse::ClickLeft() {
	SystemCallsFactory::GetSystemCalls()->ClickLeftMouse();
}

void GTMouse::ClickRight() {
	SystemCallsFactory::GetSystemCalls()->ClickRightMouse();
}

void GTMouse::ClickMiddle() {
	SystemCallsFactory::GetSystemCalls()->ClickMiddleMouse();
}

void GTMouse::PressLeft() {
	SystemCallsFactory::GetSystemCalls()->PressLeftMouse();
}

void GTMouse::PressMiddle() {
	SystemCallsFactory::GetSystemCalls()->PressMiddleMouse();
}

void GTMouse::PressRight() {
	SystemCallsFactory::GetSystemCalls()->PressRightMouse();
}

void GTMouse::ReleaseLeft() {
	SystemCallsFactory::GetSystemCalls()->ReleaseLeftMouse();
}

void GTMouse::ReleaseMiddle() {
	SystemCallsFactory::GetSystemCalls()->ReleaseMiddleMouse();
}

void GTMouse::ReleaseRight() {
	SystemCallsFactory::GetSystemCalls()->ReleaseRightMouse();
}

void GTMouse::Scroll(int scrollValue) {
	SystemCallsFactory::GetSystemCalls()->ScrollMouse(scrollValue);
}

void GTMouse::SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2i& position) {
	Vector2i windowPosition = window->GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(newPosition);
}

void GTMouse::SetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window, const Vector2f& position) {
	Vector2i windowPosition = window->GetWindowContentPosition();
	Vector2i windowSize = window->GetWindowContentSize();
	Vector2i newPosition = windowPosition + Vector2i(
		static_cast<int>(windowSize.x * position.x),
		static_cast<int>(windowSize.y * position.y)
	);
}

void GTMouse::PositionShouldBe(const Vector2i& pos, int errorDistance) {
	Helpers::ensureTrue([&]() {
		Vector2i currentPosition = GetPosition();
		return (currentPosition - pos).Length() < errorDistance;
		});
}

void GTMouse::MoveMouseTo(const Vector2i& newRedSliderPosition) {
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newRedSliderPosition);
}

void GTMouse::MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2i& position) {
	Vector2i windowPosition = window->GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newPosition);
}

void GTMouse::MoveMouseRelativeToWindowTo(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f) {
	Vector2i windowPosition = window->GetWindowContentPosition();
	Vector2i windowSize = window->GetWindowContentSize();
	Vector2i newPosition = windowPosition + Vector2i(
		static_cast<int>(windowSize.x * vector2f.x),
		static_cast<int>(windowSize.y * vector2f.y)
	);
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newPosition);

}

Vector2f GTMouse::GetPositionRelativeToWindow(const std::shared_ptr<GTWindow>& window) const {
	Vector2i windowPosition = window->GetWindowContentPosition();
	Vector2i currentPosition = GetPosition();
	Vector2i windowSize = window->GetWindowContentSize();
	return Vector2f(
		static_cast<float>(currentPosition.x - windowPosition.x) / static_cast<float>(windowSize.x),
		static_cast<float>(currentPosition.y - windowPosition.y) / static_cast<float>(windowSize.y)
	);
}

void GTMouse::PositionRelativeToWindowShouldBe(const std::shared_ptr<GTWindow>& window, const Vector2f& vector2f, float errorDistance) {
	Helpers::ensureTrue([&]()->bool {
		Vector2f currentPosition = GetPositionRelativeToWindow(window);
		return (currentPosition - vector2f).Length() < errorDistance;
		});
}

