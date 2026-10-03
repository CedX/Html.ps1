using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-LiElement` cmdlet.
#>
Describe "New-LiElement" {
	It 'should support the "value" attribute' {
		li -Value 123 | Should-BeString '<li value="123"></li>' -CaseSensitive
	}
}
