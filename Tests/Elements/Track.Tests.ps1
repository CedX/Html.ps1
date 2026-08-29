using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TrackElement` cmdlet.
#>
Describe "New-TrackElement" {
	It 'should support the "default" attribute' {
		'<track src="Subtitles.vtt" default>', '<track default src="Subtitles.vtt">' | Should-ContainCollection (track -Src Subtitles.vtt -Default)
	}

	It 'should support the "kind" attribute' -ForEach captions, chapters, descriptions, metadata, subtitles {
		"<track src=""Subtitles.vtt"" kind=""$_"">", "<track kind=""$_"" src=""Subtitles.vtt"">" | Should-ContainCollection (track -Src Subtitles.vtt -Kind $_)
	}
}
