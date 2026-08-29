using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TextareaElement` cmdlet.
#>
Describe "New-TextareaElement" {
	It 'should support the "autocomplete" attribute' -ForEach "off", "on", @("shipping", "street-address") {
		Should-BeString "<textarea autocomplete=""$($_ -join " ")""></textarea>" (textarea -AutoComplete $_) -CaseSensitive
	}

	It 'should support the "autocorrect" attribute' -ForEach "off", "on" {
		Should-BeString "<textarea autocorrect=""$_""></textarea>" (textarea -AutoCorrect $_) -CaseSensitive
	}

	It 'should support the "cols" and "rows" attributes' -ForEach @(
		@{ Cols = 80; Rows = 12 }
		@{ Cols = 120; Rows = 5 }
	) {
		"<textarea cols=""$cols"" rows=""$rows""></textarea>", "<textarea rows=""$rows"" cols=""$cols""></textarea>" | Should-ContainCollection (textarea -Cols $cols -Rows $rows)
	}

	It 'should support the "disabled" attribute' {
		Should-BeString '<textarea disabled></textarea>' (textarea -Disabled) -CaseSensitive
	}

	It 'should support the "maxlength" and "minlength" attributes' -ForEach @(
		@{ MinLength = 0; MaxLength = 255 }
		@{ MinLength = 8; MaxLength = 24 }
	) {
		$expected = "<textarea maxlength=""$maxLength"" minlength=""$minLength""></textarea>", "<textarea minlength=""$minLength"" maxlength=""$maxLength""></textarea>"
		$expected | Should-ContainCollection (textarea -MinLength $minLength -MaxLength $maxLength)
	}

	It 'should support the "readonly" attribute' {
		Should-BeString '<textarea readonly></textarea>' (textarea -ReadOnly) -CaseSensitive
	}

	It 'should support the "required" attribute' {
		Should-BeString '<textarea required></textarea>' (textarea -Required) -CaseSensitive
	}

	It 'should support the "spellcheck" attribute' -ForEach false, true {
		Should-BeString "<textarea spellcheck=""$_""></textarea>" (textarea -SpellCheck $_) -CaseSensitive
	}
}
