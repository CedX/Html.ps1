using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SlotElement` cmdlet.
#>
Describe "New-SlotElement" {
	It 'should support the "name" attribute' {
		slot -Name MyMap | Should-BeString '<slot name="MyMap"></slot>' -CaseSensitive
	}
}
