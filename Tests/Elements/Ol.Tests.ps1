using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OlElement` cmdlet.
#>
Describe "New-OlElement" {
	It 'should support the "reversed" attribute' {
		Should-BeString "<ol reversed></ol>" (ol -Reversed) -CaseSensitive
	}

	It 'should support the "type" attribute' -ForEach 1, A, a, I, i {
		Should-BeString "<ol type=""$_""></ol>" (ol -Type $_) -CaseSensitive
	}
}
