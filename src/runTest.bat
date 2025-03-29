start /min cmd /c "C:\Users\Docker\AppData\Local\Microsoft\WinGet\Links\ffmpeg.exe -f gdigrab -framerate 30 -i desktop \\host.lan\Data\\desktop-output.mkv -nostdin > \\host.lan\Data\\ffmpeg-output.log "
cd C:\OEM\GuiTestingLibrary_Tests
"C:\Users\Docker\AppData\Local\Microsoft\WinGet\Links\nuget.exe" restore ..\gui-tesing-library\gui-tesing-library.sln >> \\host.lan\Data\\nugetRestore.log
@REM "C:\Program Files\dotnet\dotnet.exe" test 
@REM "C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
@REM "C:\Program Files\dotnet\dotnet.exe" test 
@REM "C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
@REM "C:\Program Files\dotnet\dotnet.exe" dotnet restore >> \\host.lan\Data\\dotnet.log
@REM "C:\Program Files\dotnet\dotnet.exe" dotnet add package Lombok.NET --version 2.4.1 >> \\host.lan\Data\\dotnet.log
@REM "C:\Program Files\dotnet\dotnet.exe" dotnet add package System.Numerics.Vectors --version 4.1.6  >> \\host.lan\Data\\dotnet.log

"C:\Program Files\dotnet\dotnet.exe" dotnet test --logger "trx;LogFileName=\\host.lan\Data\\test-results.trx" >> \\host.lan\Data\\test.log
powershell -Command "(Get-Content \\host.lan\Data\\test-results.xml) -join \"`n\" | Set-Content \\host.lan\Data\\test-results.xml -NoNewline"
echo "fin" >> \\host.lan\Data\\fin