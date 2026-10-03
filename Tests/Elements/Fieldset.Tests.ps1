using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-FieldsetElement` cmdlet.
#>
Describe "New-FieldsetElement" {
	It 'should support the "disabled" attribute' {
		fieldset -Disabled | Should-BeString "<fieldset disabled></fieldset>" -CaseSensitive
	}

	It 'should support the "form" attribute' {
		fieldset -Form MyForm | Should-BeString '<fieldset form="MyForm"></fieldset>' -CaseSensitive
	}
}
