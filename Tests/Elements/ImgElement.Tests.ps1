using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ImgElement` cmdlet.
#>
Describe "New-ImgElement" {
	It 'should support the "alt" and "src" attributes' -ForEach @(
		@{ Src = "Image.webp"; Alt = $null }
		@{ Src = "Assets/Icon.gif"; Alt = "" }
		@{ Src = "Assets/Picture.jpg"; Alt = "A label describing the image." }
	) {
		$img = img -Src $src -Alt $alt
		if ($null -eq $alt) { $img | Should -BeExactly "<img src=""$src"">" }
		else { $img | Should -BeIn "<img alt=""$alt"" src=""$src"">", "<img src=""$src"" alt=""$alt"">" }
	}

	It 'should support the "ismap" and "usemap" attributes' {
		img -Src Image.webp -IsMap | Should -BeIn '<img ismap src="Image.webp">', '<img src="Image.webp" ismap>'
		img -Src Image.webp -UseMap my-map | Should -BeIn '<img usemap="#my-map" src="Image.webp">', '<img src="Image.webp" usemap="#my-map">'
	}

	It 'should support the "width" and "height" attributes' {
		img -Src Image.webp -Height 200 | Should -BeIn '<img height="200" src="Image.webp">', '<img src="Image.webp" height="200">'
		img -Src Image.webp -Width 460 | Should -BeIn '<img width="460" src="Image.webp">', '<img src="Image.webp" width="460">'
	}

	It 'should support the "loading" attribute' -ForEach eager, lazy {
		img -Src Image.webp -Loading $_ | Should -BeIn "<img loading=""$_"" src=""Image.webp"">", "<img src=""Image.webp"" loading=""$_"">"
	}
}
