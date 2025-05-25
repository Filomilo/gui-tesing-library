#include "pch.h"
#include "Helpers.h"

using namespace std::chrono;
void Helpers::ensureTrue(std::function<bool()> func, const std::string& mes) {
    bool state = false;
    auto start = std::chrono::steady_clock::now();
    long timeout = GtConfiguration::GetInstance()->GetTimeout();
    while (!state) {
        state = func();
        if (!state) {
            std::this_thread::sleep_for(std::chrono::milliseconds(10));
        }
        else {
            break;
        }
        auto now = std::chrono::steady_clock::now();
        auto elapsed = std::chrono::duration_cast<std::chrono::milliseconds>(now - start).count();

        if (elapsed > timeout) {
            throw std::runtime_error("Did not reach state within max time ::: " + mes);
        }

      
    }
}