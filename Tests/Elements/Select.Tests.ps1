using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SelectElement` cmdlet.
#>
Describe "New-SelectElement" {
	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		selectTag -AutoComplete $_ | Should-BeString "<select autocomplete=""$($_ -join " ")""></select>" -CaseSensitive
	}

	It 'should support the "disabled" attribute' {
		selectTag -Disabled | Should-BeString '<select disabled></select>' -CaseSensitive
	}

	It 'should support the "multiple" attribute' {
		selectTag -Multiple | Should-BeString '<select multiple></select>' -CaseSensitive
	}

	It 'should support the "required" attribute' {
		selectTag -Required | Should-BeString '<select required></select>' -CaseSensitive
	}

	It 'should support the "size" attribute' -ForEach 0, 2, 5 {
		selectTag -Size $_ | Should-BeString "<select size=""$_""></select>" -CaseSensitive
	}
}
