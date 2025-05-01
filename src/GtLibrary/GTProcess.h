#pragma once
#include "pch.h"
#include <string>
#include <vector>
#include <memory>
#include "GTWindow.h"
class GTWindow;
class GTProcess {
private:
    int handle;
public:
    ~GTProcess() = default;
	GTProcess(int handle) : handle(handle) {}

  std::string GetName() const;
  bool IsAlive() const ;
  std::vector<std::shared_ptr<GTWindow>> GetWindowsOfProcess() const;
  long GetRamUsage() const ;
  void Kill();
};