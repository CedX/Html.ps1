using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SvgElement` cmdlet.
#>
Describe "New-SvgElement" {

	It 'should support the "preserveAspectRatio" attribute' {
		Should-BeString '<svg preserveAspectRatio="xMaxYMin slice"></svg>' (svg -PreserveAspectRatio "xMaxYMin slice") -CaseSensitive
	}

	It 'should support the "viewBox" attribute' {
		Should-BeString '<svg viewBox="0 0 256 128"></svg>' (svg -ViewBox 0, 0, 256, 128) -CaseSensitive
	}

	It 'should support the "width" and "height" attributes' {
		'<svg width="320" height="200"></svg>', '<svg height="200" width="320"></svg>' | Should-ContainCollection (svg -Width 320 -Height 200)
	}

	It 'should support the "x" and "y" attributes' {
		'<svg x="640" y="480"></svg>', '<svg y="480" x="640"></svg>' | Should-ContainCollection (svg -X 640 -Y 480)
	}

	It "should allow inner content" {
		$content = '<circle cx="25" cy="25" r="20" />'
		Should-BeString "<svg>$content</svg>" (svg $content) -CaseSensitive
	}
}
