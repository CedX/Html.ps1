using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DocumentType` cmdlet.
#>
Describe "New-DocumentType" {
	It "should return a document type declaration" -ForEach @(
		@{ Value = $null; Expected = "<!doctype html>" }
		@{ Value = 'html public "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd"'; Expected = '<!doctype html public "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">' }
		@{ Value = 'html public "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"'; Expected = '<!doctype html public "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">'}
	) {
		doctype $value | Should -BeExactly $expected
	}
}
