using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DelElement` cmdlet.
#>
Describe "New-DelElement" {
	It 'should support the "cite" attribute' {
		delTag "Lorem Ipsum" -Cite "https://example.com/" | Should -BeExactly '<del cite="https://example.com/">Lorem Ipsum</del>'
	}

	It 'should support [DateOnly] objects for the "datetime" attribute' {
		$value = [DateOnly]::FromDateTime((Get-Date -Year 1974 -Month 5 -Day 3))
		delTag -DateTime $value | Should -BeExactly '<del datetime="1974-05-03"></del>'
	}

	It 'should support [DateTime] objects for the "datetime" attribute' {
		$value = Get-Date -Year 1974 -Month 5 -Day 3 -Hour 8 -Minute 16 -Second 32
		delTag -DateTime $value | Should -BeLikeExactly '<del datetime="1974-05-03T08:16:32.*"></del>'
	}
}
