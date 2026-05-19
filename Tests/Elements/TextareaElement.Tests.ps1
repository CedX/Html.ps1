using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TextareaElement` cmdlet.
#>
Describe "New-TextareaElement" {
	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		textarea -AutoComplete $_ | Should -BeExactly "<textarea autocomplete=""$($_ -join " ")""></textarea>"
	}

	It 'should support the "autocorrect" attribute' -ForEach "off", "on" {
		textarea -AutoCorrect $_ | Should -BeExactly "<textarea autocorrect=""$_""></textarea>"
	}

	It 'should support the "cols" and "rows" attributes' -ForEach @(
		@{ Cols = 80; Rows = 12 }
		@{ Cols = 120; Rows = 5 }
	) {
		textarea -Cols $cols -Rows $rows | Should -BeIn "<textarea cols=""$cols"" rows=""$rows""></textarea>", "<textarea rows=""$rows"" cols=""$cols""></textarea>"
	}

	It 'should support the "disabled" attribute' {
		textarea -Disabled | Should -BeExactly '<textarea disabled></textarea>'
	}

	It 'should support the "maxlength" and "minlength" attributes' -ForEach @(
		@{ MinLength = 0; MaxLength = 255 }
		@{ MinLength = 8; MaxLength = 24 }
	) {
		$expected = "<textarea maxlength=""$maxLength"" minlength=""$minLength""></textarea>", "<textarea minlength=""$minLength"" maxlength=""$maxLength""></textarea>"
		textarea -MinLength $minLength -MaxLength $maxLength | Should -BeIn $expected
	}

	It 'should support the "readonly" attribute' {
		textarea -ReadOnly | Should -BeExactly '<textarea readonly></textarea>'
	}

	It 'should support the "required" attribute' {
		textarea -Required | Should -BeExactly '<textarea required></textarea>'
	}

	It 'should support the "spellcheck" attribute' -ForEach false, true {
		textarea -SpellCheck $_ | Should -BeExactly "<textarea spellcheck=""$_""></textarea>"
	}
}
