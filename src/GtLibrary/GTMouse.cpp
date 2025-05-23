#include "pch.h"
#include "GTMouse.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include "Helpers.h"
#include "Configuration.h"

Vector2i GTMouse::GetPosition() const {
	GtConfiguration::GetInstance()-> DefaultSleep();
	return SystemCallsFactory::GetSystemCalls()->GetMousePosition();
}

void GTMouse::MoveMouse(const Vector2i& offset) {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->MoveMouse(offset);
}

void GTMouse::SetPosition(const Vector2i& position) {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(position);
}

void GTMouse::ClickLeft() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ClickLeftMouse();
}

void GTMouse::ClickRight() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ClickRightMouse();
}

void GTMouse::ClickMiddle() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ClickMiddleMouse();
}

void GTMouse::PressLeft() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->PressLeftMouse();
}

void GTMouse::PressMiddle() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->PressMiddleMouse();
}

void GTMouse::PressRight() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->PressRightMouse();
}

void GTMouse::ReleaseLeft() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ReleaseLeftMouse();
}

void GTMouse::ReleaseMiddle() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ReleaseMiddleMouse();
}

void GTMouse::ReleaseRight() {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ReleaseRightMouse();
}

void GTMouse::Scroll(int scrollValue) {
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->ScrollMouse(scrollValue);
}

void GTMouse::SetPositionRelativeToWindow(GTWindow window, const Vector2i& position) {
	GtConfiguration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(newPosition);
}

void GTMouse::SetPositionRelativeToWindow(GTWindow window, const Vector2f& position) {
	GtConfiguration::GetInstance()->DefaultSleep();
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
	GtConfiguration::GetInstance()->DefaultSleep();
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newRedSliderPosition);
}

void GTMouse::MoveMouseRelativeToWindowTo(GTWindow window, const Vector2i& position) {
	GtConfiguration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newPosition);
}

void GTMouse::MoveMouseRelativeToWindowTo(GTWindow window, const Vector2f& vector2f) {
	GtConfiguration::GetInstance()->DefaultSleep();
	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i windowSize = window.GetWindowContentSize();
	Vector2i newPosition = windowPosition + Vector2i(
		static_cast<int>(windowSize.x * vector2f.x),
		static_cast<int>(windowSize.y * vector2f.y)
	);
	SystemCallsFactory::GetSystemCalls()->MoveMouseTo(newPosition);

}

Vector2f GTMouse::GetPositionRelativeToWindow(GTWindow window) const {
		GtConfiguration::GetInstance()-> DefaultSleep();
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

