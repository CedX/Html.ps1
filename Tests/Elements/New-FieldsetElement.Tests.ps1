using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-FieldsetElement` cmdlet.
#>
Describe "New-FieldsetElement" {
	It 'should support the "disabled" attribute' {
		Should-BeString "<fieldset disabled></fieldset>" (fieldset -Disabled) -CaseSensitive
	}

	It 'should support the "form" attribute' {
		Should-BeString '<fieldset form="MyForm"></fieldset>' (fieldset -Form MyForm) -CaseSensitive
	}
}
