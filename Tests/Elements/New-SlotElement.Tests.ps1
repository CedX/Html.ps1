using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SlotElement` cmdlet.
#>
Describe "New-SlotElement" {
	It 'should support the "name" attribute' {
		Should-BeString '<slot name="MyMap"></slot>' (slot -Name MyMap) -CaseSensitive
	}
}
