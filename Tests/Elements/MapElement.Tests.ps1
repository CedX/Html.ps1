using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlMapElement` cmdlet.
#>
Describe "New-HtmlMapElement" {
	It 'should support the "name" attribute' {
		map -Name MyMap | Should -BeExactly '<map name="MyMap"></map>'
	}
}
