package org.filomilo.GuiTestingLibrary.Native;

import org.filomilo.GuiTestingLibrary.TestHelpers;
import org.junit.jupiter.api.Test;

import java.util.Random;

import static org.junit.jupiter.api.Assertions.*;
@FunctionalInterface
interface ColorSetter {
    void setColor(int r, int g, int b) throws InterruptedException;
}

class JGTMouseTest {




    @Test
    public void ColorSliderTest() throws InterruptedException {
        JGTWindow window = TestHelpers.OpenExampleGui();
      JGTConfiguration.getInstance().SetActionDelay(50);

        final JGTVector2f[] currRedSliderPostion = {TestHelpers.RelativePostions.RedSliderStartPostion};
        final JGTVector2f[] currGreenSliderPostion = {TestHelpers.RelativePostions.GreenSliderStartPostion};
        final JGTVector2f[] currBlueSliderPostion = {TestHelpers.RelativePostions.BlueSliderStartPostion};

        JGTColor initColor = window.GetContentPixelColorAt(
                TestHelpers.RelativePostions.SliderColorCheckPostion
        );
            assertTrue(initColor.Equals(JGTColor.Black));

        ColorSetter setColor = (int r, int g, int b) ->
        {
            float redOffset = (float)(
                    TestHelpers.RelativePostions.ColorSliderLength * (r / 255.0)
            );
            float greeOffset = (float)(
                    TestHelpers.RelativePostions.ColorSliderLength * (g / 255.0)
            );
            float blueOffset = (float)(
                    TestHelpers.RelativePostions.ColorSliderLength * (b / 255.0)
            );

            JGTVector2f newRedSliderPostion =
                    TestHelpers.RelativePostions.RedSliderStartPostion.add( new JGTVector2f(redOffset, 0f));
            JGTVector2f newGreenSliderPostion =
                    TestHelpers.RelativePostions.GreenSliderStartPostion.add(new JGTVector2f(greeOffset, 0));
            JGTVector2f newBlueSliderPostion =
                    TestHelpers.RelativePostions.BlueSliderStartPostion.add( new JGTVector2f(blueOffset, 0));
         assertTrue( newRedSliderPostion.getX() < TestHelpers.RelativePostions.RedSliderEndPostion.getX(),
                 "Red lisder move positn oshoudl be less then maximusm red slider postion, new positon [[{newRedSliderPostion}]] slider max [[{TestHelpers.RelativePostions.RedSliderEndPostion}]]"
                 );

            assertTrue(     newGreenSliderPostion.getX() < TestHelpers.RelativePostions.GreenSliderEndPostion.getX(),
                   "Green lisder move positn oshoudl be less then maximusm Green slider postion, new positon [[{newGreenSliderPostion}]] slider max [[{TestHelpers.RelativePostions.GreenSliderEndPostion}]]"
                    );
      assertTrue(              newBlueSliderPostion.getX() < TestHelpers.RelativePostions.BlueSliderEndPostion.getX(),
              "Blue lisder move positn oshoudl be less then maximusm Blue slider postion, new positon [[{newBlueSliderPostion}]] slider max [[{TestHelpers.RelativePostions.BlueSliderEndPostion}]]"
      );

            window.BringUpFront();
            JGTMouse.getInstance() .SetPositionRelativeToWindow(window, currRedSliderPostion[0]);
            JGTMouse.getInstance() .PressLeft();
            JGTMouse.getInstance() .MoveMouseRelativeToWindowTo(window, newRedSliderPostion);
            JGTMouse.getInstance() .ReleaseLeft();

            window.BringUpFront();
            JGTMouse.getInstance().SetPositionRelativeToWindow(
                    window,
                    currGreenSliderPostion[0]
            );
            JGTMouse.getInstance().PressLeft();
            JGTMouse.getInstance().MoveMouseRelativeToWindowTo(window, newGreenSliderPostion);
            JGTMouse.getInstance().ReleaseLeft();

            window.BringUpFront();
            JGTMouse.getInstance().SetPositionRelativeToWindow(window, currBlueSliderPostion[0]);
            JGTMouse.getInstance().PressLeft();
            JGTMouse.getInstance().MoveMouseRelativeToWindowTo(window, newBlueSliderPostion);
            JGTMouse.getInstance().ReleaseLeft();

            currRedSliderPostion[0] = newRedSliderPostion;
            currGreenSliderPostion[0] = newGreenSliderPostion;
            currBlueSliderPostion[0] = newBlueSliderPostion;

            JGTColor Colorshouldbe = new JGTColor(r, g, b);
            Thread.sleep(100);
            window
                    .BringUpFront();
            window .ContentPixelAtShouldBeColor(
                    TestHelpers.RelativePostions.SliderColorCheckPostion,
                    Colorshouldbe,
                    6
            );
            JGTColor currColor =
                    window
                    .GetContentPixelColorAt(TestHelpers.RelativePostions.SliderColorCheckPostion);
        assertTrue(currColor.getDiffrence(Colorshouldbe) < 6,
              "Color at postion [[{TestHelpers.RelativePostions.SliderColorCheckPostion}]] is not {Colorshouldbe} but [[{currColor}]], Difrence: {currColor.getDiffrence(Colorshouldbe)} ");
        };
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            int r = rnd.nextInt (0, 255);
            int g = rnd.nextInt(0, 255);
            int b = rnd.nextInt(0, 255);

            setColor.setColor (r, g, b);
        }
        Thread.sleep(5000);
        TestHelpers.CloseExampleGui();
    }

}