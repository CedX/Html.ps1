using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OptgroupElement` cmdlet.
#>
Describe "New-OptgroupElement" {
	It 'should support the "disabled" attribute' {
		optgroup -Disabled | Should -BeExactly "<optgroup disabled></optgroup>"
	}

	It 'should support the "label" attribute' {
		optgroup -Label MyOptiongroup | Should -BeExactly '<optgroup label="MyOptiongroup"></optgroup>'
	}
}
