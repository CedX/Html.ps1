using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlQElement` cmdlet.
#>
Describe "New-HtmlQElement" {
	It 'should support the "cite" attribute' {
		q "Lorem Ipsum" -Cite "https://example.com/" | Should -BeExactly '<q cite="https://example.com/">Lorem Ipsum</q>'
	}
}
