using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OutputElement` cmdlet.
#>
Describe "New-OutputElement" {
	It 'should support the "for" attribute' {
		Should-BeString '<output for="MyID1 MyID2">123</output>' (output 123 -For MyID1, MyID2) -CaseSensitive
	}

	It 'should support the "form" attribute' {
		Should-BeString '<output form="MyForm"></output>' (output -Form MyForm) -CaseSensitive
	}
}
