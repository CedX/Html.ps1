using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-StyleElement` cmdlet.
#>
Describe "New-StyleElement" {
	It 'should support the "media" attribute' -ForEach "all", "(width <= 500px)" {
		style -Media $_ | Should -BeExactly "<style media=""$_""></style>"
	}

	It "should allow inner content" {
		$content = "p { color: blue; background-color: yellow; }"
		style $content | Should -BeExactly "<style>$content</style>"
	}
}
