timeout 200
winget install ffmpeg --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.SDK.9 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.Framework.DeveloperPack_4 -v 4.7.2 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.NuGet --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.dotnet.runtime.8 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
echo 245.67>> \\host.lan\Data\\test-output.log
timeout 10
cd C:\OEM\GuiTestingLibrary_Tests
"C:\Program Files\dotnet\dotnet.exe" test 
"C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
start cmd /c "C:\Users\Docker\AppData\Local\Microsoft\WinGet\Links\ffmpeg.exe -f gdigrab -framerate 30 -i desktop \\host.lan\Data\\desktop-output.mkv -nostdin > \\host.lan\Data\\ffmpeg-output.log "
"C:\Program Files\dotnet\dotnet.exe" test 
"C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
