#include "GTWindow.h"
#include "GTProcess.h"
#include <memory>
#include <string>
#include "Vector2i.h"
#include "Color.h"
#include "pch.h"



//Vector2i GTWindow::GetPosition() const {
//    return Vector2i(0, 0);
//}
//
//bool GTWindow::DoesExist() const {
//    return true;
//}
//
//std::string GTWindow::GetName() const {
//    return "Default Window Name";
//}
//
//bool GTWindow::IsMinimized() const {
//    return false;
//}
//
//std::shared_ptr<GTWindow> GTWindow::MoveWindow(const Vector2i& offset) {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::Minimize() {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::Maximize() {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTProcess> GTWindow::GetProcessOfWindow() {
//    return std::make_shared<GTProcess>();
//}
//
//std::shared_ptr<GTWindow> GTWindow::Close() {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::SetWindowSize(int x, int y) {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::SetPosition(int x, int y) {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::BringUpFront() {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::SizeShouldBe(const Vector2i& vector2I) {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::ShouldWindowExist(bool v) {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::KillProcess() {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::shared_ptr<GTWindow> GTWindow::ShouldBeMinimized(bool state) {
//    return std::make_shared<GTWindow>(*this);
//}
//
//std::string GTWindow::GetWindowName() const {
//    return "Default Window Name";
//}
//
//Vector2i GTWindow::GetWindowContentPosition() const {
//    return Vector2i(0, 0);
//}
//
//Vector2i GTWindow::GetWindowContentSize() const {
//    return Vector2i(800, 600);
//}
//
//Color GTWindow::GetContentPixelColorAt(const Vector2i& position) const {
//    return Color(255, 255, 255);
//}
//
//Color GTWindow::GetContentPixelColorAt(const Vector2f& relativePosition) const {
//    return Color(255, 255, 255);
//}
//
//std::shared_ptr<GTWindow> GTWindow::CenterWindow() {
//    return std::make_shared<GTWindow>(*this);
//}
