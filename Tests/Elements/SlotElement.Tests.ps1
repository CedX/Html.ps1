using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlSlotElement` cmdlet.
#>
Describe "New-HtmlSlotElement" {
	It 'should support the "name" attribute' {
		slot -Name MyMap | Should -BeExactly '<slot name="MyMap"></slot>'
	}
}
