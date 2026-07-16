using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-FormElement` cmdlet.
#>
Describe "New-FormElement" {
	It 'should support the "action" attribute' {
		Should-BeString '<form action="/Process.php"></form>' (form -Action "/Process.php") -CaseSensitive
	}

	It 'should support the "enctype" attribute' -ForEach "application/x-www-form-urlencoded", "multipart/form-data", "text/plain" {
		Should-BeString "<form enctype=""$_""></form>" (form -EncType $_) -CaseSensitive
	}

	It 'should support the "method" attribute' -ForEach dialog, get, post {
		Should-BeString "<form method=""$_""></form>" (form -Method $_) -CaseSensitive
	}

	It 'should support the "novalidate" attribute' {
		Should-BeString '<form novalidate></form>' (form -NoValidate) -CaseSensitive
	}

	It "should allow inner content" {
		Should-BeString '<form><button type="submit">OK</button></form>' (form (button OK -Type submit)) -CaseSensitive
		Should-BeString '<form><input name="UserName"></form>' (form (input -Name UserName)) -CaseSensitive
	}
}
