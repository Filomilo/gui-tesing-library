#include "pch.h"
#include "GTSystem.h"
#include <stdexcept>
#include "SystemCalls.h"
#include "memory.h"
#include "Helpers.h"
#include <optional>
#include "GTWindow.h"

class GTWindow;

std::shared_ptr<GTSystem> GTSystem::_gtSystem = nullptr;

GTSystem::GTSystem() : _SystemCalls(std::make_shared<SystemCalls>()) {}

std::shared_ptr<GTSystem> GTSystem::Instance() {
    if (!_gtSystem) {
        _gtSystem = std::shared_ptr<GTSystem>(new GTSystem());
    }
    return _gtSystem;
}

std::vector<GTWindow> GTSystem::FindWindowByName(const std::string& name) {
    return {};
}

std::vector<GTProcess> GTSystem::FindProcessByName(const std::string& name) {
    return {};
}

std::optional<GTWindow> GTSystem::FindTopWindowByName(const std::string& name) {
    HWND hwnd = FindWindowA(nullptr, name.c_str());
    if (hwnd != nullptr) {
        if (IsWindow(hwnd)) {
            return GTWindow(hwnd);
        }
        
    }
    return std::nullopt;
}


std::vector<GTProcess> GTSystem::GetActiveProcesses() {
    std::vector<HANDLE> handles= _SystemCalls->GetActiveProcesses();
    std::vector<GTProcess> processes = std::vector<GTProcess>(1);
    for (size_t i = 0; i < handles.size(); i++)
    {
        processes.push_back(GTProcess(handles[i]));
    }
    return processes;

}

std::vector<GTWindow> GTSystem::GetActiveWindows() {
    std::vector<HWND> windowhandles = this->_SystemCalls->GetActiveWindows();
    std::vector<GTWindow> windows = std::vector<GTWindow>();
    for(HWND handle : windowhandles)
    {
        windows.push_back(GTWindow(handle));
    }
    return windows;
}

std::wstring GTSystem::GetClipBoardContent() {

    return this->_SystemCalls->GetClipBoardContent();
}

GTProcess* GTSystem::StartProcess(const std::string& commandString) {

    return new GTProcess((HANDLE)this->_SystemCalls->StartProcess(commandString)) ;
}

GTSystemVersion GTSystem::GetOsVersion() const {

    return this->_SystemCalls->GetSystemVersion();
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

void GTSystem::WindowOfNameShouldExist(const std::string& name) {
 
    Helpers::ensureTrue([this,name]()-> bool {
        std::optional<GTWindow> window = this->FindTopWindowByName(name);
        return window.has_value();
        });
}