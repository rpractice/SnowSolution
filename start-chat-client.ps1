pushd

cd API

Start-Process -FilePath "bin\Release\netcoreapp3.1\API.exe"

cd ..\Client


Start-Process -FilePath "bin\Release\netcoreapp3.1\Client.exe"
Start-Process -FilePath "bin\Release\netcoreapp3.1\Client.exe"


popd