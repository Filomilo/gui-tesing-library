#include "pch.h"
#include "GTMouse.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include "Helpers.h"
#include "Configuration.h"

Vector2i GTMouse::GetPosition() const {
	Configuration::GetInstance()-> DefaultSleep();
	return SystemCallsFactory::GetSystemCalls()->GetMousePosition();
}

void GTMouse::MoveMouse(const Vector2i& offset) {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->MoveMouse(offset);
}

void GTMouse::SetPosition(const Vector2i& position) {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(position);
}

void GTMouse::ClickLeft() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ClickLeftMouse();
}

void GTMouse::ClickRight() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ClickRightMouse();
}

void GTMouse::ClickMiddle() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ClickMiddleMouse();
}

void GTMouse::PressLeft() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->PressLeftMouse();
}

void GTMouse::PressMiddle() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->PressMiddleMouse();
}

void GTMouse::PressRight() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->PressRightMouse();
}

void GTMouse::ReleaseLeft() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ReleaseLeftMouse();
}

void GTMouse::ReleaseMiddle() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ReleaseMiddleMouse();
}

void GTMouse::ReleaseRight() {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ReleaseRightMouse();
}

void GTMouse::Scroll(int scrollValue) {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ScrollMouse(scrollValue);
}

void GTMouse::SetPositionRelativeToWindow(GTWindow window, const Vector2i& position) {
	Configuration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(newPosition);
}

void GTMouse::SetPositionRelativeToWindow(GTWindow window, const Vector2f& position) {
	Configuration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i windowSize = window.GetWindowContentSize();
	Vector2i newPosition = windowPosition + Vector2i(
		static_cast<int>(windowSize.x * position.x),
		static_cast<int>(windowSize.y * position.y)
	);
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(newPosition);
}

void GTMouse::PositionShouldBe(const Vector2i& pos, int errorDistance) {
	Helpers::ensureTrue([&]() {
		Vector2i currentPosition = GetPosition();
		return (currentPosition - pos).Length() <= errorDistance;
		});
}

void GTMouse::MoveMouseTo(const Vector2i& newRedSliderPosition) {
	Configuration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newRedSliderPosition);
}

void GTMouse::MoveMouseRelativeToWindowTo(GTWindow window, const Vector2i& position) {
	Configuration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newPosition);
}

void GTMouse::MoveMouseRelativeToWindowTo(GTWindow window, const Vector2f& vector2f) {
	Configuration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i windowSize = window.GetWindowContentSize();
	Vector2i newPosition = windowPosition + Vector2i(
		static_cast<int>(windowSize.x * vector2f.x),
		static_cast<int>(windowSize.y * vector2f.y)
	);
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newPosition);

}

Vector2f GTMouse::GetPositionRelativeToWindow(GTWindow window) const {
		Configuration::GetInstance()-> DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i currentPosition = GetPosition();
	Vector2i windowSize = window.GetWindowContentSize();
	return Vector2f(
		static_cast<float>(currentPosition.x - windowPosition.x) / static_cast<float>(windowSize.x),
		static_cast<float>(currentPosition.y - windowPosition.y) / static_cast<float>(windowSize.y)
	);
}

void GTMouse::PositionRelativeToWindowShouldBe(GTWindow window, const Vector2f& vector2f, float errorDistance) {
	Helpers::ensureTrue([&]()->bool {
		Vector2f currentPosition = GetPositionRelativeToWindow(window);
		return (currentPosition - vector2f).Length() < errorDistance;
		});
}

