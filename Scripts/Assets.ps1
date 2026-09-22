using namespace System.Collections.Generic

"Deploying the assets..."
$cmdletTemplate = Get-Content Resources/CmdletTemplate.cs -Raw
$cmdletsToExport = [List[string]]::new([string[]] @("New-HtmlCustomElement"))

New-Item Sources/Generated -Force -ItemType Directory | Out-Null
(Import-PowerShellDataFile Resources/HtmlElements.psd1).Elements | ForEach-Object {
	$parameters = @{
		Alias = (Get-Alias $_.Tag -ErrorAction Ignore) ? "$($_.Tag)Tag" : $_.Tag
		CapitalizedTag = [char]::ToUpperInvariant($_.Tag[0]) + $_.Tag.Substring(1)
		IsVoid = $_.IsVoid.ToString().ToLowerInvariant()
		Tag = $_.Tag
	}

	$cmdletsToExport.Add("New-Html$($parameters.CapitalizedTag)Element")
	if (Test-Path "Sources/Elements/$($parameters.CapitalizedTag).cs") { continue }

	$content = $cmdletTemplate
	$parameters.Keys | ForEach-Object { $content = $content -replace "{$_}", $parameters.$_ }
	Set-Content "Sources/Generated/$($parameters.CapitalizedTag).g.cs" $content -NoNewline
}

$cmdletsToExport.Sort()
$cmdlets = ($cmdletsToExport | ForEach-Object { "`t`t""$_""" }) -join [Environment]::NewLine
$content = (Get-Content Html.psd1 -Raw) -replace "CmdletsToExport = @\([^)]+\)", "CmdletsToExport = @(`n$cmdlets`n`t)"
Set-Content Html.psd1 $content -NoNewline
