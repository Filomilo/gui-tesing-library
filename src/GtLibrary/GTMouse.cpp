#include "pch.h"
#include "GTMouse.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include "Helpers.h"
#include "Configuration.h"

Vector2i GTMouse::GetPosition() const {
	
	return SystemCallsFactory::GetSystemCalls()->GetMousePosition();GtConfiguration::GetInstance()-> DefaultSleep();
}

void GTMouse::MoveMouse(const Vector2i& offset) {

	SystemCallsFactory::GetSystemCalls()->MoveMouse(offset);	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::SetPosition(const Vector2i& position) {
	
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(position);GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::ClickLeft() {
	
	SystemCallsFactory::GetSystemCalls()->ClickLeftMouse();GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::ClickRight() {
	
	SystemCallsFactory::GetSystemCalls()->ClickRightMouse();GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::ClickMiddle() {
	
	SystemCallsFactory::GetSystemCalls()->ClickMiddleMouse(); GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::PressLeft() {


	GtConfiguration::GetInstance()->DefaultSleep();	SystemCallsFactory::GetSystemCalls()->PressLeftMouse();
}

void GTMouse::PressMiddle() {
	
	SystemCallsFactory::GetSystemCalls()->PressMiddleMouse();GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::PressRight() {

	SystemCallsFactory::GetSystemCalls()->PressRightMouse();	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::ReleaseLeft() {

	SystemCallsFactory::GetSystemCalls()->ReleaseLeftMouse();	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::ReleaseMiddle() {

	SystemCallsFactory::GetSystemCalls()->ReleaseMiddleMouse();	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::ReleaseRight() {

	SystemCallsFactory::GetSystemCalls()->ReleaseRightMouse();	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::Scroll(int scrollValue) {

	SystemCallsFactory::GetSystemCalls()->ScrollMouse(scrollValue);	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::SetPositionRelativeToWindow(GTWindow window, const Vector2i& position) {

	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i newPosition = windowPosition + position;
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(newPosition);	GtConfiguration::GetInstance()->DefaultSleep();
}

void GTMouse::SetPositionRelativeToWindow(GTWindow window, const Vector2f& position) {

	Vector2i windowPosition = window.GetWindowContentPosition();
	Vector2i windowSize = window.GetWindowContentSize();
	Vector2i newPosition = windowPosition + Vector2i(
		static_cast<int>(windowSize.x * position.x),
		static_cast<int>(windowSize.y * position.y)
	);
	SystemCallsFactory::GetSystemCalls()->SetMousePosition(newPosition);	GtConfiguration::GetInstance()->DefaultSleep();
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

