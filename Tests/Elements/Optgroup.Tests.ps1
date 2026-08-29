using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-OptGroupElement` cmdlet.
#>
Describe "New-OptGroupElement" {
	It 'should support the "disabled" attribute' {
		Should-BeString "<optgroup disabled></optgroup>" (optgroup -Disabled) -CaseSensitive
	}

	It 'should support the "label" attribute' {
		Should-BeString '<optgroup label="MyOptiongroup"></optgroup>' (optgroup -Label MyOptiongroup) -CaseSensitive
	}
}
