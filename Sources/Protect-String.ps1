using namespace System.Text.Encodings.Web

<#
.SYNOPSIS
	Encodes a string using the specified character encoding.
.INPUTS
	The string to encode.
.OUTPUTS
	The encoded string.
#>
function Protect-HtmlString {
	[Alias("esc")]
	[CmdletBinding()]
	[OutputType([string])]
	param (
		# The string to encode.
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[AllowEmptyString()]
		[AllowNull()]
		[string] $Value,

		# The character encoding to use.
		[ValidateSet("Html", "Url")]
		[string] $Encoding = "Html"
	)

	begin {
		$encoder = $Encoding -eq "Url" ? [UrlEncoder]::Default : [HtmlEncoder]::Default
	}

	process {
		$encoder.Encode($Value ?? "")
	}
}
