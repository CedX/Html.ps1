using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DetailsElement` cmdlet.
#>
Describe "New-DetailsElement" {
	It 'should support the "name" attribute' {
		details -Name MyGroup | Should -BeExactly '<details name="MyGroup"></details>'
	}

	It 'should support the "open" attribute' {
		details -Open | Should -BeExactly '<details open></details>'
	}
}
