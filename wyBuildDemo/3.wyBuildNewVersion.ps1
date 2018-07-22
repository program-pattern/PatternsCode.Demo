$redistVersion = Read-Host "Enter current version:"

$wyBuildCmd = "C:\Program Files (x86)\wyBuild\wyBuild.cmd.exe"
$wyBuildProject = ".\wyBuild\App1.wyp" 

#create versionized wyBuild files list
$templateFile = ".\wyBuild\Versions\template.xml"
$versionFile = ".\wyBuild\Versions\v"+$redistVersion+".xml"
(Get-Content $templateFile).Replace('$version',$redistVersion) | out-file $versionFile -encoding utf8  

#build updates
$redistDirectory = ".\redist"
$redistVersionDirectory = $redistDirectory + "\" + $redistVersion + "\"
$redistCurrentDirectory = $redistDirectory + "\current"

& $wyBuildCmd  $wyBuildProject -add="Versions\v$redistVersion.xml" /bwu
& copy .\output\wyUpdate\client.wyc $redistVersionDirectory
& copy .\output\wyUpdate\wyUpdate.exe $redistVersionDirectory

& $wyBuildCmd  $wyBuildProject /bwu /bu
& copy .\output\wyUpdate\client.wyc $redistVersionDirectory
& copy .\output\wyUpdate\wyUpdate.exe $redistVersionDirectory
& copy .\output\wyUpdate\client.wyc $redistCurrentDirectory
& copy .\output\wyUpdate\wyUpdate.exe $redistCurrentDirectory