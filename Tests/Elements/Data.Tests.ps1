using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DataElement` cmdlet.
#>
Describe "New-DataElement" {
	It 'should support the "value" attribute' -ForEach 123, "MY_KEY" {
		dataTag -Value $_ | Should-BeString "<data value=""$_""></data>" -CaseSensitive
	}
}
