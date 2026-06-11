using namespace AngleSharp.Html
using namespace System.IO

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
