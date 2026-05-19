using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DialogElement` cmdlet.
#>
Describe "New-DialogElement" {
	It 'should support the "closedby" attribute' -ForEach any, closerequest, none {
		dialog -ClosedBy $_ | Should -BeExactly "<dialog closedby=""$_""></dialog>"
	}

	It 'should support the "open" attribute' {
		dialog -Open | Should -BeExactly '<dialog open></dialog>'
	}
}
