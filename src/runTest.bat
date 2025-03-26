cd C:\OEM\GuiTestingLibrary_Tests
"C:\Program Files\dotnet\dotnet.exe" test 
"C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
"C:\Program Files\dotnet\dotnet.exe" test 
"C:\Program Files\dotnet\dotnet.exe" test >> \\host.lan\Data\\dotnet-output.log
"C:\Program Files\dotnet\dotnet.exe" dotnet restore >> \\host.lan\Data\\dotnet.log
"C:\Program Files\dotnet\dotnet.exe" dotnet add package Lombok.NET --version 2.4.1 >> \\host.lan\Data\\dotnet.log
"C:\Program Files\dotnet\dotnet.exe" dotnet add package System.Numerics.Vectors --version 4.1.6  >> \\host.lan\Data\\dotnet.log

"C:\Program Files\dotnet\dotnet.exe" dotnet test --logger "trx;LogFileName=\\host.lan\Data\\test-results.xml" >> \\host.lan\Data\\test.log
echo "fin" >> \\host.lan\Data\\fin