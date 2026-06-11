using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TrackElement` cmdlet.
#>
Describe "New-TrackElement" {
	It 'should support the "default" attribute' {
		track -Src Subtitles.vtt -Default | Should -BeIn '<track src="Subtitles.vtt" default>', '<track default src="Subtitles.vtt">'
	}

	It 'should support the "kind" attribute' -ForEach captions, chapters, descriptions, metadata, subtitles {
		track -Src Subtitles.vtt -Kind $_ | Should -BeIn "<track src=""Subtitles.vtt"" kind=""$_"">", "<track kind=""$_"" src=""Subtitles.vtt"">"
	}
}
