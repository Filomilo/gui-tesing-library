#include "pch.h"
#include "GTWindow.h"
#include "GTProcess.h"
#include <memory>
#include <string>
#include "Vector2i.h"
#include "Color.h"

#include "SystemCallsFactory.h"
#include "GTWindow.h"
#include "Helpers.h"

Vector2i GTWindow::GetPosition() const {
	return SystemCallsFactory::GetSystemCalls()->GetWindowPostion(handle);
}

bool GTWindow::DoesExist() const {
    GtConfiguration::GetInstance()->DefaultSleep();
    return SystemCallsFactory::GetSystemCalls()->DoesWindowExist(handle);
}

std::wstring GTWindow::GetName() const {
	return SystemCallsFactory::GetSystemCalls()->GetWindowName(handle);
}

bool GTWindow::IsMinimized() const {
    return SystemCallsFactory::GetSystemCalls()->IsWindowMinimized(handle);
}

void GTWindow::MoveWindow(const Vector2i& offset) {
	Vector2i currentPosition = GetPosition();
	Vector2i newPosition = currentPosition + offset;
	SystemCallsFactory::GetSystemCalls()->SetWindowPosition(handle, newPosition);
}

void GTWindow::Minimize() {
	SystemCallsFactory::GetSystemCalls()->MinizmizeWindow(handle);
    GtConfiguration::GetInstance()->DefaultSleep();
}

void GTWindow::Maximize() {
    SystemCallsFactory::GetSystemCalls()->MaximizeWindow(handle);
        GtConfiguration::GetInstance()->DefaultSleep();
}

GTProcess* GTWindow::GetProcessOfWindow() {
    return new GTProcess(SystemCallsFactory::GetSystemCalls()->GetProcessOfWindow(handle));
}

void GTWindow::Close() {
    SystemCallsFactory::GetSystemCalls()->TerminateWindow(handle);
}

void GTWindow::SetWindowSize(int x, int y) {
	Vector2i size = { x, y };
	SystemCallsFactory::GetSystemCalls()->SetWindowSize(handle, size);
}

void GTWindow::SetPosition(int x, int y) {
	Vector2i position = { x, y };
	SystemCallsFactory::GetSystemCalls()->SetWindowPosition(handle, position);
}

void GTWindow::BringUpFront() {
	SystemCallsFactory::GetSystemCalls()->BringWindowUpFront(handle);
}

void GTWindow::SizeShouldBe(const Vector2i& vector2I) {
    Helpers::ensureTrue([&]() {
        Vector2i size = SystemCallsFactory::GetSystemCalls()->GetSizeOfWindow(handle);
        return size.Equals(vector2I);
        });
}

void GTWindow::ShouldWindowExist(bool v) {
    Helpers::ensureTrue([&]() {
		bool doesExist = SystemCallsFactory::GetSystemCalls()->DoesWindowExist(handle);
        return doesExist==v;
        });
}

void GTWindow::KillProcess() {
    GTProcess* proc = this->GetProcessOfWindow();
    proc->Kill();
}

void GTWindow::ShouldBeMinimized(bool state) {
	Helpers::ensureTrue([&]() {
		bool isMinimized = SystemCallsFactory::GetSystemCalls()->IsWindowMinimized(handle);
		return isMinimized == state;
		});
}

std::wstring GTWindow::GetWindowName() const {
	return SystemCallsFactory::GetSystemCalls()->GetWindowName(handle);
}

Vector2i GTWindow::GetWindowContentPosition() const {
    Vector2i positon = this->GetPosition();
	int WindowBorderWidth = SystemCallsFactory::GetSystemCalls()->GetWindowBorderWidth();
	int WindowBorderHeight = SystemCallsFactory::GetSystemCalls()->GetWindowBorderHeight();
	int WindowTitleBarHeight = SystemCallsFactory::GetSystemCalls()->GetWindowTitleBarHeight();
    return Vector2i(
        positon.x + WindowBorderWidth,
        positon.y
        + WindowBorderHeight
        + WindowTitleBarHeight
    );
}

Vector2i GTWindow::GetWindowContentSize() const {
    Vector2i size = this->GetSize();
    int borderWidth = SystemCallsFactory::GetSystemCalls()->GetWindowBorderWidth();
    int windwopadding = SystemCallsFactory::GetSystemCalls()->GetWindowPadding();
    int WindowBorderHeight = SystemCallsFactory::GetSystemCalls()->GetWindowBorderHeight();
    int windowtielebarheight = SystemCallsFactory::GetSystemCalls()->GetWindowTitleBarHeight();
    return Vector2i(
        size.x - borderWidth * 2 - windwopadding * 2 - 1,
        size.y - WindowBorderHeight * 2 - windowtielebarheight - windwopadding * 2 - 5
    );
}

Color GTWindow::GetContentPixelColorAt(const Vector2i& position) const {
    GtConfiguration::GetInstance()->DefaultSleep();
	return SystemCallsFactory::GetSystemCalls()->GetPixelColorAt(handle, position);
}

Color GTWindow::GetContentPixelColorAt(const Vector2f& relativePosition) const {
    GtConfiguration::GetInstance()->DefaultSleep();
    Vector2i contentSize = this->GetWindowContentSize();
    return GetContentPixelColorAt(
        Vector2i(
            (int)(contentSize.x * relativePosition.x),
            (int)(contentSize.y * relativePosition.y)
        )
    );
}

void GTWindow::ContentPixelAtShouldBeColor(const Vector2i& position, const Color& color) {
	Helpers::ensureTrue([&]()->bool {
		Color pixelColor = this->GetContentPixelColorAt(position);
		return pixelColor.Equals(color);
		});
}

void GTWindow::CenterWindow() {
    GtConfiguration::GetInstance()->DefaultSleep();
    Vector2i screenSize = SystemCallsFactory::GetSystemCalls()->GetScreenSize();
    Vector2i windowSize = this->GetSize();
    Vector2i diffrence = screenSize - windowSize;
    this->SetPosition(diffrence.x / 2, diffrence.y / 2);

}

void GTWindow::WindowNameShouldBe(const std::wstring& title) {
    GtConfiguration::GetInstance()->DefaultSleep();
	Helpers::ensureTrue([&]() {
		std::wstring name = SystemCallsFactory::GetSystemCalls()->GetWindowName(handle);
		return name == title;
		});
}

void GTWindow::ContentPixelAtShouldBeColor(const Vector2f& sliderColorCheckPosition, const Color& colorShouldBe, int errorPass) {
    std::function<bool()> func = [&]()->bool {
        Color color = this->GetContentPixelColorAt(sliderColorCheckPosition);
        return color.Equals(colorShouldBe, errorPass);
        };
    Helpers::ensureTrue(func);
}

HWND GTWindow::GetHandle() {
    return this->handle;
}

Vector2i GTWindow::GetSize() const {
    return SystemCallsFactory().GetSystemCalls()->GetSizeOfWindow(this->handle);
}

GTScreenshot* GTWindow::GetScreenshot()
{
    Vector2i size = this->GetWindowContentSize();
    Vector2i pos = Vector2i();
    return   SystemCallsFactory().GetSystemCalls()->GetScreenshot(this->handle, pos, size);
}
GTScreenshot* GTWindow::GetScreenshotRect(Vector2i position, Vector2i size) {
    return   SystemCallsFactory().GetSystemCalls()->GetScreenshot(this->handle, position, size);
}

Color GTWindow::GetPixelColorAt(Vector2i position) {
    return   SystemCallsFactory().GetSystemCalls()->GetPixelColorAt(this->handle, position);
}
void GTWindow::PixelAtShouldBeColor(Vector2i position, Color color) {
    std::function<bool()> func = [&]()->bool {
        Color color = this->GetPixelColorAt(position);
        return color.Equals(color);
        };
    Helpers::ensureTrue(func);
}