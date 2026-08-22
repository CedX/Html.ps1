using namespace System.Net.Mime

<#
.SYNOPSIS
	Converts a file or a byte stream into a data URI.
.INPUTS
	The path to a file to convert.
.OUTPUTS
	The data URI corresponding to the specified file or byte stream.
#>
function ConvertTo-HtmlDataUri {
	[CmdletBinding(DefaultParameterSetName = "Path")]
	[OutputType([string])]
	[OutputType([uri])]
	param (
		# The path to a file to convert.
		[Parameter(Mandatory, ParameterSetName = "Path", Position = 1, ValueFromPipeline)]
		[string] $Path,

		# The byte stream to convert.
		[Parameter(Mandatory, ParameterSetName = "Bytes", Position = 1)]
		[byte[]] $ByteStream,

		# The media type to associate with the data URI.
		[string] $MediaType = [MediaTypeNames.Application]::Octet
	)

	process {
		if ($Path) { $ByteStream = Get-Content $Path -AsByteStream }
		[uri]::new("data:$MediaType;base64,$([Convert]::ToBase64String($ByteStream))")
	}
}
