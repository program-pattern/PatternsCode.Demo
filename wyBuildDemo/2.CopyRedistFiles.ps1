$binDirectory = ".\App1\App1\bin\Release"
$distDirectory = ".\redist"
$currentDistDirectory = $distDirectory+"\current"

& xcopy $binDirectory $currentDistDirectory /E /U /Y

$updateExeFile=$currentDistDirectory+"\wyUpdate.exe"
$updateClientfile=$currentDistDirectory+"\client.wyc"
& del $updateExeFile
& del $updateClientfile 

$distVersion = Read-Host "Enter current version:"

$versionDistDirectory = $distDirectory+"\"+$distVersion
New-Item -Path $versionDistDirectory -ItemType "directory"

& xcopy $currentDistDirectory $versionDistDirectory /E /Y