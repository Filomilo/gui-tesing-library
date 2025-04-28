#pragma once
public ref class ScreenShot_CS
{
private:
	GTScreenshot* native;
public:
	ScreenShot_CS(std::shared_ptr<GTScreenshot> screen)
	{
		native = screen.get();
	}
	~ScreenShot_CS()
	{
		delete native;
	}
};

