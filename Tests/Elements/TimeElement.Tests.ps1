using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TimeElement` cmdlet.
#>
Describe "New-TimeElement" {
	It 'should support [DateOnly] objects for the "datetime" attribute' {
		$value = [DateOnly]::FromDateTime((Get-Date -Year 1974 -Month 5 -Day 3))
		time -DateTime $value | Should -BeExactly '<time datetime="1974-05-03"></time>'
	}

	It 'should support [DateTime] objects for the "datetime" attribute' {
		$value = Get-Date -Year 1974 -Month 5 -Day 3 -Hour 8 -Minute 16 -Second 32
		time -DateTime $value | Should -BeLikeExactly '<time datetime="1974-05-03T08:16:32.*"></time>'
	}

	It 'should support [TimeOnly] objects for the "datetime" attribute' {
		$value = [TimeOnly]::FromDateTime((Get-Date -Hour 8 -Minute 16 -Second 32))
		time -DateTime $value | Should -BeLikeExactly '<time datetime="08:16:32.*"></time>'
	}

	It 'should support [TimeSpan] objects for the "datetime" attribute' {
		$value = New-TimeSpan -Days 3 -Hours 5 -Minutes 19 -Seconds 7
		time -DateTime $value | Should -BeExactly '<time datetime="P3DT5H19M7S"></time>'
	}
}
