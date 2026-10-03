using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DetailsElement` cmdlet.
#>
Describe "New-DetailsElement" {
	It 'should support the "name" attribute' {
		details -Name MyGroup | Should-BeString '<details name="MyGroup"></details>' -CaseSensitive
	}

	It 'should support the "open" attribute' {
		details -Open | Should-BeString '<details open></details>' -CaseSensitive
	}
}
