#include "pch.h"
#include "SystemCalls.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include <windows.h>
#include "GtSystemVersion.h"

 GTSystemVersion SystemCalls::GetOsVersion() {
    return GTSystemVersion("");
}

Vector2i SystemCalls::GetMaximizedWindowSize() {
    int screenWidth = GetSystemMetrics(SM_CXSCREEN);
    int screenHeight = GetSystemMetrics(SM_CYSCREEN);

    return Vector2i(screenWidth, screenHeight);
}

GTSystemVersion SystemCalls::GetSystemVersion() {
    return GTSystemVersion("");
}

std::shared_ptr<GTProcess> SystemCalls::StartProcess(const std::string& commandString) {
    return nullptr;
}

std::string SystemCalls::GetClipBoardContent() {
    return "";
}

std::vector<std::shared_ptr<GTWindow>> SystemCalls::GetActiveWindows() {
    return {};
}

std::vector<std::shared_ptr<GTWindow>> SystemCalls::FindWindowByName(const std::string& name) {
    return {};
}

std::vector<std::shared_ptr<GTProcess>> SystemCalls::FindProcessByName(const std::string& name) {
    return {};
}

std::vector<std::shared_ptr<GTProcess>> SystemCalls::GetActiveProcesses() {
    return {};
}

std::shared_ptr<GTWindow> SystemCalls::FindTopWindowByName(const std::string& name) {
    return nullptr;
}

void SystemCalls::WindowOfNameShouldExist(const std::string& name) {
    
}

int SystemCalls::GetWindowTitleBarHeight() {
    return SystemCallsFactory::GetSystemCalls()->GetWindowTitleBarHeight();
}

int SystemCalls::GetWindowBorderWidth() {
    return SystemCallsFactory::GetSystemCalls()->GetWindowBorderWidth();
}

int SystemCalls::GetWindowBorderHeight() {
    
    return SystemCallsFactory::GetSystemCalls()->GetWindowBorderHeight();
}

int SystemCalls::GetWindowPadding() {
    
    return SystemCallsFactory::GetSystemCalls()->GetWindowPadding();
}

Vector2i SystemCalls::GetScreenSize() {
	return SystemCallsFactory::GetSystemCalls()->GetScreenSize();
}
