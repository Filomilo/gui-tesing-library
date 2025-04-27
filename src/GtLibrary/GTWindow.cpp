#include "GTWindow.h"
#include "GTProcess.h"
#include <memory>
#include <string>
#include "Vector2i.h"
#include "Color.h"
#include "pch.h"

#include "GTWindow.h"

Vector2i GTWindow::GetPosition() const {
    return Vector2i();
}

bool GTWindow::DoesExist() const {
    return false;
}

std::string GTWindow::GetName() const {
    return "";
}

bool GTWindow::IsMinimized() const {
    return false;
}

void GTWindow::MoveWindow(const Vector2i& offset) {
}

void GTWindow::Minimize() {
}

void GTWindow::Maximize() {
}

std::shared_ptr<GTProcess> GTWindow::GetProcessOfWindow() {
    return std::make_shared<GTProcess>();
}

void GTWindow::Close() {
}

void GTWindow::SetWindowSize(int x, int y) {
}

void GTWindow::SetPosition(int x, int y) {
}

void GTWindow::BringUpFront() {
}

void GTWindow::SizeShouldBe(const Vector2i& vector2I) {
}

void GTWindow::ShouldWindowExist(bool v) {
}

void GTWindow::KillProcess() {
}

void GTWindow::ShouldBeMinimized(bool state) {
}

std::string GTWindow::GetWindowName() const {
    return "";
}

Vector2i GTWindow::GetWindowContentPosition() const {
    return Vector2i();
}

Vector2i GTWindow::GetWindowContentSize() const {
    return Vector2i();
}

Color GTWindow::GetContentPixelColorAt(const Vector2i& position) const {
    return Color();
}

Color GTWindow::GetContentPixelColorAt(const Vector2f& relativePosition) const {
    return Color();
}

void GTWindow::ContentPixelAtShouldBeColor(const Vector2i& position, const Color& color) {
}

void GTWindow::CenterWindow() {
}

void GTWindow::WindowNameShouldBe(const std::string& title) {
}

void GTWindow::ContentPixelAtShouldBeColor(const Vector2f& sliderColorCheckPosition, const Color& colorShouldBe, int errorPass) {
}
