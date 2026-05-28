using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlColGroupElement` cmdlet.
#>
Describe "New-HtmlColGroupElement" {
	It 'should support the "span" attribute' -ForEach 1, 25 {
		colgroup -Span $_ | Should -BeExactly "<colgroup span=""$_""></colgroup>"
	}
}
