using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DialogElement` cmdlet.
#>
Describe "New-DialogElement" {
	It 'should support the "closedby" attribute' -ForEach any, closerequest, none {
		dialog -ClosedBy $_ | Should-BeString "<dialog closedby=""$_""></dialog>" -CaseSensitive
	}

	It 'should support the "open" attribute' {
		dialog -Open | Should-BeString '<dialog open></dialog>' -CaseSensitive
	}
}
