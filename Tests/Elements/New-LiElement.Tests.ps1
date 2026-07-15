using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-LiElement` cmdlet.
#>
Describe "New-LiElement" {
	It 'should support the "value" attribute' {
		Should-BeString '<li value="123"></li>' (li -Value 123) -CaseSensitive
	}
}
