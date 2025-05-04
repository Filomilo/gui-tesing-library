#include "pch.h"
#include "Helpers.h"
#include "Configuration.h"


void AwaitTrue(std::function<bool()> func, const std::string& mes = "") {
    bool state = false;
    auto start = std::chrono::steady_clock::now();

    while (!state) {
        auto now = std::chrono::steady_clock::now();
        auto elapsed = std::chrono::duration_cast<std::chrono::milliseconds>(now - start).count();

        if (elapsed > Configuration::GetInstance()->GetTimeout()) {
            throw std::runtime_error("Did not reach state within max time ::: " + mes);
        }

        state = func();
        if (!state) {
            std::this_thread::sleep_for(std::chrono::milliseconds(100));
        }
    }
}