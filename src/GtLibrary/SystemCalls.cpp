#include "pch.h"
#include "SystemCalls.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include <windows.h>
#include <tlhelp32.h>

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
    std::vector<std::shared_ptr<GTProcess>> processes;

    HANDLE hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if (hProcessSnap == INVALID_HANDLE_VALUE) {
        return processes; 
    }
    PROCESSENTRY32 pe32;
    pe32.dwSize = sizeof(PROCESSENTRY32);
   if (Process32First(hProcessSnap, &pe32)) {
        do {
             std::shared_ptr<GTProcess> process = std::make_shared<GTProcess>(pe32.szExeFile);
            processes.push_back(process);
        } while (Process32Next(hProcessSnap, &pe32)); 
    }

    CloseHandle(hProcessSnap); 
    return processes;
}

std::shared_ptr<GTWindow> SystemCalls::FindTopWindowByName(const std::string& name) {
	return std::make_shared<GTWindow>(FindWindowA(nullptr, name.c_str()));
}

void SystemCalls::WindowOfNameShouldExist(const std::string& name) {
	throw std::runtime_error("Not implemented");
}

int SystemCalls::GetWindowTitleBarHeight() {
	return GetSystemMetrics(SM_CYCAPTION);
}

int SystemCalls::GetWindowBorderWidth() {
	return GetSystemMetrics(SM_CXBORDER);
}

int SystemCalls::GetWindowBorderHeight() {
    
	return GetSystemMetrics(SM_CYBORDER);
}

int SystemCalls::GetWindowPadding() {
    return GetSystemMetrics(SM_CXPADDEDBORDER);
}

Vector2i SystemCalls::GetScreenSize() {
	return Vector2i(GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN));
}
