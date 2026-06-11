using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-VideoElement` cmdlet.
#>
Describe "New-VideoElement" {
	It 'should support the "autoplay", "controls", "loop" and "muted" attributes' {
		video -AutoPlay | Should -BeExactly "<video autoplay></video>"
		video -Controls | Should -BeExactly "<video controls></video>"
		video -Loop | Should -BeExactly "<video loop></video>"
		video -Muted | Should -BeExactly "<video muted></video>"
	}

	It 'should support the "poster" attribute' {
		video -Poster Picture.webp | Should -BeExactly '<video poster="Picture.webp"></video>'
	}

	It 'should support the "preload" attribute' -ForEach auto, none, metadata {
		video -Preload $_ | Should -BeExactly "<video preload=""$_""></video>"
	}

	It 'should support the "width" and "height" attributes' {
		video -Width 460 -Height 200 | Should -BeIn '<video width="460" height="200"></video>', '<video height="200" width="460"></video>'
	}
}
