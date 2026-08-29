using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SelectElement` cmdlet.
#>
Describe "New-SelectElement" {
	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		Should-BeString "<select autocomplete=""$($_ -join " ")""></select>" (selectTag -AutoComplete $_) -CaseSensitive
	}

	It 'should support the "disabled" attribute' {
		Should-BeString '<select disabled></select>' (selectTag -Disabled) -CaseSensitive
	}

	It 'should support the "multiple" attribute' {
		Should-BeString '<select multiple></select>' (selectTag -Multiple) -CaseSensitive
	}

	It 'should support the "required" attribute' {
		Should-BeString '<select required></select>' (selectTag -Required) -CaseSensitive
	}

	It 'should support the "size" attribute' -ForEach 0, 2, 5 {
		Should-BeString "<select size=""$_""></select>" (selectTag -Size $_) -CaseSensitive
	}
}
