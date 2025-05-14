#pragma once
#include <cmath>
#include <sstream>
#include "Vector2f.h"
class Vector2i
{
public:
    int x;
    int y;

    Vector2i(int x = 0, int y = 0) : x(x), y(y) {}

    float Length() const {
        return sqrt(static_cast<float>(x * x + y * y));
    }

    bool Equals(const Vector2i& other) const {
        return x == other.x && y == other.y;
    }

    bool operator==(const Vector2i& other) const {
        return Equals(other);
    }

    bool operator!=(const Vector2i& other) const {
        return !Equals(other);
    }

    std::string ToString() const {
        std::ostringstream oss;
        oss << "[" << x << ";" << y << "]";
        return oss.str();
    }

    int Area() const {
        return x * y;
    }

    Vector2i operator+(const Vector2i& other) const {
        return Vector2i(x + other.x, y + other.y);
    }

    Vector2i operator-(const Vector2i& other) const {
        return Vector2i(x - other.x, y - other.y);
    }

    Vector2i operator/(int scalar) const {
        return Vector2i(x / scalar, y / scalar);
    }

    Vector2i operator/(const Vector2i& other) const {
        return Vector2i(x / other.x, y / other.y);
    }

    explicit operator Vector2f() const;
};

