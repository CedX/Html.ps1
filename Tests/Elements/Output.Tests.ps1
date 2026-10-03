using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OutputElement` cmdlet.
#>
Describe "New-OutputElement" {
	It 'should support the "for" attribute' {
		output 123 -For MyID1, MyID2 | Should-BeString '<output for="MyID1 MyID2">123</output>' -CaseSensitive
	}

	It 'should support the "form" attribute' {
		output -Form MyForm | Should-BeString '<output form="MyForm"></output>' -CaseSensitive
	}
}
