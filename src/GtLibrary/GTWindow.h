#pragma once
#include "pch.h"
#include "Vector2f.h"
#include "Vector2i.h"
#include "GTProcess.h"
#include "Color.h"
#include "GTSystem.h"
#include <string>
#include <memory>

class GTProcess;

class GTWindow
{
private:
    HWND handle;

public:
    GTWindow(HWND handle) {
        this->handle = handle;
    }

    
    Vector2i GetPosition() const;
    Vector2i GetSize() const;
    bool DoesExist() const;
    std::wstring GetName() const;
    bool IsMinimized() const;

   
    void MoveWindow(const Vector2i& offset);
    void Minimize();
    void Maximize();
    GTProcess* GetProcessOfWindow();
    void Close();
    void SetWindowSize(int x, int y) ;
    void SetPosition(int x, int y);
    void BringUpFront();
    void SizeShouldBe(const Vector2i& vector2I);
    void ShouldWindowExist(bool v);
    void KillProcess();

    void ShouldBeMinimized(bool state);
    std::wstring GetWindowName() const;

    Vector2i GetWindowContentPosition() const;
    Vector2i GetWindowContentSize() const;

    Color GetContentPixelColorAt(const Vector2i& position) const;
    Color GetContentPixelColorAt(const Vector2f& relativePosition) const;
    void ContentPixelAtShouldBeColor(const Vector2i& position, const Color& color) ;
    void CenterWindow();
    void WindowNameShouldBe(const std::wstring& title);
    void ContentPixelAtShouldBeColor(const Vector2f& sliderColorCheckPosition, const Color& colorShouldBe, int errorPass);
    HWND GetHandle();
    GTScreenshot* GetScreenshot();
    GTScreenshot* GetScreenshotRect(Vector2i position, Vector2i size);


    Color GetPixelColorAt(Vector2i position);

    void PixelAtShouldBeColor(Vector2i position, Color color);
};

