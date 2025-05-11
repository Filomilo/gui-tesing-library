@echo off
setlocal

:: Define the source directory (adjust this as needed)
set SRC_DIR=F:\projects\gui-tesing-library\src\GuiTestingLibraryJava\src\main\java

:: Change to that directory
cd /d %SRC_DIR%

:: Create output directory for headers if needed
mkdir headers

:: Compile all .java files at once with JNI headers generation
javac -h headers org\filomilo\GuiTestingLibrary\Native\*.java org\filomilo\GuiTestingLibrary\*.java

endlocal
