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
	_nativeWindow->SetPosition(x, y);
}
void GTWindow_CS::BringUpFront() {
	_nativeWindow->BringUpFront();

}
void GTWindow_CS::SizeShouldBe(Vector2i_CS^ size)
{
	_nativeWindow->SizeShouldBe(Converters::Vector2iCSToVector2i(size));
}
void GTWindow_CS::ShouldWindowExist(bool exists) {
	_nativeWindow->ShouldWindowExist(exists);
}
void GTWindow_CS::KillProcess() {
	_nativeWindow->KillProcess();

}
void GTWindow_CS::ShouldBeMinimized(bool state) {
	_nativeWindow->ShouldBeMinimized(state);
}
String^ GTWindow_CS::GetWindowName() {
	return Converters::ConvertWStdStringToString(_nativeWindow->GetName());
}
Vector2i_CS^ GTWindow_CS::GetWindowContentPosition() {
	return Converters::Vector2iToVector2iCS(_nativeWindow->GetWindowContentPosition());
}
Vector2i_CS^ GTWindow_CS::GetWindowContentSize() {
	Vector2i size = _nativeWindow->GetWindowContentSize();
	return Converters::Vector2iToVector2iCS(size);

}
Color_CS^ GTWindow_CS::GetContentPixelColorAt(Vector2i_CS^ position) {
	return Converters::ColorToColorCS(_nativeWindow->GetContentPixelColorAt(Converters::Vector2iCSToVector2i(position)));
}
Color_CS^ GTWindow_CS::GetContentPixelColorAt(Vector2f_CS^ relativePosition) {
	return Converters::ColorToColorCS(_nativeWindow->GetContentPixelColorAt(Converters::Vector2fCSToVector2f(relativePosition)));
}
void GTWindow_CS::ContentPixelAtShouldBeColor(Vector2i_CS^ position, Color_CS^ color) {
	_nativeWindow->ContentPixelAtShouldBeColor(Converters::Vector2iCSToVector2i(position), Converters::ColorCSToColor(color));

}
void GTWindow_CS::CenterWindow() {
	_nativeWindow->CenterWindow();
}
void GTWindow_CS::WindowNameShouldBe(String^ title) {
	_nativeWindow->WindowNameShouldBe(Converters::ConvertStringToWStdString(title));
}
void GTWindow_CS::ContentPixelAtShouldBeColor(Vector2f_CS^ sliderColorCheckPosition, Color_CS^ colorShouldBe, int errorPass) {

}
Vector2i_CS^ GTWindow_CS::GetWindowSize() {
	return gcnew Vector2i_CS(_nativeWindow->GetSize());
}
Vector2i_CS^ GTWindow_CS::GetMaximizedWindowSize() {
	return Converters::Vector2iToVector2iCS(GTSystem::Instance()-> GetMaximizedWindowSize());
}
ScreenShot_CS^ GTWindow_CS::GetScreenshot() {
	return Converters::ScreenShotTOScreenShotCs(_nativeWindow->GetScreenshot());
}

ScreenShot_CS^ GTWindow_CS::GetScreenshotRect(Vector2i_CS^ position, Vector2i_CS^ size) {
	return Converters::ScreenShotTOScreenShotCs(_nativeWindow->GetScreenshotRect(
		Converters::Vector2iCSToVector2i(position), Converters::Vector2iCSToVector2i(size)
	));
}

Color_CS^ GTWindow_CS::GetPixelColorAt(Vector2i_CS^ position) {
	return Converters::ColorToColorCS(_nativeWindow->GetPixelColorAt(Converters::Vector2iCSToVector2i(position)));
}

void GTWindow_CS::PixelAtShouldBeColor( Vector2i_CS^ position, Color_CS^ color) {
	_nativeWindow->PixelAtShouldBeColor(Converters::Vector2iCSToVector2i(position), Converters::ColorCSToColor(color));
}
Vector2i_CS^ GTWindow_CS::GetWindowPosition() {
	return Converters::Vector2iToVector2iCS(_nativeWindow->GetPosition());
}
GTWindow* GTWindow_CS::GetNative()
{
	return this->_nativeWindow;
}

