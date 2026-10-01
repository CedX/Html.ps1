@{
	ModuleVersion = "5.0.0"
	PowerShellVersion = "7.6"
	RootModule = "Binaries/Belin.Html.dll"

	Author = "Cédric Belin <cedx@outlook.com>"
	CompanyName = "Cedric-Belin.fr"
	Copyright = "© Cédric Belin"
	Description = "PowerShell cmdlets for rendering HTML documents."
	GUID = "3c16800c-921e-4c31-9fc3-00052d2f30ba"

	AliasesToExport = @()
	FunctionsToExport = @()
	VariablesToExport = @()

	CmdletsToExport = @(
		"New-HtmlDataUri"
		"New-HtmlDocumentType"
		# "New-HtmlQueryString"
		# "Protect-HtmlString"
		# "Use-HtmlLayout"
		# "Write-HtmlView"
	)

	RequiredModules = @(
		@{ ModuleName = "Belin.FSharp"; ModuleVersion = "10.1.401" }
	)

	PrivateData = @{
		PSData = @{
			LicenseUri = "https://github.com/CedX/Html.ps1/blob/main/License.md"
			ProjectUri = "https://github.com/CedX/Html.ps1"
			ReleaseNotes = "https://github.com/CedX/Html.ps1/releases"
			Tags = "html", "renderer", "template", "templating", "web"
		}
	}
}
