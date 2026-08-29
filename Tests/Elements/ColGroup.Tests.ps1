using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ColgroupElement` cmdlet.
#>
Describe "New-ColgroupElement" {
	It 'should support the "span" attribute' -ForEach 1, 25 {
		Should-BeString "<colgroup span=""$_""></colgroup>" (colgroup -Span $_) -CaseSensitive
	}
}
