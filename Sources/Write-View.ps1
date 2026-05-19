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
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[ValidateScript({ Test-Path $_ -PathType Leaf }, ErrorMessage = "The specified view path does not exist.")]
		[string] $Path,

		# The view data.
		[hashtable] $Data
	)

	process {
		$Data ? (& $Path $Data) : (& $Path) | Out-String -NoNewline
	}
}
