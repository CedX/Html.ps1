using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-QueryString` cmdlet.
#>
Describe "New-QueryString" {
	It "should create a query string from the specified hash table" -ForEach @(
		@{ Value = $null; Parameters = @{}; Expected = "" }
		@{ Value = ""; Parameters = [ordered]@{ Foo = "Bar"; Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = @{ Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = [ordered]@{ Baz = 123; Qux = $true }; Expected = "Foo=Bar&Baz=123&Qux=True" }
	) {
		$parameters | New-HtmlQueryString -Value $value | Should-BeString $expected -CaseSensitive
	}

	It "should create a name/value collection from the specified hash table" -ForEach @(
		@{ Value = $null; Parameters = @{}; Expected = "" }
		@{ Value = ""; Parameters = [ordered]@{ Foo = "Bar"; Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = @{ Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = [ordered]@{ Baz = 123; Qux = $true }; Expected = "Foo=Bar&Baz=123&Qux=True" }
	) {
		$collection = $parameters | New-HtmlQueryString -Value $value -AsCollection
		$collection.ToString() | Should-BeString $expected -CaseSensitive
	}

	It "should add a question mark if required" -ForEach @(
		@{ Value = $null; Parameters = @{}; Expected = "" }
		@{ Value = ""; Parameters = [ordered]@{ Foo = "Bar"; Baz = ""; Qux = $null }; Expected = "?Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = @{ Baz = ""; Qux = $null }; Expected = "?Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = [ordered]@{ Baz = 123; Qux = $true }; Expected = "?Foo=Bar&Baz=123&Qux=True" }
	) {
		$parameters | New-HtmlQueryString -Value $value -AddQuestionMark | Should-BeString $expected -CaseSensitive
	}
}
