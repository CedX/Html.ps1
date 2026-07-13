using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-AreaElement` cmdlet.
#>
Describe "New-AreaElement" {
	It 'should support the "shape" and "coords" attributes' {
		$area = area -Href Index.html -Shape circle -Coords 100, 200, 64.7
		Should-BeLikeString "<area *" $area -CaseSensitive
		Should-BeLikeString '* href="Index.html"*' $area -CaseSensitive
		Should-BeLikeString '* shape="circle"*' $area -CaseSensitive
		Should-BeLikeString '* coords="100,200,64.7"*' $area -CaseSensitive
		Should-BeLikeString "*>" $area -CaseSensitive
	}
}
