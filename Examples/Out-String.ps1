<#
.SYNOPSIS
	Renders an HTML document from the given PowerShell script.
#>
Import-Module Belin.Html

$data = @{ AppName = "My Application"; Title = "Hello World!"; Year = (Get-Date).Year }
$viewPath = Join-Path $PSScriptRoot ../Resources/Views -Resolve

$content = & "$viewPath/Content.ps1" $data | Out-String -NoNewline
& "$viewPath/Layout.ps1" $content $data | Out-String
