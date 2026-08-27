using namespace System.Collections
using namespace System.Diagnostics.CodeAnalysis
using namespace System.Web

<#
.SYNOPSIS
	Creates a new query string.
.INPUTS
	The name/value pairs providing the query parameters.
.OUTPUTS
	[string] The newly created query string.
.OUTPUTS
	[System.Collections.Specialized.NameValueCollection] The name/value collection representing the query string.
#>
function New-HtmlQueryString {
	[CmdletBinding(DefaultParameterSetName = "Default")]
	[OutputType([string])]
	[OutputType([System.Collections.Specialized.NameValueCollection])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The name/value pairs providing the query parameters.
		[Parameter(Position = 1, ValueFromPipeline)]
		[ValidateNotNull()]
		[IDictionary] $InputObject = @{},

		# The initial query string.
		[string] $Value = "",

		# Value indicating whether to include the question mark.
		[Parameter(ParameterSetName = "AddQuestionMark")]
		[switch] $AddQuestionMark,

		# Value indicating whether to return the name/value collection.
		[Parameter(ParameterSetName = "AsCollection")]
		[switch] $AsCollection
	)

	process {
		$collection = [HttpUtility]::ParseQueryString($Value ?? "")
		foreach ($key in $InputObject.Keys) { $collection.Add($key, $InputObject[$key] ?? [NullString]::Value) }

		if ($AsCollection) { Write-Output $collection -NoEnumerate }
		else {
			$queryString = $collection.ToString()
			$queryString -and $AddQuestionMark ? "?$queryString" : $queryString
		}
	}
}
