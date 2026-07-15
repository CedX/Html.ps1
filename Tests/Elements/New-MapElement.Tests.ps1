using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-MapElement` cmdlet.
#>
Describe "New-MapElement" {
	It 'should support the "name" attribute' {
		Should-BeString '<map name="MyMap"></map>' (map -Name MyMap) -CaseSensitive
	}
}
