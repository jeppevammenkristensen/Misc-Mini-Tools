properties {
	$BaseDir = Resolve-Path "..\"
	$SolutionFile = "$BaseDir\MiscMiniTools.sln"
	$SpecsForOutput = "$BaseDir\JsonConfiguration\bin\Debug"
	$ProjectPath = "$BaseDir\JsonConfiguration\JsonConfiguration.csproj"	
	$ArchiveDir = "$BaseDir\Deploy\Archive"

	$NuGetPackageName = "JConfig"

	$ZipFiles =  @("$SpecsForOutput\Moq.dll",
		"$SpecsForOutput\nunit.framework.dll",
		"$SpecsForOutput\SpecsFor.dll",
		"$SpecsForOutput\StructureMap.AutoMocking.dll",
		"$SpecsForOutput\StructureMap.dll",
		"$SpecsForOutput\Should.dll",
		"$SpecsForOutput\ExpectedObjects.dll")
	$ZipName = "JConfig.zip"
}

$framework = '4.5.1'

task default -depends Pack

task Build {
    exec { msbuild $SolutionFile }
}


task Pack -depends Build{
    exec { nuget pack "$projectpath" "-IncludeReferencedProjects" }
}

task PackAndCopyToLocal -depends Pack{
    robocopy .\ "$env:onedrive\LocalNuget" "*.nupkg" 
}