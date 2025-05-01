#include "pch.h"
#include "SystemCalls.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include <windows.h>
#include "GtSystemVersion.h"
#include "GTScreenshot.h"

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

int SystemCalls::StartProcess(const std::string& commandString) {
    return 0;
}

std::string SystemCalls::GetClipBoardContent() {
    return "";
}

std::vector<int> SystemCalls::GetActiveWindows() {
    return {};
}

std::vector<int> SystemCalls::FindWindowByName(const std::string& name) {
    return {};
}

std::vector<int> SystemCalls::FindProcessByName(const std::string& name) {
    return {};
}

std::vector<int> SystemCalls::GetActiveProcesses() {
    return {};
}


void SystemCalls::WindowOfNameShouldExist(const std::string& name) {
    
}

int SystemCalls::GetWindowTitleBarHeight() {
    return ::GetSystemMetrics(SM_CYCAPTION);

}

int SystemCalls::GetWindowBorderWidth() {
    return ::GetSystemMetrics(SM_CXFRAME);
}

int SystemCalls::GetWindowBorderHeight() {
    
    return ::GetSystemMetrics(SM_CYFRAME);

}

int SystemCalls::GetWindowPadding() {
    
    return ::GetSystemMetrics(SM_CXPADDEDBORDER);
}

Vector2i SystemCalls::GetScreenSize() {
    return { ::GetSystemMetrics(SM_CXSCREEN), ::GetSystemMetrics(SM_CYSCREEN) };

}
void SystemCalls::SetWindowPosition(int handle, const Vector2i& position) {
    ::SetWindowPos(reinterpret_cast<HWND>(handle), 0, position.x, position.y, 0, 0, SWP_NOSIZE);
}

void SystemCalls::SetWindowSize(int handle, const Vector2i& size) {
    ::SetWindowPos(reinterpret_cast<HWND>(handle), 0, 0, 0, size.x, size.y, SWP_NOMOVE);
}




long SystemCalls::GetRamUsageOfProcess(int handle) {
    return 0;
}

void SystemCalls::KillProcess(int handle) {
}

bool SystemCalls::IsProcesAlive(int handle) {
    return false;
}

Vector2i SystemCalls::GetWindowPostion(int handle) {
    return Vector2i(0, 0);
}

bool SystemCalls::DoesWindowExist(int handle) {
    return false;
}

std::string SystemCalls::GetWindowName(int handle) {

    return "";
}

bool SystemCalls::IsWindowMinimized(int handle) {
   
    return false;
}

void SystemCalls::MinizmizeWindow(int handle) {

}

void SystemCalls::MaximizeWindow(int handle) {
    
}

int SystemCalls::GetProcessOfWindow(int handle) {

    return -1;
}

void SystemCalls::CloseWindow(int handle) {

}



void SystemCalls::BringWindowUpFront(int handle) {

}

Color SystemCalls::GetPixelColorAt(int handle, const Vector2i& position) {

    return Color();
}

void SystemCalls::TypeText(const std::string& text) {

}

void SystemCalls::PressKey(Key key) {

}

void SystemCalls::ReleaseKey(Key key) {

}

void SystemCalls::ClickKey(Key key) {

}

Vector2i SystemCalls::GetMousePosition() {

    return Vector2i(0, 0);
}

void SystemCalls::MoveMouse(const Vector2i& offset) {
  
}

void SystemCalls::SetMousePosition(const Vector2i& position) {
 
}

void SystemCalls::ClickLeftMouse() {

}

void SystemCalls::ClickRightMouse() {
    
}

void SystemCalls::ClickMiddleMouse() {
    
}

void SystemCalls::PressLeftMouse() {
  
}

void SystemCalls::PressMiddleMouse() {

}

void SystemCalls::PressRightMouse() {
    
}

void SystemCalls::ReleaseLeftMouse() {

}

void SystemCalls::ReleaseMiddleMouse() {
 
}

void SystemCalls::ReleaseRightMouse() {

}

void SystemCalls::ScrollMouse(int scrollValue) {

}

void SystemCalls::MoveMouseTo(const Vector2i& position) {
   
}

GTScreenshot SystemCalls::GetScreenshot() {
    return GTScreenshot();
}
GTScreenshot SystemCalls::GetScreenshotRect(Vector2i postion, Vector2i size) {

    return GTScreenshot();
}