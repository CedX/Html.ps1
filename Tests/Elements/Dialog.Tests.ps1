using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DialogElement` cmdlet.
#>
Describe "New-DialogElement" {
	It 'should support the "closedby" attribute' -ForEach any, closerequest, none {
		Should-BeString "<dialog closedby=""$_""></dialog>" (dialog -ClosedBy $_) -CaseSensitive
	}

	It 'should support the "open" attribute' {
		Should-BeString '<dialog open></dialog>' (dialog -Open) -CaseSensitive
	}
}
