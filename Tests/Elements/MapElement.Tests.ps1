using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-MapElement` cmdlet.
#>
Describe "New-MapElement" {
	It 'should support the "name" attribute' {
		map -Name MyMap | Should -BeExactly '<map name="MyMap"></map>'
	}
}
