package org.filomilo.GuiTestingLibrary;


import lombok.extern.java.Log;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.Assertions;

@Log
class DllLoadTest {

    @Test
    public void LoadDll() {
        log.info("test");
        org.junit.jupiter.api.Assertions.assertDoesNotThrow(() -> {
            System.load("D:\\proejcts\\gui-tesing-library\\gui-tesing-library\\src\\GuiTestingLibraryJava\\src\\main\\resources\\Gui-testing-lib-java.dll");

        });
    }


}

