using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlAreaElement` cmdlet.
#>
Describe "New-HtmlAreaElement" {
	It 'should support the "shape" and "coords" attributes' {
		$area = area -Href Index.html -Shape circle -Coords 100, 200, 64.7
		$area | Should -BeLikeExactly "<area *"
		$area | Should -BeLikeExactly '* href="Index.html"*'
		$area | Should -BeLikeExactly '* shape="circle"*'
		$area | Should -BeLikeExactly '* coords="100,200,64.7"*'
		$area | Should -BeLikeExactly "*>"
	}
}
