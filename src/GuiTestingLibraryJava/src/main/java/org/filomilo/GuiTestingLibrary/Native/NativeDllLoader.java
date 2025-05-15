package org.filomilo.GuiTestingLibrary.Native;

//import lombok.extern.slf4j.Slf4j;

import java.net.URL;
//@Slf4j
public class NativeDllLoader {

    static boolean loaded=false;
    static  public void LoadDll(){
        if(!loaded)
        {
            try{
                URL resource = NativeDllLoader.class.getClassLoader().getResource("Gui-testing-lib-java.dll");
//                log.info("Loading Gui-testing-lib-java.dll:: "+ resource.getPath());
                System.load(resource.getPath());
                loaded=true;
            }
            catch(Exception e){
//                log.error(e.toString());
            }
        }

    }
}
