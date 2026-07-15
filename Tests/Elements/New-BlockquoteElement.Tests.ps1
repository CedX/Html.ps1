using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-BlockquoteElement` cmdlet.
#>
Describe "New-BlockquoteElement" {
	It 'should support the "cite" attribute' {
		Should-BeString '<blockquote cite="https://example.com/">Lorem Ipsum</blockquote>' (blockquote "Lorem Ipsum" -Cite "https://example.com/") -CaseSensitive
	}
}
