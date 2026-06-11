using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-BlockquoteElement` cmdlet.
#>
Describe "New-BlockquoteElement" {
	It 'should support the "cite" attribute' {
		blockquote "Lorem Ipsum" -Cite "https://example.com/" | Should -BeExactly '<blockquote cite="https://example.com/">Lorem Ipsum</blockquote>'
	}
}
