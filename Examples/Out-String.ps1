<#
.SYNOPSIS
	Renders an HTML document from the given PowerShell script.
#>
using module Belin.Html

$title = "My Application"
$viewPath = Join-Path $PSScriptRoot ../Resources/Views -Resolve

$content = & "$viewPath/Content.ps1" @{ Heading = $title } | Out-String
& "$viewPath/Layout.ps1" $content @{ Title = $title } | Out-String
