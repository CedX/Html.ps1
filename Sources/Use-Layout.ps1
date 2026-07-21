using namespace System.Text

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
