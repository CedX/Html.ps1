using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SvgElement` cmdlet.
#>
Describe "New-SvgElement" {

	It 'should support the "preserveAspectRatio" attribute' {
		svg -PreserveAspectRatio "xMaxYMin slice" | Should -BeExactly '<svg preserveAspectRatio="xMaxYMin slice"></svg>'
	}

	It 'should support the "viewBox" attribute' {
		svg -ViewBox 0, 0, 256, 128 | Should -BeExactly '<svg viewBox="0 0 256 128"></svg>'
	}

	It 'should support the "width" and "height" attributes' {
		svg -Width 320 -Height 200 | Should -BeIn '<svg width="320" height="200"></svg>', '<svg height="200" width="320"></svg>'
	}

	It 'should support the "x" and "y" attributes' {
		svg -X 640 -Y 480 | Should -BeIn '<svg x="640" y="480"></svg>', '<svg y="480" x="640"></svg>'
	}

	It "should allow inner content" {
		$content = '<circle cx="25" cy="25" r="20" />'
		svg $content | Should -BeExactly "<svg>$content</svg>"
	}
}
