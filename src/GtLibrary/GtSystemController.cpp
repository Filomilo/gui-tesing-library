#include "pch.h"
#include "GtSystemController.h"

std::shared_ptr<GtSystemController> GtSystemController::Instance()
{
    if (!_gtSystem) {
        _gtSystem = std::shared_ptr<GtSystemController>(new GtSystemController());

    }
    return _gtSystem;
}
std::vector<std::shared_ptr<GTWindow>> GtSystemController::FindWindowByName(const std::string& name)
{
    return std::vector<std::shared_ptr<GTWindow>>();
}

std::vector<std::shared_ptr<GTProcess>> GtSystemController::FindProcessByName(const std::string& name)
{
    return std::vector<std::shared_ptr<GTProcess>>();
}

std::shared_ptr<GTWindow> GtSystemController::FindTopWindowByName(const std::string& name)
{
    return std::shared_ptr<GTWindow>();
}

std::shared_ptr<GTSystem> GtSystemController::WindowOfNameShouldExist(const std::string& name)
{
    return std::shared_ptr<GTSystem>();
}

std::vector<std::shared_ptr<GTProcess>> GtSystemController::GetActiveProcesses()
{
    return std::vector<std::shared_ptr<GTProcess>>();
}

std::vector<std::shared_ptr<GTWindow>> GtSystemController::GetActiveWindows()
{
    return std::vector<std::shared_ptr<GTWindow>>();
}

std::string GtSystemController::GetClipBoardContent()
{
    return std::string();
}

std::shared_ptr<GTProcess> GtSystemController::StartProcess(const std::string& commandString)
{
    return std::shared_ptr<GTProcess>();
}

GTSystemVersion GtSystemController::GetOsVersion() const
{
    return GTSystemVersion();
}

GTSystemVersion GtSystemController::GetSystemVersion()
{
    return GTSystemVersion();
}

int GtSystemController::GetWindowTitleBarHeight()
{
    return 0;
}

int GtSystemController::GetWindowBorderWidth()
{
    return 0;
}

int GtSystemController::GetWindowBorderHeight()
{
    return 0;
}

int GtSystemController::GetWindowPadding()
{
    return 0;
}

Vector2i GtSystemController::GetScreenSize()
{
    return Vector2i();
}
