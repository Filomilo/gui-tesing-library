#pragma once
#include "Vector2f.h"
#include "Vector2i.h"
#include "GTProcess.h"

#include "Color.h"
class GTWindow
{
public:
    GTWindow() = default;

    
    Vector2i GetPosition() const;
    bool DoesExist() const;
    std::string GetName() const;
    bool IsMinimized() const;

   
    std::shared_ptr<GTWindow> MoveWindow(const Vector2i& offset);
    std::shared_ptr<GTWindow> Minimize();
    std::shared_ptr<GTWindow> Maximize();
    std::shared_ptr<GTProcess> GetProcessOfWindow();
    std::shared_ptr<GTWindow> Close();
    std::shared_ptr<GTWindow> SetWindowSize(int x, int y) ;
    std::shared_ptr<GTWindow> SetPosition(int x, int y);
    std::shared_ptr<GTWindow> BringUpFront();
    std::shared_ptr<GTWindow> SizeShouldBe(const Vector2i& vector2I);
    std::shared_ptr<GTWindow> ShouldWindowExist(bool v);
    std::shared_ptr<GTWindow> KillProcess();

    std::shared_ptr<GTWindow> ShouldBeMinimized(bool state);
    std::string GetWindowName() const;

    Vector2i GetWindowContentPosition() const;
    Vector2i GetWindowContentSize() const;

    Color GetContentPixelColorAt(const Vector2i& position) const;
    Color GetContentPixelColorAt(const Vector2f& relativePosition) const;
    std::shared_ptr<GTWindow> ContentPixelAtShouldBeColor(const Vector2i& position, const Color& color) ;
    std::shared_ptr<GTWindow> CenterWindow();
    std::shared_ptr<GTWindow> WindowNameShouldBe(const std::string& title);
    std::shared_ptr<GTWindow> ContentPixelAtShouldBeColor(const Vector2f& sliderColorCheckPosition, const Color& colorShouldBe, int errorPass);

};

