using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `Protect-String` cmdlet.
#>
Describe "Protect-String" {
	It "should encode the specified string" -ForEach @(
		@{ Value = $null; Encoding = "Html"; Expected = "" }
		@{ Value = $null; Encoding = "Url"; Expected = "" }
		@{ Value = '<script type="module"></script>'; Encoding = "Html"; Expected = "&lt;script type=&quot;module&quot;&gt;&lt;/script&gt;" }
		@{ Value = " foo "; Encoding = "Url"; Expected = "%20foo%20" }
	) {
		esc $value -Encoding $encoding | Should -BeExactly $expected
	}
}
