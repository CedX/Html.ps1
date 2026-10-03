using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ColgroupElement` cmdlet.
#>
Describe "New-ColgroupElement" {
	It 'should support the "span" attribute' -ForEach 1, 25 {
		colgroup -Span $_ | Should-BeString "<colgroup span=""$_""></colgroup>" -CaseSensitive
	}
}
