using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlStyleElement` cmdlet.
#>
Describe "New-HtmlStyleElement" {
	It 'should support the "media" attribute' -ForEach "all", "(width <= 500px)" {
		style -Media $_ | Should -BeExactly "<style media=""$_""></style>"
	}

	It "should allow inner content" {
		$content = "p { color: blue; background-color: yellow; }"
		style $content | Should -BeExactly "<style>$content</style>"
	}
}
