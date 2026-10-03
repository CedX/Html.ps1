using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-FormElement` cmdlet.
#>
Describe "New-FormElement" {
	It 'should support the "action" attribute' {
		form -Action "/Process.php" | Should-BeString '<form action="/Process.php"></form>' -CaseSensitive
	}

	It 'should support the "enctype" attribute' -ForEach "application/x-www-form-urlencoded", "multipart/form-data", "text/plain" {
		form -EncType $_ | Should-BeString "<form enctype=""$_""></form>" -CaseSensitive
	}

	It 'should support the "method" attribute' -ForEach dialog, get, post {
		form -Method $_ | Should-BeString "<form method=""$_""></form>" -CaseSensitive
	}

	It 'should support the "novalidate" attribute' {
		form -NoValidate | Should-BeString '<form novalidate></form>' -CaseSensitive
	}

	It "should allow inner content" {
		button OK -Type submit | form | Should-BeString '<form><button type="submit">OK</button></form>' -CaseSensitive
		input -Name UserName | form | Should-BeString '<form><input name="UserName"></form>' -CaseSensitive
	}
}
