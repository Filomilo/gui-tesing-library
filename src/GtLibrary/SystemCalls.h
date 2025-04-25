#pragma once
#pragma once
#include <string>
#include <vector>
#include <memory>
#include "GTSystemVersion.h"
#include "Vector2i.h"
#include "GTProcess.h"
#include "GTWindow.h"
#include "SystemCalls.h"
#include "ISystemCalls.h"
class SystemCalls: public ISystemCalls
{
public:
   SystemCalls() = default;

   GTSystemVersion GetOsVersion() override;
   Vector2i GetMaximizedWindowSize() override;
   GTSystemVersion GetSystemVersion() override;
   std::shared_ptr<GTProcess> StartProcess(const std::string& commandString) override;
   std::string GetClipBoardContent() override;

   std::vector<std::shared_ptr<GTWindow>> GetActiveWindows() override;
   std::vector<std::shared_ptr<GTWindow>> FindWindowByName(const std::string& name) override;
   std::vector<std::shared_ptr<GTProcess>> FindProcessByName(const std::string& name) override;
   std::vector<std::shared_ptr<GTProcess>> GetActiveProcesses() override;
   std::shared_ptr<GTWindow> FindTopWindowByName(const std::string& name) override;

   std::shared_ptr<ISystemCalls> WindowOfNameShouldExist(const std::string& name) override;

   int GetWindowTitleBarHeight() override;
   int GetWindowBorderWidth() override;
   int GetWindowBorderHeight() override;
   int GetWindowPadding() override;
   Vector2i GetScreenSize() override;
};

