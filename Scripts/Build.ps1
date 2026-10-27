using module ./Tools.psm1
& "$PSScriptRoot/Assets.ps1"

Write-Information "Building the solution..."
Build-DotNetSolution ($Release ? "Release" : "Debug")
