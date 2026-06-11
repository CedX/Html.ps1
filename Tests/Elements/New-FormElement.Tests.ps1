using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-FormElement` cmdlet.
#>
Describe "New-FormElement" {
	It 'should support the "action" attribute' {
		form -Action "/Process.php" | Should -BeExactly '<form action="/Process.php"></form>'
	}

	It 'should support the "enctype" attribute' -ForEach "application/x-www-form-urlencoded", "multipart/form-data", "text/plain" {
		form -EncType $_ | Should -BeExactly "<form enctype=""$_""></form>"
	}

	It 'should support the "method" attribute' -ForEach dialog, get, post {
		form -Method $_ | Should -BeExactly "<form method=""$_""></form>"
	}

	It 'should support the "novalidate" attribute' {
		form -NoValidate | Should -BeExactly '<form novalidate></form>'
	}

	It "should allow inner content" {
		form (button OK -Type submit) | Should -BeExactly '<form><button type="submit">OK</button></form>'
		form (input -Name UserName) | Should -BeExactly '<form><input name="UserName"></form>'
	}
}
