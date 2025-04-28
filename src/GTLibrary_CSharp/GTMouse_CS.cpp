#include "GTMouse_CS.h"
#include "Converters.h"

void GTMouse_CS::MoveMouse(Vector2i_CS^ offset)
{
	native->MoveMouse(Converters::Vector2iCSToVector2i(offset));
}

void GTMouse_CS::SetPosition(Vector2i_CS^ position)
{
	native->SetPosition(Converters::Vector2iCSToVector2i(position));
}

void GTMouse_CS::ClickLeft()
{
	native->ClickLeft();
}

void GTMouse_CS::ClickRight()
{
	native->ClickRight();

}

void GTMouse_CS::ClickMiddle()
{
	native->ClickMiddle();

}

void GTMouse_CS::PressLeft()
{
	native->PressLeft();
}

void GTMouse_CS::PressMiddle()
{
	native->PressMiddle();
}

void GTMouse_CS::PressRight()
{
	native->PressRight();

}

void GTMouse_CS::ReleaseLeft()
{
	native->PressLeft();

}

void GTMouse_CS::ReleaseMiddle()
{
	native->PressMiddle();

}

void GTMouse_CS::ReleaseRight()
{
	native->ReleaseRight();


}

void GTMouse_CS::Scroll(int scrollValue)
{
	native->Scroll(scrollValue);

}

void GTMouse_CS::SetPositionRelativeToWindow(GTWindow_CS^ window, Vector2i_CS^ position)
{
	native->SetPositionRelativeToWindow(Converters::WidnowCsToWindow(window), Converters::Vector2iCSToVector2i(position));
}

void GTMouse_CS::SetPositionRelativeToWindow(GTWindow_CS^ window, Vector2f_CS^ position)
{
	native->SetPositionRelativeToWindow(Converters::WidnowCsToWindow(window), Converters::Vector2fCSToVector2f(position));

}

void GTMouse_CS::PositionShouldBe(Vector2i_CS^ pos, int errorDistance)
{
	native->PositionShouldBe(Converters::Vector2iCSToVector2i(pos),errorDistance);

}

void GTMouse_CS::MoveMouseTo(Vector2i_CS^ newRedSliderPosition)
{
	native->MoveMouse(Converters::Vector2iCSToVector2i(newRedSliderPosition));

}

void GTMouse_CS::MoveMouseRelativeToWindowTo(GTWindow_CS^ window, Vector2i_CS^ position)
{
	native->MoveMouseRelativeToWindowTo(Converters::WidnowCsToWindow(window), Converters::Vector2iCSToVector2i(position));
}

void GTMouse_CS::MoveMouseRelativeToWindowTo(GTWindow_CS^ window, Vector2f_CS^ position)
{
	native->MoveMouseRelativeToWindowTo(Converters::WidnowCsToWindow(window), Converters::Vector2fCSToVector2f(position));

}
Vector2f_CS^ GTMouse_CS::GetPositionRelativeToWindow(GTWindow_CS^ window)
{
	return Converters::Vector2fToVector2fCS(native->GetPositionRelativeToWindow(Converters::WidnowCsToWindow(window)));
}

void GTMouse_CS::PositionRelativeToWindowShouldBe(GTWindow_CS^ window, Vector2f_CS^ position, float errorDistance)
{
	native->PositionRelativeToWindowShouldBe(Converters::WidnowCsToWindow(window), Converters::Vector2fCSToVector2f(position), errorDistance);
}