using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TdElement` cmdlet.
#>
Describe "New-TdElement" {
	It 'should support the "colspan" and "rowspan" attributes' {
		'<td colspan="1" rowspan="3"></td>', '<td rowspan="3" colspan="1"></td>' | Should-ContainCollection (td -ColSpan 1 -RowSpan 3)
	}

	It 'should support the "headers" attribute' {
		Should-BeString '<td headers="tid1 tid2"></td>' (td -Headers tid1, tid2) -CaseSensitive
	}
}
