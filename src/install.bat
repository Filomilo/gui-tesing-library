timeout 100
taskkill /f /im explorer.exe
winget install ffmpeg --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Chocolatey --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
choco upgrade chocolatey  --accept-package-agreements >> \\host.lan\Data\\chocko-output.log
winget install Oracle.JDK.21 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.SDK.9 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.Framework.DeveloperPack_4 -v 4.7.2 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.NuGet --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.dotnet.runtime.8 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
set PATH="C:\Program Files\Common Files\Oracle\Java\javapath";%PATH% 
start /max cmd /c "C:\OEM\runTest.bat"


 

