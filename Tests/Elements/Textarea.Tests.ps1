using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TextareaElement` cmdlet.
#>
Describe "New-TextareaElement" {
	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		textarea -AutoComplete $_ | Should-BeString "<textarea autocomplete=""$($_ -join " ")""></textarea>" -CaseSensitive
	}

	It 'should support the "autocorrect" attribute' -ForEach "off", "on" {
		textarea -AutoCorrect $_ | Should-BeString "<textarea autocorrect=""$_""></textarea>" -CaseSensitive
	}

	It 'should support the "cols" and "rows" attributes' -ForEach @(
		@{ Cols = 80; Rows = 12 }
		@{ Cols = 120; Rows = 5 }
	) {
		"<textarea cols=""$cols"" rows=""$rows""></textarea>", "<textarea rows=""$rows"" cols=""$cols""></textarea>" | Should-ContainCollection (textarea -Cols $cols -Rows $rows)
	}

	It 'should support the "disabled" attribute' {
		textarea -Disabled | Should-BeString '<textarea disabled></textarea>' -CaseSensitive
	}

	It 'should support the "maxlength" and "minlength" attributes' -ForEach @(
		@{ MinLength = 0; MaxLength = 255 }
		@{ MinLength = 8; MaxLength = 24 }
	) {
		$expected = "<textarea maxlength=""$maxLength"" minlength=""$minLength""></textarea>", "<textarea minlength=""$minLength"" maxlength=""$maxLength""></textarea>"
		$expected | Should-ContainCollection (textarea -MinLength $minLength -MaxLength $maxLength)
	}

	It 'should support the "readonly" attribute' {
		textarea -ReadOnly | Should-BeString '<textarea readonly></textarea>' -CaseSensitive
	}

	It 'should support the "required" attribute' {
		textarea -Required | Should-BeString '<textarea required></textarea>' -CaseSensitive
	}

	It 'should support the "spellcheck" attribute' -ForEach false, true {
		textarea -SpellCheck $_ | Should-BeString "<textarea spellcheck=""$_""></textarea>" -CaseSensitive
	}
}
