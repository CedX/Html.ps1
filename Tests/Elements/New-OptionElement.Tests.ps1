using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OptionElement` cmdlet.
#>
Describe "New-OptionElement" {
	It 'should support the "disabled" and "selected" attributes' {
		Should-BeString "<option disabled></option>" (option -Disabled) -CaseSensitive
		Should-BeString "<option selected></option>" (option -selected) -CaseSensitive
	}

	It 'should support the "label" and "value" attributes' -ForEach @(
		@{ Label = "Option #1"; Value = "" }
		@{ Label = "Option #2"; Value = "FooBar" }
	) {
		"<option label=""$label"" value=""$value""></option>", "<option value=""$value"" label=""$label""></option>" | Should-ContainCollection (option -Label $label -Value $value)
	}
}
