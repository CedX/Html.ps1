using namespace System.Text

<#
.SYNOPSIS
	Tests the features of the `Use-Layout` cmdlet.
#>
Describe "Use-Layout" {
	It "should render the specified HTML content inside the given layout" {
		$data = @{ AppName = "My Application"; Title = "The headline"; Year = 2025 }
		$html = layout "$PSScriptRoot/../Resources/Views/Layout.ps1" (& "$PSScriptRoot/../Resources/Views/Content.ps1" $data) -Data $data
		Should-BeLikeString '<!doctype html><html lang="*"><head>*<title>My Application</title>*' $html -CaseSensitive
		Should-BeLikeString '*<header>*<div class="ms-2">My Application</div>*</header>*' $html -CaseSensitive
		Should-BeLikeString '*<h1>The headline</h1><div class="alert alert-success">Welcome to my website!</div>*' $html -CaseSensitive
		Should-BeLikeString '*<footer class="text-center">Copyright &copy; 2025 - All rights reserved.</footer></body></html>' $html -CaseSensitive
	}
}

<#
.SYNOPSIS
	Renders the specified child content inside a layout.
.INPUTS
	The child content of the layout.
.OUTPUTS
	The rendered HTML view.
#>
function Use-HtmlLayout {
	[Alias("layout")]
	[CmdletBinding()]
	[OutputType([string])]
	param (
		# The path to the layout file.
		[Parameter(Mandatory, Position = 1)]
		[ValidateScript({ Test-Path $_ -PathType Leaf }, ErrorMessage = "The specified layout path does not exist.")]
		[string] $Path,

		# The child content of the layout.
		[Parameter(Mandatory, Position = 2, ValueFromPipeline)]
		[object] $Content,

		# The layout data.
		[ValidateNotNull()]
		[hashtable] $Data = @{}
	)

	process {
		$builder = [StringBuilder]::new()
		$output = $Content -is [scriptblock] ? (& $Content) : @($Content)
		foreach ($value in $output) { $builder.Append($value) | Out-Null }

		$childContent = $builder.ToString()
		& $Path $childContent $Data | Out-String -NoNewline
	}
}

<#
.SYNOPSIS
	Renders the specified view file as an HTML string.
.INPUTS
	The path to the view file.
.OUTPUTS
	The rendered HTML view.
#>
function Write-HtmlView {
	[CmdletBinding()]
	[OutputType([string])]
	param (
		# The path to the view file.
		[Parameter(Mandatory, Position = 1, ValueFromPipeline)]
		[ValidateScript({ Test-Path $_ -PathType Leaf }, ErrorMessage = "The specified view path does not exist.")]
		[string] $Path,

		# The view data.
		[ValidateNotNull()]
		[hashtable] $Data = @{}
	)

	process {
		& $Path $Data | Out-String -NoNewline
	}
}
