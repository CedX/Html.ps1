using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-MeterElement` cmdlet.
#>
Describe "New-MeterElement" {
	It 'should support the "min" and "max" attributes' {
		'<meter min="-100" max="200"></meter>', '<meter max="200" min="-100"></meter>' | Should-ContainCollection (meter -Min -100 -Max 200)
	}

	It 'should support the "low" and "high" attributes' {
		'<meter low="50" high="150"></meter>', '<meter high="150" low="50"></meter>' | Should-ContainCollection (meter -Low 50 -High 150)
	}
}
