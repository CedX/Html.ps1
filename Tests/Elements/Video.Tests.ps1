using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-VideoElement` cmdlet.
#>
Describe "New-VideoElement" {
	It 'should support the "autoplay", "controls", "loop" and "muted" attributes' {
		Should-BeString "<video autoplay></video>" (video -AutoPlay) -CaseSensitive
		Should-BeString "<video controls></video>" (video -Controls) -CaseSensitive
		Should-BeString "<video loop></video>" (video -Loop) -CaseSensitive
		Should-BeString "<video muted></video>" (video -Muted) -CaseSensitive
	}

	It 'should support the "poster" attribute' {
		Should-BeString '<video poster="Picture.webp"></video>' (video -Poster Picture.webp) -CaseSensitive
	}

	It 'should support the "preload" attribute' -ForEach auto, none, metadata {
		Should-BeString "<video preload=""$_""></video>" (video -Preload $_) -CaseSensitive
	}

	It 'should support the "width" and "height" attributes' {
		'<video width="460" height="200"></video>', '<video height="200" width="460"></video>' | Should-ContainCollection (video -Width 460 -Height 200)
	}
}
