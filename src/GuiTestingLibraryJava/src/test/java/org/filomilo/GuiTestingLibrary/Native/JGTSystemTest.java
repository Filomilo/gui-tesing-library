package org.filomilo.GuiTestingLibrary.Native;

import org.filomilo.GuiTestingLibrary.TestHelpers;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;

class JGTSystemTest {

    @AfterEach
    public void tearDown() {
        TestHelpers.CloseExampleGui();
    }

    @Test
    void findWindowByName() {
    }

    @Test
    void findProcessByName() {
    }

    @Test
    void findTopWindowByName() {
    }

    @Test
    void windowOfNameShouldExist() {
    }

    @Test
    void getActiveProcesses() {
    }

    @Test
    void getActiveWindows() {
    }

    @Test
    void getClipBoardContent() {
    }

    @Test
    void startProcess() {
        JGTProcess gtRocess = JGTSystem.getInstance().StartProcess(
                "java -jar ..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
        );
        assertTrue(gtRocess.isAlive());
        assertDoesNotThrow(()->{
            gtRocess.kill();
        });



    }

    @Test
    void getOsVersion() {
    }

    @Test
    void getWindowTitleBarHeight() {
    }

    @Test
    void getWindowBorderWidth() {
    }

    @Test
    void getWindowBorderHeight() {
    }

    @Test
    void getWindowPadding() {
    }

    @Test
    void getScreenSize() {
    }

    @Test
    void getMaximizedWindowSize() {
    }
}