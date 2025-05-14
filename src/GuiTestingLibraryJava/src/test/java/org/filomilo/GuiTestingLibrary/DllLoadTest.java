package org.filomilo.GuiTestingLibrary;


import lombok.extern.java.Log;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.Assertions;

import java.net.URL;

@Slf4j
class DllLoadTest {

    @Test
    public void LoadDll() {

        URL resource = DllLoadTest.class.getClassLoader().getResource("Gui-testing-lib-java.dll");
        log.info("Loading Gui-testing-lib-java.dll:: "+ resource.getPath());
        org.junit.jupiter.api.Assertions.assertDoesNotThrow(() -> {
            System.load(resource.getPath());
        });
    }


}

