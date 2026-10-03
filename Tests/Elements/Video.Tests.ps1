using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-VideoElement` cmdlet.
#>
Describe "New-VideoElement" {
	It 'should support the "autoplay", "controls", "loop" and "muted" attributes' {
		video -AutoPlay | Should-BeString "<video autoplay></video>" -CaseSensitive
		video -Controls | Should-BeString "<video controls></video>" -CaseSensitive
		video -Loop | Should-BeString "<video loop></video>" -CaseSensitive
		video -Muted | Should-BeString "<video muted></video>" -CaseSensitive
	}

	It 'should support the "poster" attribute' {
		video -Poster Picture.webp | Should-BeString '<video poster="Picture.webp"></video>' -CaseSensitive
	}

	It 'should support the "preload" attribute' -ForEach auto, none, metadata {
		video -Preload $_ | Should-BeString "<video preload=""$_""></video>" -CaseSensitive
	}

	It 'should support the "width" and "height" attributes' {
		'<video width="460" height="200"></video>', '<video height="200" width="460"></video>' | Should-ContainCollection (video -Width 460 -Height 200)
	}
}
