using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ThElement` cmdlet.
#>
Describe "New-ThElement" {
	It 'should support the "colspan" and "rowspan" attributes' {
		'<th colspan="1" rowspan="3"></th>', '<th rowspan="3" colspan="1"></th>' | Should-ContainCollection (th -ColSpan 1 -RowSpan 3)
	}

	It 'should support the "headers" attribute' {
		Should-BeString '<th headers="tid1 tid2"></th>' (th -Headers tid1, tid2) -CaseSensitive
	}

	It 'should support the "scope" attribute' -ForEach col, colgroup, row, rowgroup {
		Should-BeString "<th scope=""$_""></th>" (th -Scope $_) -CaseSensitive
	}
}
