timeout 200
winget install ffmpeg --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.SDK.9 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.Framework. DeveloperPack_4 -v 4.7.2 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.NuGet --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.dotnet.runtime.8 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
echo 245.67>> \\host.lan\Data\\test-output.log
timeout 10
start cmd /k "C:\OEM\runTest.bat"