using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-QueryString` cmdlet.
#>
Describe "New-QueryString" {
	It "should create a query string from the specified hash table" -ForEach @(
		@{ Value = $null; Parameters = @{}; Expected = "" }
		@{ Value = ""; Parameters = [ordered]@{ Foo = "Bar"; Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = [ordered]@{ Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
	) {
		Should-BeString $expected (New-HtmlQueryString $parameters -Value $value) -CaseSensitive
	}

	It "should create a name/value collection from the specified hash table" -ForEach @(
		@{ Value = $null; Parameters = @{}; Expected = "" }
		@{ Value = ""; Parameters = [ordered]@{ Foo = "Bar"; Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = [ordered]@{ Baz = ""; Qux = $null }; Expected = "Foo=Bar&Baz=" }
	) {
		$collection = New-HtmlQueryString $parameters -Value $value -AsCollection
		Should-BeString $expected $collection.ToString() -CaseSensitive
	}

	It "should add a question mark if required" -ForEach @(
		@{ Value = $null; Parameters = @{}; Expected = "" }
		@{ Value = ""; Parameters = [ordered]@{ Foo = "Bar"; Baz = ""; Qux = $null }; Expected = "?Foo=Bar&Baz=" }
		@{ Value = "?Foo=Bar"; Parameters = [ordered]@{ Baz = ""; Qux = $null }; Expected = "?Foo=Bar&Baz=" }
	) {
		Should-BeString $expected (New-HtmlQueryString $parameters -Value $value -AddQuestionMark) -CaseSensitive
	}
}
