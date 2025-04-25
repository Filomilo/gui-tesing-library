#include "pch.h"
#include "GTSystem.h"
#include <stdexcept>
#include "SystemCalls.h"
#include "memory.h"


std::shared_ptr<GTSystem> GTSystem::_gtSystem = nullptr;

GTSystem::GTSystem() : _SystemCalls(std::make_shared<SystemCalls>()) {}

std::shared_ptr<GTSystem> GTSystem::Instance() {
    if (!_gtSystem) {
        _gtSystem = std::shared_ptr<GTSystem>(new GTSystem());
    }
    return _gtSystem;
}

std::vector<std::shared_ptr<GTWindow>> GTSystem::FindWindowByName(const std::string& name) {
    return {};
}

std::vector<std::shared_ptr<GTProcess>> GTSystem::FindProcessByName(const std::string& name) {
    return {};
}

std::shared_ptr<GTWindow> GTSystem::FindTopWindowByName(const std::string& name) {
    return nullptr;
}

std::shared_ptr<GTSystem> GTSystem::WindowOfNameShouldExist(const std::string& name) {
    return nullptr;
}

std::vector<std::shared_ptr<GTProcess>> GTSystem::GetActiveProcesses() {

    return {};
}

std::vector<std::shared_ptr<GTWindow>> GTSystem::GetActiveWindows() {
    return {};
}

std::string GTSystem::GetClipBoardContent() {

    return "";
}

std::shared_ptr<GTProcess> GTSystem::StartProcess(const std::string& commandString) {

    return nullptr;
}

GTSystemVersion GTSystem::GetOsVersion() const {

    return GTSystemVersion();
}

GTSystemVersion GTSystem::GetSystemVersion() {

    return GTSystemVersion();
}

int GTSystem::GetWindowTitleBarHeight() {

    return 0;
}

int GTSystem::GetWindowBorderWidth() {
 
    return 0;
}

int GTSystem::GetWindowBorderHeight() {

    return 0;
}

int GTSystem::GetWindowPadding() {
  return 0;
}

Vector2i GTSystem::GetScreenSize() {
   
    return Vector2i(0, 0);
}

Vector2i GTSystem::GetMaximizedWindowSize() {
	return this->_SystemCalls->GetMaximizedWindowSize();
}

