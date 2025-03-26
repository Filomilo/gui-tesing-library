cd C:\OEM\GuiTestingLibrary_Tests
@REM "C:\Program Files\dotnet\dotnet.exe" test 
@REM "C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
@REM "C:\Program Files\dotnet\dotnet.exe" test 
@REM "C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
"C:\Program Files\dotnet\dotnet.exe" dotnet restore >> \\host.lan\Data\\dotnet.log
"C:\Program Files\dotnet\dotnet.exe" dotnet test --logger "trx;LogFileName=\\host.lan\Data\\test-results.xml" >> \\host.lan\Data\\test.log
echo "fin" >> \\host.lan\Data\\fin