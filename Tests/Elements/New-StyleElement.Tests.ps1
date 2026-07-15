using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-StyleElement` cmdlet.
#>
Describe "New-StyleElement" {
	It 'should support the "media" attribute' -ForEach "all", "(width <= 500px)" {
		Should-BeString "<style media=""$_""></style>" (style -Media $_) -CaseSensitive
	}

	It "should allow inner content" {
		$content = "p { color: blue; background-color: yellow; }"
		Should-BeString "<style>$content</style>" (style $content) -CaseSensitive
	}
}
