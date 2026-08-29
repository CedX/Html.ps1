using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-LabelElement` cmdlet.
#>
Describe "New-LabelElement" {
	It 'should support the "for" attribute' {
		Should-BeString '<label for="MyID"></label>' (label -For MyID) -CaseSensitive
	}
}
