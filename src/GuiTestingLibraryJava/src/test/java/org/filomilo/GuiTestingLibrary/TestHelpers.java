package org.filomilo.GuiTestingLibrary;

import lombok.extern.slf4j.Slf4j;
import org.filomilo.GuiTestingLibrary.Native.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import static org.junit.jupiter.api.Assertions.*;

@Slf4j
public class TestHelpers {
    private static final Logger log = LoggerFactory.getLogger(TestHelpers.class);

    public static void CloseExampleGui()
    {
        if (JGTSystem.getInstance().FindTopWindowByName("Hello!") == null)
            return;
        try
        {
            JGTSystem.getInstance().WindowOfNameShouldExist("Hello!");
            JGTWindow window = JGTSystem.getInstance().FindTopWindowByName("Hello!");
            JGTProcess gtRocess = window.GetProcessOfWindow();
            assertDoesNotThrow(() ->
                    {
                            gtRocess.kill();
        });
            window.Close();
            window.KillProcess();
        }
        catch (Exception ex)
        {
            log.error(ex.getMessage(), ex);

        }

    }

    public static JGTWindow OpenExampleGui() {
        long prevActionDleay = JGTConfiguration .getInstance().GetActionDelay();
        JGTConfiguration .getInstance().SetActionDelay(500);
        JGTProcess gtRocess = JGTSystem.getInstance().StartProcess(
                "java -jar ..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
        );
        assertTrue(gtRocess.isAlive());

         JGTSystem.getInstance()
                .WindowOfNameShouldExist("Hello!");
        JGTWindow window=  JGTSystem.getInstance()
                .FindTopWindowByName("Hello!");
        assertNotNull(window);
        window    .SetWindowSize(1280, 720);
        window       .CenterWindow();
        window     .BringUpFront();
        JGTVector2i size=new JGTVector2i(1280, 720);
        window     .SizeShouldBe(size);;
        JGTConfiguration .getInstance().SetActionDelay(prevActionDleay);

        return window;
    }

    public class  RelativePostions
    {
        public static JGTVector2f windowNameINputPos = new JGTVector2f(0.25f, 0.24f);
        public static JGTVector2f ChangeWindowTitleButtonPositon = new JGTVector2f(0.21f, 0.35f);
        public static JGTVector2f TextAreaInput = new JGTVector2f(0.21f, 0.55f);
        public static JGTVector2f ColorSwitcherColorTest = new JGTVector2f(0.21f, 0.66f);
        public static JGTVector2f ColorSwitcherGreenButton = new JGTVector2f(0.21f, 0.9f);
        public static JGTVector2f ColorSwitcherBlackButton =
                ColorSwitcherGreenButton.plus(new JGTVector2f(0, -0.06f)) ;
        public static JGTVector2f ColorSwitcherWhiteButton =
                ColorSwitcherBlackButton.plus(new JGTVector2f(0, -0.06f))  ;

        public static JGTVector2f SliderColorCheckPostion = new JGTVector2f(0.355f, 0.10f);
        public static JGTVector2f RedSliderStartPostion = new JGTVector2f(0.355f, 0.19f);
        public static JGTVector2f RedSliderEndPostion = new JGTVector2f(0.652f, 0.19f);
        public static JGTVector2f GreenSliderStartPostion = new JGTVector2f(0.355f, 0.26f);
        public static JGTVector2f GreenSliderEndPostion = new JGTVector2f(0.652f, 0.26f);
        public static JGTVector2f BlueSliderStartPostion = new JGTVector2f(0.355f, 0.33f);
        public static JGTVector2f BlueSliderEndPostion = new JGTVector2f(0.652f, 0.33f);
        public static float ColorSliderLength =
                BlueSliderEndPostion.getX() - BlueSliderStartPostion.getX() ;
    }


}
