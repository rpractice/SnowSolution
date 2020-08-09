pushd

cd API

Start-Process -FilePath "bin\Release\netcoreapp3.1\API.exec"

cd ..\Client


Start-Process -FilePath "bin\Release\netcoreapp3.1\Client.exec"
Start-Process -FilePath "bin\Release\netcoreapp3.1\Client.exec"


popd