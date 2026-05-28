using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlLabelElement` cmdlet.
#>
Describe "New-HtmlLabelElement" {
	It 'should support the "for" attribute' {
		label -For MyID | Should -BeExactly '<label for="MyID"></label>'
	}
}
