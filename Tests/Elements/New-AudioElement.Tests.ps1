using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-AudioElement` cmdlet.
#>
Describe "New-AudioElement" {
	It 'should support the "autoplay", "controls", "loop" and "muted" attributes' {
		Should-BeString "<audio autoplay></audio>" (audio -AutoPlay) -CaseSensitive
		Should-BeString "<audio controls></audio>" (audio -Controls) -CaseSensitive
		Should-BeString "<audio loop></audio>" (audio -Loop) -CaseSensitive
		Should-BeString "<audio muted></audio>" (audio -Muted) -CaseSensitive
	}

	It 'should support the "preload" attribute' -ForEach auto, none, metadata {
		Should-BeString "<audio preload=""$_""></audio>" (audio -Preload $_) -CaseSensitive
	}
}
