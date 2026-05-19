using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-InputElement` cmdlet.
#>
Describe "New-InputElement" {
	It 'should support the "accept" attribute' {
		input -Accept "image/*" | Should -BeExactly '<input accept="image/*">'
	}

	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		input -AutoComplete $_ | Should -BeExactly "<input autocomplete=""$($_ -join " ")"">"
	}

	It 'should support the "capture" attribute' -ForEach "environment", "user" {
		input -Capture $_ | Should -BeExactly "<input capture=""$_"">"
	}

	It 'should support the "checked" attribute' {
		input -Checked | Should -BeExactly '<input checked>'
	}

	It 'should support the "disabled" attribute' {
		input -Disabled | Should -BeExactly '<input disabled>'
	}

	It 'should support the "maxlength" and "minlength" attributes' -ForEach @(
		@{ MinLength = 0; MaxLength = 255 }
		@{ MinLength = 8; MaxLength = 24 }
	) {
		$expected = "<input maxlength=""$maxLength"" minlength=""$minLength"">", "<input minlength=""$minLength"" maxlength=""$maxLength"">"
		input -MinLength $minLength -MaxLength $maxLength | Should -BeIn $expected
	}

	It 'should support the "multiple" attribute' {
		input -Multiple | Should -BeExactly '<input multiple>'
	}

	It 'should support the "pattern" attribute' -ForEach "https?://.*", "\d{8,14}", "[a-zA-Z0-9]+", "\d[a-zA-Z][a-zA-Z\d]{1,3}", "\s*[+0][\d\s\-.\/]{9,}\s*" {
		input -Pattern $_ | Should -BeExactly "<input pattern=""$($_ -replace "\\", "\\")"">"
	}

	It 'should support the "readonly" attribute' {
		input -ReadOnly | Should -BeExactly '<input readonly>'
	}

	It 'should support the "required" attribute' {
		input -Required | Should -BeExactly '<input required>'
	}

	It 'should support the "spellcheck" attribute' -ForEach false, true {
		input -SpellCheck $_ | Should -BeExactly "<input spellcheck=""$_"">"
	}

	It 'should support the "type" and "value" attributes' -ForEach @(
		@{ Type = "checkbox"; Value = 1 }
		@{ Type = "date"; Value = "1974-05-03" }
		@{ Type = "email"; Value = "hello@example.com" }
		@{ Type = "number"; Value = 666 }
		@{ Type = "submit"; Value = "OK" }
	) {
		$expected = "<input type=""$type"" value=""$value"">", "<input value=""$value"" type=""$type"">"
		input -Type $type -Value $value | Should -BeIn $expected
	}
}
