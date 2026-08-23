using namespace System.Diagnostics.CodeAnalysis
using namespace System.Net.Mime

<#
.SYNOPSIS
	Creates a data URI from the specified file or byte stream.
.INPUTS
	The path to a file to convert.
.OUTPUTS
	The newly created data URI.
#>
function New-HtmlDataUri {
	[CmdletBinding(DefaultParameterSetName = "Path")]
	[OutputType([uri])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The path to a file to convert.
		[Parameter(Mandatory, ParameterSetName = "Path", Position = 1, ValueFromPipeline)]
		[string] $Path,

		# The byte stream to convert.
		[Parameter(Mandatory, ParameterSetName = "Bytes", Position = 1)]
		[byte[]] $ByteStream,

		# The media type to associate with the data URI.
		[ValidateNotNullOrWhiteSpace()]
		[string] $MediaType = [MediaTypeNames]::Application::Octet
	)

	process {
		if ($Path) { $ByteStream = Get-Content $Path -AsByteStream }
		[uri]::new("data:$MediaType;base64,$([Convert]::ToBase64String($ByteStream))")
	}
}
