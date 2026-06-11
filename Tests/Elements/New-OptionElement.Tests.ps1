using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OptionElement` cmdlet.
#>
Describe "New-OptionElement" {
	It 'should support the "disabled" and "selected" attributes' {
		option -Disabled | Should -BeExactly "<option disabled></option>"
		option -selected | Should -BeExactly "<option selected></option>"
	}

	It 'should support the "label" and "value" attributes' -ForEach @(
		@{ Label = "Option #1"; Value = "" }
		@{ Label = "Option #2"; Value = "FooBar" }
	) {
		option -Label $label -Value $value | Should -BeIn "<option label=""$label"" value=""$value""></option>", "<option value=""$value"" label=""$label""></option>"
	}
}
