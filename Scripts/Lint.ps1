using module PSScriptAnalyzer
using module ./Cmdlets.psm1

"Performing the static analysis of source code..."
Invoke-FSharpLint Html.slnx -Configuration Configuration/FSharpLint.json
Invoke-ScriptAnalyzer $PSScriptRoot -Recurse
Test-ModuleManifest Html.psd1 | Out-Null
