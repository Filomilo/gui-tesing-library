timeout 100
winget install ffmpeg --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
start /min cmd /c "C:\Users\Docker\AppData\Local\Microsoft\WinGet\Links\ffmpeg.exe -f gdigrab -framerate 30 -i desktop \\host.lan\Data\\desktop-output.mkv -nostdin > \\host.lan\Data\\ffmpeg-output.log "
winget install Chocolatey --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Oracle.JDK.21 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.SDK.9 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.DotNet.Framework.DeveloperPack_4 -v 4.7.2 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.NuGet --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
winget install Microsoft.dotnet.runtime.8 --accept-source-agreements --accept-package-agreements >> \\host.lan\Data\\winget-output.log
set PATH="C:\Program Files\Common Files\Oracle\Java\javapath";%PATH% 
start /min cmd /c "C:\OEM\runTest.bat"


 

