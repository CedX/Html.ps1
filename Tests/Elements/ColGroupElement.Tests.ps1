using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ColGroupElement` cmdlet.
#>
Describe "New-ColGroupElement" {
	It 'should support the "span" attribute' -ForEach 1, 25 {
		colgroup -Span $_ | Should -BeExactly "<colgroup span=""$_""></colgroup>"
	}
}
