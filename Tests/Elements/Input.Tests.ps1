using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-InputElement` cmdlet.
#>
Describe "New-InputElement" {
	It 'should support the "accept" attribute' {
		Should-BeString '<input accept="image/*">' (input -Accept "image/*") -CaseSensitive
	}

	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		Should-BeString "<input autocomplete=""$($_ -join " ")"">" (input -AutoComplete $_) -CaseSensitive
	}

	It 'should support the "capture" attribute' -ForEach "environment", "user" {
		Should-BeString "<input capture=""$_"">" (input -Capture $_) -CaseSensitive
	}

	It 'should support the "checked" attribute' {
		Should-BeString '<input checked>' (input -Checked) -CaseSensitive
	}

	It 'should support the "disabled" attribute' {
		Should-BeString '<input disabled>' (input -Disabled) -CaseSensitive
	}

	It 'should support the "max", "min" attributes' -ForEach @(
		@{ Min = 0; Max = 255 }
		@{ Min = 8; Max = 24 }
	) {
		$expected = "<input max=""$max"" min=""$min"">", "<input min=""$min"" max=""$max"">"
		$expected | Should-ContainCollection (input -Min $min -Max $max)
	}

	It 'should support the "maxlength" and "minlength" attributes' -ForEach @(
		@{ MinLength = 0; MaxLength = 255 }
		@{ MinLength = 8; MaxLength = 24 }
	) {
		$expected = "<input maxlength=""$maxLength"" minlength=""$minLength"">", "<input minlength=""$minLength"" maxlength=""$maxLength"">"
		$expected | Should-ContainCollection (input -MinLength $minLength -MaxLength $maxLength)
	}

	It 'should support the "multiple" attribute' {
		Should-BeString '<input multiple>' (input -Multiple) -CaseSensitive
	}

	It 'should support the "pattern" attribute' -ForEach "https?://.*", "\d{8,14}", "[a-zA-Z0-9]+", "\d[a-zA-Z][a-zA-Z\d]{1,3}", "\s*[+0][\d\s\-.\/]{9,}\s*" {
		Should-BeString "<input pattern=""$($_ -replace "\\", "\\")"">" (input -Pattern $_) -CaseSensitive
	}

	It 'should support the "readonly" attribute' {
		Should-BeString '<input readonly>' (input -ReadOnly) -CaseSensitive
	}

	It 'should support the "required" attribute' {
		Should-BeString '<input required>' (input -Required) -CaseSensitive
	}

	It 'should support the "spellcheck" attribute' -ForEach false, true {
		Should-BeString "<input spellcheck=""$_"">" (input -SpellCheck $_) -CaseSensitive
	}

	It 'should support the "type" and "value" attributes' -ForEach @(
		@{ Type = "checkbox"; Value = 1 }
		@{ Type = "date"; Value = "1974-05-03" }
		@{ Type = "email"; Value = "hello@example.com" }
		@{ Type = "number"; Value = 666 }
		@{ Type = "submit"; Value = "OK" }
	) {
		$expected = "<input type=""$type"" value=""$value"">", "<input value=""$value"" type=""$type"">"
		$expected | Should-ContainCollection (input -Type $type -Value $value)
	}
}
