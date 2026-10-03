using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-AreaElement` cmdlet.
#>
Describe "New-AreaElement" {
	It 'should support the "shape" and "coords" attributes' {
		$area = area -Href Index.html -Shape circle -Coords 100, 200, 64.7
		$area | Should-BeLikeString "<area *" -CaseSensitive
		$area | Should-BeLikeString '* href="Index.html"*' -CaseSensitive
		$area | Should-BeLikeString '* shape="circle"*' -CaseSensitive
		$area | Should-BeLikeString '* coords="100,200,64.7"*' -CaseSensitive
		$area | Should-BeLikeString "*>" -CaseSensitive
	}
}
