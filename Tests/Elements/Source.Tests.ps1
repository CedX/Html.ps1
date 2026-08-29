using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SourceElement` cmdlet.
#>
Describe "New-SourceElement" {
	It 'should support the "src" and "type" attributes' {
		'<source src="Video.webm" type="video/webm">', '<source type="video/webm" src="Video.webm">' | Should-ContainCollection (source -Src Video.webm -Type video/webm)
	}

	It 'should support the "srcset" and "media" attributes' {
		'<source media="(width > 600px)" srcset="Image.webp">', '<source srcset="Image.webp" media="(width > 600px)">' | Should-ContainCollection (source -SrcSet Image.webp -Media "(width > 600px)")
	}
}
