using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OptgroupElement` cmdlet.
#>
Describe "New-OptgroupElement" {
	It 'should support the "disabled" attribute' {
		$expected = '<optgroup disabled label="MyOptiongroup"></optgroup>', '<optgroup label="MyOptiongroup" disabled></optgroup>'
		$expected | Should-ContainCollection (optgroup -Disabled -Label MyOptiongroup)
	}

	It 'should support the "label" attribute' {
		optgroup -Label MyOptiongroup | Should-BeString '<optgroup label="MyOptiongroup"></optgroup>' -CaseSensitive
	}
}
