using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-SourceElement` cmdlet.
#>
Describe "New-SourceElement" {
	It 'should support the "src" and "type" attributes' {
		source -Src Video.webm -Type video/webm | Should -BeIn '<source src="Video.webm" type="video/webm">', '<source type="video/webm" src="Video.webm">'
	}

	It 'should support the "srcset" and "media" attributes' {
		source -SrcSet Image.webp -Media "(width > 600px)" | Should -BeIn '<source media="(width > 600px)" srcset="Image.webp">', '<source srcset="Image.webp" media="(width > 600px)">'
	}
}
