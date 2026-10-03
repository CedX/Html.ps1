using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OlElement` cmdlet.
#>
Describe "New-OlElement" {
	It 'should support the "reversed" attribute' {
		ol -Reversed | Should-BeString "<ol reversed></ol>" -CaseSensitive
	}

	It 'should support the "type" attribute' -ForEach 1, A, a, I, i {
		ol -Type $_ | Should-BeString "<ol type=""$_""></ol>" -CaseSensitive
	}
}
