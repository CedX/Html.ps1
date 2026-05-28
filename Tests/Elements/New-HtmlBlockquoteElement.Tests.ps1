using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlBlockquoteElement` cmdlet.
#>
Describe "New-HtmlBlockquoteElement" {
	It 'should support the "cite" attribute' {
		blockquote "Lorem Ipsum" -Cite "https://example.com/" | Should -BeExactly '<blockquote cite="https://example.com/">Lorem Ipsum</blockquote>'
	}
}
