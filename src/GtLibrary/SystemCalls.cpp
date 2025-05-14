#include "pch.h"
#include "SystemCalls.h"
#include "SystemCalls.h"
#include "SystemCallsFactory.h"
#include <windows.h>
#include "GtSystemVersion.h"
#include "GTScreenshot.h"
#include "Casters.h"
#include <iostream>
#include <chrono>
#include <thread>
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
    std::wstring text;

    if (IsClipboardFormatAvailable(CF_UNICODETEXT))
    {
        if (OpenClipboard(nullptr))
        {
            HANDLE hData = GetClipboardData(CF_UNICODETEXT);
            if (hData != nullptr)
            {
                LPCWSTR pText = static_cast<LPCWSTR>(GlobalLock(hData));
                if (pText != nullptr)
                {
                    text = pText;
                    GlobalUnlock(hData);
                }
            }
            CloseClipboard(); 
        }
    }

    return text;
}


std::vector<HWND> SystemCalls::GetActiveWindows() {
    std::vector<HWND> windowHandles;

    EnumWindows([](HWND hwnd, LPARAM lParam) -> BOOL {
        std::vector<HWND>* handles = reinterpret_cast<std::vector<HWND>*>(lParam);
        if (IsWindowVisible(hwnd)) {
            int length = GetWindowTextLengthW(hwnd);
            if (length > 0) {
                handles->push_back(hwnd);
            }
        }
        return TRUE;
        }, reinterpret_cast<LPARAM>(&windowHandles));

    return windowHandles;
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
    AllowSetForegroundWindow(ASFW_ANY);
    if (!IsWindow(handle))
    {
        throw std::runtime_error("Not vlaid windwo handle");
    }


    

    DWORD windowThreadProcessId = GetWindowThreadProcessId(GetForegroundWindow(), LPDWORD(0));
    DWORD currentThreadId = GetCurrentThreadId();
    DWORD CONST_SW_SHOW = 5;
    AttachThreadInput(windowThreadProcessId, currentThreadId, true);
    BringWindowToTop(hwnd);
    ShowWindow(hwnd, CONST_SW_SHOW);
    if (ShowWindow(hwnd, SW_SHOW) == 0)
    {
        pirintError();
    }
    if (SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW) == 0)
    {
        pirintError();
    }
    if (BringWindowToTop(hwnd) == 0)
    {
        pirintError();
    }

    AttachThreadInput(windowThreadProcessId, currentThreadId, false);


}

Color SystemCalls::GetPixelColorAt(HWND handle, const Vector2i& position) {

    HDC hdc = GetDC(handle);
    COLORREF pixel = GetPixel(hdc, position.x, position.y);
    if (pixel == CLR_INVALID) {
        ReleaseDC(handle, hdc);
        pirintError();
        return Color(0, 0, 0); 
    }
    ReleaseDC(handle, hdc);

    int red = (int)(pixel & 0x000000FF);
    int green = (int)((pixel & 0x0000FF00) >> 8);
    int blue = (int)((pixel & 0x00FF0000) >> 16);
    Color col = Color(red, green, blue);
    return col;
}
void SimulateKeyPress(wchar_t key, HKL hkl) {

    SHORT vkCode = VkKeyScanExA(key, hkl); 
    BYTE keyCode = LOBYTE(vkCode); 
    BYTE shiftState = HIBYTE(vkCode);

   
    if (shiftState & 0x01) { 
        keybd_event(VK_SHIFT, 0, 0, 0);
    }

    keybd_event(keyCode, 0, 0, 0);
    keybd_event(keyCode, 0, KEYEVENTF_KEYUP, 0); 

    if (shiftState & 0x01) {
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0); 
    }
}
void SystemCalls::TypeText(const std::wstring& text) {
    HKL hkl = GetKeyboardLayout(0);
    for (size_t i = 0; i < text.length(); i++)
    {
        //std::this_thread::sleep_for(std::chrono::milliseconds(2));
        SimulateKeyPress(text[i], hkl);
    }
}

void SystemCalls::PressKey(GTKey key) {
    keybd_event(Casters::GTKeyToVK(key), 0, 0, 0);
}

void SystemCalls::ReleaseKey(GTKey key) {
 
    keybd_event(Casters::GTKeyToVK(key), 0, KEYEVENTF_KEYUP, 0);
}

void SystemCalls::ClickKey(GTKey key) {
    PressKey(key);
    ReleaseKey(key);
}

Vector2i SystemCalls::GetMousePosition() {

    POINT pt;
    if(!GetCursorPos(&pt)) {
        pirintError();
    }
    return Vector2i(pt.x, pt.y);
}



void SystemCalls::MoveMouse(const Vector2i& offset) {
    Vector2i currPos = GetMousePosition();
        INPUT input = {};
        input.type = INPUT_MOUSE;
        input.mi.mouseData = 0;
        int screenWidth = GetSystemMetrics(SM_CXSCREEN);
        int screenHeight = GetSystemMetrics(SM_CYSCREEN);

        double normalizedX = ((double)(currPos.x + offset.x)) * 65535.0 / (screenWidth - 1);
        double normalizedY = ((double)(currPos.y + offset.y)) * 65535.0 / (screenHeight - 1);

        input.mi.dx = static_cast<LONG>(normalizedX);
        input.mi.dy = static_cast<LONG>(normalizedY);   input.mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
        SendInput(1, &input, sizeof(input));
}

void SystemCalls::SetMousePosition(const Vector2i& position) {
    if (!SetCursorPos(position.x, position.y))
    {
        pirintError();
    }
}
void MouseClick(DWORD downFlag, DWORD upFlag) {
    INPUT input[2] = {};
    input[0].type = INPUT_MOUSE;
    input[0].mi.dwFlags = downFlag;
    input[1].type = INPUT_MOUSE;
    input[1].mi.dwFlags = upFlag;
    SendInput(2, input, sizeof(INPUT));
}
void SystemCalls::ClickLeftMouse() {
    MouseClick(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
}

void SystemCalls::ClickRightMouse() {
    MouseClick(MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP);
}

void SystemCalls::ClickMiddleMouse() {
    MouseClick(MOUSEEVENTF_MIDDLEDOWN, MOUSEEVENTF_MIDDLEUP);
}

void SystemCalls::PressLeftMouse() {
    MouseClick(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTDOWN);
}

void SystemCalls::PressMiddleMouse() {
    MouseClick(MOUSEEVENTF_MIDDLEDOWN, MOUSEEVENTF_MIDDLEDOWN);
}

void SystemCalls::PressRightMouse() {
    MouseClick(MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTDOWN);
}

void SystemCalls::ReleaseLeftMouse() {
    MouseClick(MOUSEEVENTF_LEFTUP, MOUSEEVENTF_LEFTUP);
}

void SystemCalls::ReleaseMiddleMouse() {
    MouseClick(MOUSEEVENTF_MIDDLEUP, MOUSEEVENTF_MIDDLEUP);
}

void SystemCalls::ReleaseRightMouse() {
    MouseClick(MOUSEEVENTF_RIGHTUP, MOUSEEVENTF_RIGHTUP);
}

void SystemCalls::ScrollMouse(int scrollValue) {

}

void SystemCalls::MoveMouseTo(const Vector2i& position) {
    INPUT input = {};
    input.type = INPUT_MOUSE;
    input.mi.mouseData = 0;
    int screenWidth = GetSystemMetrics(SM_CXSCREEN);
    int screenHeight = GetSystemMetrics(SM_CYSCREEN);

    double normalizedX = ((double)(position.x)) * 65535.0 / (screenWidth - 1);
    double normalizedY = ((double)(position.y)) * 65535.0 / (screenHeight - 1);

    input.mi.dx = static_cast<LONG>(normalizedX);
    input.mi.dy = static_cast<LONG>(normalizedY);   input.mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
    SendInput(1, &input, sizeof(input));
}


static GTScreenshot* HbitampToGtScreenShot(HBITMAP hbitmap) {
    BITMAP bmp;
    if (GetObject(hbitmap, sizeof(BITMAP), &bmp) == 0) {
        pirintError();
        throw std::runtime_error("Failed to retrieve bitmap info.");
    }

    int width = bmp.bmWidth;
    int height = bmp.bmHeight;

    BITMAPINFO bmi = {};
    bmi.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
    bmi.bmiHeader.biWidth = width;
    bmi.bmiHeader.biHeight = -height;
    bmi.bmiHeader.biPlanes = 1;
    bmi.bmiHeader.biBitCount = 24;   
    bmi.bmiHeader.biCompression = BI_RGB;

    int rowSize = ((width * 3 + 3) & ~3);
    std::vector<uint8_t> data(rowSize * height);

 
    HDC hdc = GetDC(nullptr);
    if (!GetDIBits(hdc, hbitmap, 0, height, data.data(), &bmi, DIB_RGB_COLORS)) {
        ReleaseDC(nullptr, hdc);
        pirintError();
        throw std::runtime_error("Failed to get bitmap bits.");
    }
    ReleaseDC(nullptr, hdc);
    std::vector< std::vector<Color>> pixels = std::vector< std::vector<Color>>();
    pixels.resize(height, std::vector<Color>(width));
    for (int y = 0; y < height; ++y) {
        const uint8_t* row = data.data() + y * rowSize;
        for (int x = 0; x < width; ++x) {
            Color c;
            c.b = row[x * 3 + 0];
            c.g = row[x * 3 + 1];
            c.r = row[x * 3 + 2];
            pixels[y][x] = c;
        }
    }
    return new GTScreenshot(pixels);
}

GTScreenshot* SystemCalls::GetScreenshot(HWND handle, Vector2i startPos, Vector2i size) {
    HDC hdcScreen = GetDC(handle);
    if (!hdcScreen) {
        pirintError();
        throw std::runtime_error("Failed to get screen DC");
    }
       

    HDC hdcMemDC = CreateCompatibleDC(hdcScreen);
    if (!hdcMemDC) {
        ReleaseDC(handle, hdcScreen);
        pirintError();
        throw std::runtime_error("Failed to create compatible DC");
    }

    HBITMAP hBitmap = CreateCompatibleBitmap(hdcScreen, size.x, size.y);
    if (!hBitmap) {
        DeleteDC(hdcMemDC);
        ReleaseDC(handle, hdcScreen);
        pirintError();

        throw std::runtime_error("Failed to create compatible bitmap");
    }

    HGDIOBJ hOld = SelectObject(hdcMemDC, hBitmap);

    BOOL res = BitBlt(
        hdcMemDC,
        0, 0,
        size.x, size.y,
        hdcScreen,
        startPos.x, startPos.y, 
        SRCCOPY
    );

    if (!res) {
        SelectObject(hdcMemDC, hOld);
        DeleteObject(hBitmap);
        DeleteDC(hdcMemDC);
        ReleaseDC(handle, hdcScreen);
        pirintError();
        throw std::runtime_error("BitBlt failed");
    }

    SelectObject(hdcMemDC, hOld);
    DeleteDC(hdcMemDC);
    ReleaseDC(handle, hdcScreen);

    return HbitampToGtScreenShot(hBitmap);
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