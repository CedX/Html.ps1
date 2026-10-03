using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-InsElement` cmdlet.
#>
Describe "New-InsElement" {
	It 'should support the "cite" attribute' {
		ins "Lorem Ipsum" -Cite "https://example.com/" | Should-BeString '<ins cite="https://example.com/">Lorem Ipsum</ins>' -CaseSensitive
	}

	It 'should support [DateOnly] objects for the "datetime" attribute' {
		$value = [DateOnly]::FromDateTime((Get-Date -Year 1974 -Month 5 -Day 3))
		ins -DateTime $value | Should-BeString '<ins datetime="1974-05-03"></ins>' -CaseSensitive
	}

	It 'should support [DateTime] objects for the "datetime" attribute' {
		$value = Get-Date -Year 1974 -Month 5 -Day 3 -Hour 8 -Minute 16 -Second 32
		ins -DateTime $value | Should-BeLikeString '<ins datetime="1974-05-03T08:16:32.*"></ins>' -CaseSensitive
	}
}
