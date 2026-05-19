using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ProgressElement` cmdlet.
#>
Describe "New-ProgressElement" {
	It 'should support the "max" and "value" attributes' {
		progress "70%" -Max 100 -Value 70 | Should -BeIn '<progress max="100" value="70">70%</progress>', '<progress value="70" max="100">70%</progress>'
	}
}
