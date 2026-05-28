using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlCanvasElement` cmdlet.
#>
Describe "New-HtmlCanvasElement" {
	It 'should support the "width" and "height" attributes' {
		canvas -Height 200 | Should -BeExactly '<canvas height="200"></canvas>'
		canvas -Width 460 | Should -BeExactly '<canvas width="460"></canvas>'
	}
}
