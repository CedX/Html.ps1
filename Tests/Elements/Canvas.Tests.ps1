using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-CanvasElement` cmdlet.
#>
Describe "New-CanvasElement" {
	It 'should support the "width" and "height" attributes' {
		canvas -Height 200 | Should-BeString '<canvas height="200"></canvas>' -CaseSensitive
		canvas -Width 460 | Should-BeString '<canvas width="460"></canvas>' -CaseSensitive
	}
}
