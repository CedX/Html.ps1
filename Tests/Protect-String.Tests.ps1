using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `Protect-String` cmdlet.
#>
Describe "Protect-String" {
	It "encode the specified string" -ForEach @(
		@{ Value = $null; Encoder = "Html"; Expected = "" }
		@{ Value = $null; Encoder = "Url"; Expected = "" }
		@{ Value = '<script type="module"></script>'; Encoder = "Html"; Expected = "&lt;script type=&quot;module&quot;&gt;&lt;/script&gt;" }
		@{ Value = " foo "; Encoder = "Url"; Expected = "%20foo%20" }
	) {
		esc $value -Encoder $encoder | Should -BeExactly $expected
	}
}
