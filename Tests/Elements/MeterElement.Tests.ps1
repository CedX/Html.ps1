using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-MeterElement` cmdlet.
#>
Describe "New-MeterElement" {
	It 'should support the "min" and "max" attributes' {
		meter -Min -100 -Max 200 | Should -BeIn '<meter min="-100" max="200"></meter>', '<meter max="200" min="-100"></meter>'
	}

	It 'should support the "low" and "high" attributes' {
		meter -Low 50 -High 150 | Should -BeIn '<meter low="50" high="150"></meter>', '<meter high="150" low="50"></meter>'
	}
}
