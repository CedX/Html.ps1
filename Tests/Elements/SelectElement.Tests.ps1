using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SelectElement` cmdlet.
#>
Describe "New-SelectElement" {
	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		selectTag -AutoComplete $_ | Should -BeExactly "<select autocomplete=""$($_ -join " ")""></select>"
	}

	It 'should support the "disabled" attribute' {
		selectTag -Disabled | Should -BeExactly '<select disabled></select>'
	}

	It 'should support the "multiple" attribute' {
		selectTag -Multiple | Should -BeExactly '<select multiple></select>'
	}

	It 'should support the "required" attribute' {
		selectTag -Required | Should -BeExactly '<select required></select>'
	}

	It 'should support the "size" attribute' -ForEach 0, 2, 5 {
		selectTag -Size $_ | Should -BeExactly "<select size=""$_""></select>"
	}
}
