using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-StyleElement` cmdlet.
#>
Describe "New-StyleElement" {
	It 'should support the "media" attribute' -ForEach "all", "(width <= 500px)" {
		style -Media $_ | Should-BeString "<style media=""$_""></style>" -CaseSensitive
	}

	It "should allow inner content" {
		$content = "p { color: blue; background-color: yellow; }"
		$content | style | Should-BeString "<style>$content</style>" -CaseSensitive
	}
}
