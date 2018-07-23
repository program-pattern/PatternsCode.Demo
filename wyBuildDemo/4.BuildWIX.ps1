$redistVersion = Read-Host "Enter current version:"

$wixSolution = "WIX\App1WixDemo.sln"
& "$env:SystemRoot\Microsoft.NET\Framework\v4.0.30319\MsBuild" $wixSolution /t:Rebuild /p:Configuration=Release

$installersOutputDirectory = "Output\Installers\" + $redistVersion +"\"
New-Item -Path $installersOutputDirectory -ItemType "directory"

& COPY WIX\App1SetupProject\bin\Release\App1.msi $installersOutputDirectory
& COPY WIX\App1Bootstrapper\bin\Release\App1Bootstrapper.exe $installersOutputDirectory
