using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TdElement` cmdlet.
#>
Describe "New-TdElement" {
	It 'should support the "colspan" and "rowspan" attributes' {
		td -ColSpan 1 -RowSpan 3 | Should -BeIn '<td colspan="1" rowspan="3"></td>', '<td rowspan="3" colspan="1"></td>'
	}

	It 'should support the "headers" attribute' {
		td -Headers tid1, tid2 | Should -BeExactly '<td headers="tid1 tid2"></td>'
	}
}
