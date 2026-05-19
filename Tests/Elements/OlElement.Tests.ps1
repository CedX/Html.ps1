using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OlElement` cmdlet.
#>
Describe "New-OlElement" {
	It 'should support the "reversed" attribute' {
		ol -Reversed | Should -BeExactly "<ol reversed></ol>"
	}

	It 'should support the "type" attribute' -ForEach 1, A, a, I, i {
		ol -Type $_ | Should -BeExactly "<ol type=""$_""></ol>"
	}
}
