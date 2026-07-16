using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DetailsElement` cmdlet.
#>
Describe "New-DetailsElement" {
	It 'should support the "name" attribute' {
		Should-BeString '<details name="MyGroup"></details>' (details -Name MyGroup) -CaseSensitive
	}

	It 'should support the "open" attribute' {
		Should-BeString '<details open></details>' (details -Open) -CaseSensitive
	}
}
