using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ColElement` cmdlet.
#>
Describe "New-ColElement" {
	It 'should support the "span" attribute' -ForEach 1, 25 {
		col -Span $_ | Should -BeExactly "<col span=""$_"">"
	}
}
