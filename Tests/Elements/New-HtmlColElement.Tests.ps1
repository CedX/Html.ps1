using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlColElement` cmdlet.
#>
Describe "New-HtmlColElement" {
	It 'should support the "span" attribute' -ForEach 1, 25 {
		col -Span $_ | Should -BeExactly "<col span=""$_"">"
	}
}
