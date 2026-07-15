using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-QElement` cmdlet.
#>
Describe "New-QElement" {
	It 'should support the "cite" attribute' {
		Should-BeString '<q cite="https://example.com/">Lorem Ipsum</q>' (q "Lorem Ipsum" -Cite "https://example.com/") -CaseSensitive
	}
}
