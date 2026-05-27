using namespace AngleSharp.Html
using namespace System.Diagnostics.CodeAnalysis
using namespace System.IO
using namespace System.Text
using namespace System.Text.Encodings.Web

<#
.SYNOPSIS
	Formats an HTML string with inserted indents.
.INPUTS
	The HTML string to format.
.OUTPUTS
	The formatted HTML string.
#>
function Format-HtmlString {
	[CmdletBinding()]
	[OutputType([string])]
	param (
		# The HTML string to format.
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[AllowEmptyString()]
		[AllowNull()]
		[string] $Value,

		# Value indicating whether the formatter should operate within the context of a complete HTML document.
		[switch] $AsDocument
	)

	begin {
		$formatter = [PrettyMarkupFormatter]::new()
		$parser = [Parser.HtmlParser]::new()
	}

	process {
		if (-not $Value) { return "" }

		$writer = [StringWriter]::new()
		if ($AsDocument) {
			$document = $parser.ParseDocument($Value)
			$document.ToHtml($writer, $formatter)
			$document.Dispose()
		}
		else {
			$document = $parser.ParseDocument("")
			foreach ($node in $parser.ParseFragment($Value, $document.Body)) { $node.ToHtml($writer, $formatter) }
			$document.Dispose()
		}

		$html = $writer.ToString().TrimStart("`n")
		$writer.Close()
		$html
	}
}

<#
.SYNOPSIS
	Creates a new document type declaration.
.INPUTS
	The value of the document type.
.OUTPUTS
	The rendered document type declaration.
#>
function New-HtmlDocumentType {
	[Alias("doctype")]
	[CmdletBinding()]
	[OutputType([string])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The value of the document type.
		[Parameter(Position = 0, ValueFromPipeline)]
		[string] $Value = "html"
	)

	process {
		"<!doctype $([string]::IsNullOrWhiteSpace($Value) ? "html" : $Value)>"
	}
}

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
		[Parameter(Mandatory, Position = 0)]
		[ValidateScript({ Test-Path $_ -PathType Leaf }, ErrorMessage = "The specified layout path does not exist.")]
		[string] $Path,

		# The child content of the layout.
		[Parameter(Mandatory, Position = 1, ValueFromPipeline)]
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
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
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
