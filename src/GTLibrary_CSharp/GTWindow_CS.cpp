#include "GTWindow_CS.h"
#include "GTWindow_CS.h"
#include "Vector2i_CS.h"
#include "Vector2f_CS.h"
#include "GTProcess_CS.h"
#include "Color_CS.h"
#include "Converters.h"
#include "GTWindow_CS.h"

Vector2i_CS^ GTWindow_CS::GetPosition() {
	return Converters::Vector2iToVector2iCS(_nativeWindow->GetPosition());
}
bool GTWindow_CS::DoesExist() {

	return this->_nativeWindow->DoesExist();
}
String^ GTWindow_CS::GetName() {
	return Converters::ConvertWStdStringToString(_nativeWindow->GetName());
}
bool GTWindow_CS::IsMinimized() {
	return _nativeWindow->IsMinimized();
}

void GTWindow_CS::MoveWindow(Vector2i_CS^ offset) {
	_nativeWindow->MoveWindow(Converters::Vector2iCSToVector2i(offset));
}
void GTWindow_CS::Minimize() {
	_nativeWindow->Minimize();
;}
void GTWindow_CS::Maximize() {
	_nativeWindow->Maximize();
}
GTProcess_CS^ GTWindow_CS::GetProcessOfWindow() {
	return Converters::ProcessToProcessCS(_nativeWindow->GetProcessOfWindow());
}
void GTWindow_CS::Close() {
	_nativeWindow->Close();
}
void GTWindow_CS::SetWindowSize(int x, int y) {
	_nativeWindow->SetWindowSize(x,y);

}
void GTWindow_CS::SetPosition(int x, int y) {

}
void GTWindow_CS::BringUpFront() {


}
void GTWindow_CS::SizeShouldBe(const Vector2i_CS^ size) {

}
void GTWindow_CS::ShouldWindowExist(bool exists) {

}
void GTWindow_CS::KillProcess() {

}
void GTWindow_CS::ShouldBeMinimized(bool state) {

}
String^ GTWindow_CS::GetWindowName() {
	return "";
}
Vector2i_CS^ GTWindow_CS::GetWindowContentPosition() {
	return nullptr;
}
Vector2i_CS^ GTWindow_CS::GetWindowContentSize() {
	return nullptr;
}
Color_CS^ GTWindow_CS::GetContentPixelColorAt(const Vector2i_CS^ position) {
	return nullptr;
}
Color_CS^ GTWindow_CS::GetContentPixelColorAt(const Vector2f_CS^ relativePosition) {
	return nullptr;
}
void GTWindow_CS::ContentPixelAtShouldBeColor(const Vector2i_CS^ position, const Color_CS^ color) {

}
void GTWindow_CS::CenterWindow() {

}
void GTWindow_CS::WindowNameShouldBe(const String^ title) {

}
void GTWindow_CS::ContentPixelAtShouldBeColor(const Vector2f_CS^ sliderColorCheckPosition, const Color_CS^ colorShouldBe, int errorPass) {

}
Vector2i_CS^ GTWindow_CS::GetWindowSize() {
	return nullptr;
}
Vector2i_CS^ GTWindow_CS::GetMaximizedWindowSize() {
	return nullptr;
}
ScreenShot_CS^ GTWindow_CS::GetScreenshot() {
	return nullptr;
}

ScreenShot_CS^ GTWindow_CS::GetScreenshotRect(const Vector2i_CS^ position, const Vector2i_CS^ size) {
	return nullptr;
}

Color_CS^ GTWindow_CS::GetPixelColorAt(const Vector2i_CS^ position) {
	return nullptr;
}

void GTWindow_CS::PixelAtShouldBeColor(const Vector2i_CS^ position, const Color_CS^ color) {
}
Vector2i_CS^ GTWindow_CS::GetWindowPosition() {
	return nullptr;
}
GTWindow* GTWindow_CS::GetNative()
{
	return this->_nativeWindow;
}

