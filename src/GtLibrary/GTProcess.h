#pragma once
#include "pch.h"
#include <string>
#include <vector>
#include <memory>
#include "GTWindow.h"
class GTWindow;
class GTProcess {
public:
    virtual ~GTProcess() = default;

  std::string GetName() const;
  bool IsAlive() const ;
  std::vector<std::shared_ptr<GTWindow>> GetWindowsOfProcess() const;
  long GetRamUsage() const ;
  void Kill();
};