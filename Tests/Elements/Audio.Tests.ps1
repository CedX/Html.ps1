using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-AudioElement` cmdlet.
#>
Describe "New-AudioElement" {
	It 'should support the "autoplay", "controls", "loop" and "muted" attributes' {
		audio -AutoPlay | Should-BeString "<audio autoplay></audio>" -CaseSensitive
		audio -Controls | Should-BeString "<audio controls></audio>" -CaseSensitive
		audio -Loop | Should-BeString "<audio loop></audio>" -CaseSensitive
		audio -Muted | Should-BeString "<audio muted></audio>" -CaseSensitive
	}

	It 'should support the "preload" attribute' -ForEach auto, none, metadata {
		audio -Preload $_ | Should-BeString "<audio preload=""$_""></audio>" -CaseSensitive
	}
}
