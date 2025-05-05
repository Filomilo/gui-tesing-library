#include "pch.h"
#include "SystemCalls.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include <windows.h>
#include "GtSystemVersion.h"
#include "GTScreenshot.h"
#include "Casters.h"
#include <iostream>
void pirintError() {
    DWORD errorCode = GetLastError();
    LPWSTR errorMsg = nullptr;
    FormatMessageW(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        errorCode,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPWSTR)&errorMsg,
        0,
        NULL
    );

    std::wcerr << L"failed. Error " << errorCode
        << L": " << (errorMsg ? errorMsg : L"Unknown error") << std::endl;

    if (errorMsg)
        LocalFree(errorMsg);
}



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

HANDLE _DuplicateHandle(HANDLE Origin) {
    HANDLE duplicatedHandle;
    if (!DuplicateHandle(
        GetCurrentProcess(),
        Origin,
        GetCurrentProcess(),
        &duplicatedHandle,
        0,
        FALSE,
        DUPLICATE_SAME_ACCESS)) {
    }
    return duplicatedHandle;
}

HANDLE SystemCalls::StartProcess(const std::string& commandString) {

        STARTUPINFOA si = { sizeof(STARTUPINFOA) }; PROCESS_INFORMATION pi;
    std::string cmd = commandString;
   char* cmdLine = &cmd[0];


    if (!CreateProcessA(
        nullptr,        
        cmdLine,        
        nullptr,        
        nullptr,        
        FALSE,          
        0,              
        nullptr,        
        nullptr,        
        &si,            
        &pi))           
    {
        pirintError();
    }

    DWORD exitCode = -1;


    HANDLE _hanlde = _DuplicateHandle(pi.hProcess);

    CloseHandle(pi.hThread);
    CloseHandle(pi.hProcess);
    IsProcesAlive(_hanlde);
    return _hanlde;
}

std::wstring SystemCalls::GetClipBoardContent() {
    throw std::exception("not implemdnerd");
    //return "";
}

std::vector<HWND> SystemCalls::GetActiveWindows() {
    return {};
}

std::vector<HWND> SystemCalls::FindWindowByName(const std::wstring& name) {
    return {};
}

std::vector<HANDLE> SystemCalls::FindProcessByName(const std::wstring& name) {
    return {};
}

std::vector<HANDLE> SystemCalls::GetActiveProcesses() {
    return {};
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
void SystemCalls::SetWindowPosition(HWND handle, const Vector2i& position) {
    ::SetWindowPos(handle, 0, position.x, position.y, 0, 0, SWP_NOSIZE);
}

void SystemCalls::SetWindowSize(HWND handle, const Vector2i& size) {
    ::SetWindowPos(handle, 0, 0, 0, size.x, size.y, SWP_NOMOVE);
}




long SystemCalls::GetRamUsageOfProcess(HANDLE handle) {
    return 0;
}

void SystemCalls::KillProcess(HANDLE handle) {
   BOOL res= TerminateProcess(handle,1);
}


bool SystemCalls::IsProcesAlive(HANDLE handle) {
    HANDLE hProcess = handle;

    if (hProcess == nullptr) {
        return false; 
    }

    DWORD exitCode = -1;


    if (GetExitCodeProcess(hProcess, &exitCode)) {
        return exitCode == STILL_ACTIVE;
    }
    else {
        pirintError();
    }

    return false;
}

Vector2i SystemCalls::GetWindowPostion(HWND handle) {
    RECT rect;
    GetWindowRect(handle, &rect);
    return Vector2i(rect.left, rect.top);
}

bool SystemCalls::DoesWindowExist(HWND handle) {
    return IsWindow(handle);
}

std::wstring SystemCalls::GetWindowName(HWND handle) {
    wchar_t buffer[256];
    GetWindowText(handle, buffer, 256);

    std::wstring wtext(buffer);
    return wtext;
}

bool SystemCalls::IsWindowMinimized(HWND handle) {
   
    return IsIconic(handle);
}

void SystemCalls::MinizmizeWindow(HWND handle) {
    ShowWindow(handle, SW_MINIMIZE);
}

void SystemCalls::MaximizeWindow(HWND handle) {
    ShowWindow(handle, SW_MAXIMIZE);
}

HANDLE SystemCalls::GetProcessOfWindow(HWND handle) {
    DWORD processId;
    if (!IsWindow(handle))
    {
        throw std::runtime_error("Not vlaid windwo handle");
    }
    GetWindowThreadProcessId(handle, &processId);
    HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, processId);
    return hProcess;
}

void SystemCalls::TerminateWindow(HWND handle) {
    CloseWindow(handle);
}



void SystemCalls::BringWindowUpFront(HWND handle) {
    HWND hwnd = handle;
    if (!IsWindow(handle))
    {
        throw std::runtime_error("Not vlaid windwo handle");
    }
    if (ShowWindow(hwnd, SW_SHOW)==0)
    {
        pirintError();
    }
    if (SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW)==0)
    {
        pirintError();
    }
    if (BringWindowToTop(hwnd)==0)
    {
        pirintError();
    }
  ;
}

Color SystemCalls::GetPixelColorAt(HWND handle, const Vector2i& position) {

    return Color();
}

void SystemCalls::TypeText(const std::wstring& text) {

}

void SystemCalls::PressKey(GTKey key) {

}

void SystemCalls::ReleaseKey(GTKey key) {

}

void SystemCalls::ClickKey(GTKey key) {

}

Vector2i SystemCalls::GetMousePosition() {

    POINT pt;
    if(!GetCursorPos(&pt)) {
        pirintError();
    }
    return Vector2i(pt.x, pt.y);
}

void SystemCalls::MoveMouse(const Vector2i& offset) {
        INPUT input = {};
        input.type = INPUT_MOUSE;
        input.mi.mouseData = 0;
        input.mi.dx = offset.x * (65536 / GetSystemMetrics(SM_CXSCREEN));
        input.mi.dy = offset.y * (65536 / GetSystemMetrics(SM_CYSCREEN));
        input.mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
        SendInput(1, &input, sizeof(input));
}

void SystemCalls::SetMousePosition(const Vector2i& position) {
    if (!SetCursorPos(position.x, position.y))
    {
        pirintError();
    }
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

HWND SystemCalls::FindTopWindowByName(const std::wstring& name) {
    return (HWND)nullptr;
}

Vector2i SystemCalls::GetSizeOfWindow(HWND handle) {
    RECT rect;
    GetWindowRect(handle, &rect);
        int width = rect.right - rect.left;
        int height = rect.bottom - rect.top;
        return Vector2i(width, height);

}

std::wstring  SystemCalls::GetProcesName(HANDLE handle)
{
    return L"";
}

std::vector<HWND> SystemCalls::GetWindowsOfProcess(HANDLE handle) {
    return {};
}