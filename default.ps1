﻿Framework "4.0"

Properties {
	$build_dir = Split-Path $psake.build_script_file
    $build_cfg = "Debug"
}

Task default -Depends Test

Task Deps {
	Exec { & "$build_dir\tools\nuget" install NUnit.Runners -Version "2.6.0.12051" -ExcludeVersion -OutputDirectory "$build_dir\tools" }
    
    Get-ChildItem "$build_dir\src\*\packages.config" -Exclude .nuget | ForEach-Object {
    	Write-Host "Downloading packages defined in $_"
    	Exec { & "$build_dir\tools\nuget" install $_ -OutputDirectory "$build_dir\lib" }
    }
}

Task Compile -Depends Deps {
	Exec { msbuild "$build_dir\src\SalesTax.sln" /t:Build /p:Configuration=$build_cfg /v:quiet /nologo }
}

Task Test -Depends Compile {
    $TestDlls = Get-ChildItem "$build_dir\src\*\bin\$build_cfg\*.Test.dll"
    Exec { & "$build_dir\tools\NUnit.Runners\tools\nunit-console.exe" /nologo /noresult /framework=4.0.30319 @TestDlls }
}

Task Clean {
	Exec { hg purge --all --repository $build_dir }
}
