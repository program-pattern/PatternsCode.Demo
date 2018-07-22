$redistVersion = Read-Host "Enter current version:"

$binDirectory = ".\App1\App1\bin\Release"
$redistDirectory = ".\redist"
$redistCurrentDirectory = $redistDirectory+"\current"
$redistVersionDirectory = $redistDirectory+"\"+$redistVersion

& xcopy $binDirectory $redistCurrentDirectory /E /U /Y

$updateExeFile=$redistCurrentDirectory+"\wyUpdate.exe"
$updateClientfile=$redistCurrentDirectory+"\client.wyc"
# & del $updateExeFile
# & del $updateClientfile 

New-Item -Path $redistVersionDirectory -ItemType "directory"
& xcopy $redistCurrentDirectory $redistVersionDirectory /E /Y