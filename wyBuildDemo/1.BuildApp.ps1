$baseDirectory = ".\App1"
$projectFiles = "App1.sln" 

$msbuild = "C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$MSBuildLogger="/flp1:Append;LogFile=Build.log;Verbosity=Normal; /flp2:LogFile=BuildErrors.log;Verbosity=Normal;errorsonly"

$devenv = "C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe"

$action = "Y"

Clear-Host

foreach($projectFile in $projectFiles)
{
    if ($projectFile.EndsWith(".sln")) 
    {
        $projectFileAbsPath = "$baseDirectory\$projectFile"
        
        $filename = [System.IO.Path]::GetFileName($projectFile); 
        $action = "Y"  
        while($action -eq "Y") 
        {
            if(Test-Path $projectFileAbsPath) 
            {
                Write-Host "Building $projectFileAbsPath"
                & $msbuild $projectFileAbsPath /t:rebuild /p:Configuration=Release /fl "/flp1:logfile=$baseDirectory\msbuild.log;Verbosity=Normal;Append;" "/flp2:logfile=$baseDirectory\errors.txt;errorsonly;Append;"
                
                if($LASTEXITCODE -eq 0)
                {
                    Write-Host "Build SUCCESS" -ForegroundColor Green
#                   Clear-Host
                    break
                }
                else
                {
                    Write-Host "Build FAILED" -ForegroundColor Red
                    
                    $action = Read-Host "Enter Y to Fix then continue, N to Terminate, I to Ignore and continue the build"
                    
                    if($action -eq "Y")
                    {
                        & $devenv $projectFileAbsPath
                        wait-process -name devenv    
                    }
                    else 
                    {
                        if($action -eq "I")
                        {
                            Write-Host "Ignoring build failure..."
                            break
                        }
                        else
                        {
                            Write-Host "Terminating Build... Please restart the build once the issue is fixed." -ForegroundColor Red
                            break
                        }
                    }
                }
            }
            else
            {
                Write-Host "File does not exist : $projectFileAbsPath"
                Start-Sleep -s 5
                break
            }
        }
        
        if($action -eq "N")
        {
            break;
        }      
    }
}