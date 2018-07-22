$redistVersion = Read-Host "Enter current version:"

$wyBuildCmd = "C:\Program Files (x86)\wyBuild\wyBuild.cmd.exe"
$wyBuildProject = ".\wyBuild\App1.wyp" 

#create versionized wyBuild files list
$templateFile = ".\wyBuild\Versions\template.xml"
$versionFile = ".\wyBuild\Versions\v"+$redistVersion+".xml"
(Get-Content $templateFile).Replace('$version',$redistVersion) | out-file $versionFile -encoding utf8  

#build updates
$redistVersionDirectory = ".\redist\" + $redistVersion + "\"
& $wyBuildCmd  $wyBuildProject -add="Versions\v$redistVersion.xml" /bwu
& copy .\output\wyUpdate\client.wyc $redistVersionDirectory
& $wyBuildCmd  $wyBuildProject -add="Versions\v$redistVersion.xml" /bwu /bu
