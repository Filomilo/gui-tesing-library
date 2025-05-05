#pragma once
#include "pch.h"
#include <string>
#include <vector>
#include <memory>
#include "Windows.h"
#include "GTWindow.h"
class GTWindow;
class GTProcess {
private:
    HANDLE handle;
public:
    ~GTProcess() = default;
	GTProcess(HANDLE handle) : handle(handle) {}

  std::wstring GetName() const;
  bool IsAlive() const ;
  std::vector<std::shared_ptr<GTWindow>> GetWindowsOfProcess() const;
  long GetRamUsage() const ;
  void Kill();
};