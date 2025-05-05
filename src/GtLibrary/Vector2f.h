#pragma once
#include <cmath>
class Vector2f
{
public:
	float x;
	float y;

	Vector2f() : x(0), y(0) {}
	Vector2f(float x, float y) : x(x), y(y) {}
	float Length() const {
		return std::sqrt(x * x + y * y);
	}
};

inline Vector2f operator-(const Vector2f& lhs, const Vector2f& rhs) {
	return Vector2f(lhs.x - rhs.x, lhs.y - rhs.y);
}