cd C:\OEM\GuiTestingLibrary_Tests
DotNet test 
DotNet test >> \\host.lan\Data\\dotnet-output.log
start cmd /c "ffmpeg -f gdigrab -framerate 30 -i desktop output.mkv -nostdin > \\host.lan\Data\\ffmpeg-output.log "
DotNet test 
DotNet test >> \\host.lan\Data\\dotnet-output.log
