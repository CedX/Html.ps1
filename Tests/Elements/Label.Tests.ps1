using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-LabelElement` cmdlet.
#>
Describe "New-LabelElement" {
	It 'should support the "for" attribute' {
		label -For MyID | Should-BeString '<label for="MyID"></label>' -CaseSensitive
	}
}
