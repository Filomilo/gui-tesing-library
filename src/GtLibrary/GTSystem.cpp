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
    std::vector<int> windowhandles = this->_SystemCalls->GetActiveWindows();
    std::vector<std::shared_ptr<GTWindow>> windows = std::vector<std::shared_ptr<GTWindow>>();
    for(int handle : windowhandles)
    {
        windows.push_back(std::make_shared<GTWindow>(handle));
    }
    return windows;
}

std::string GTSystem::GetClipBoardContent() {

    return this->_SystemCalls->GetClipBoardContent();
}

std::shared_ptr<GTProcess> GTSystem::StartProcess(const std::string& commandString) {

    return std::make_shared<GTProcess>(this->_SystemCalls->StartProcess(commandString)) ;
}

GTSystemVersion GTSystem::GetOsVersion() const {

    return this->_SystemCalls->GetOsVersion();
}

GTSystemVersion GTSystem::GetSystemVersion() {

    return this->_SystemCalls->GetSystemVersion();
}

int GTSystem::GetWindowTitleBarHeight() {

    return this->_SystemCalls->GetWindowTitleBarHeight();
}

int GTSystem::GetWindowBorderWidth() {
 
    return this->_SystemCalls->GetWindowBorderWidth();
}

int GTSystem::GetWindowBorderHeight() {

	return this->_SystemCalls->GetWindowBorderHeight();
}

int GTSystem::GetWindowPadding() {
    return this->_SystemCalls->GetWindowPadding();
}

Vector2i GTSystem::GetScreenSize() {
   
	return this->_SystemCalls->GetScreenSize();
}

Vector2i GTSystem::GetMaximizedWindowSize() {
	return this->_SystemCalls->GetMaximizedWindowSize();
}

