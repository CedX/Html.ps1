using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ButtonElement` cmdlet.
#>
Describe "New-ButtonElement" {
	It 'should support the "command" and "commandfor" attributes' {
		$expected = '<button command="show-modal" commandfor="DialogBox"></button>', '<button commandfor="DialogBox" command="show-modal"></button>'
		$expected | Should-ContainCollection (button -Command show-modal -CommandFor DialogBox)
	}

	It 'should support the "disabled" attribute' {
		Should-BeString '<button disabled></button>' (button -Disabled) -CaseSensitive
	}

	It 'should support the "formnovalidate" attribute' {
		Should-BeString '<button formnovalidate></button>' (button -FormNoValidate) -CaseSensitive
	}

	It 'should support the "type" attribute' -ForEach button, reset, submit {
		Should-BeString "<button type=""$_""></button>" (button -Type $_) -CaseSensitive
	}
}
