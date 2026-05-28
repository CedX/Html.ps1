using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-HtmlFieldsetElement` cmdlet.
#>
Describe "New-HtmlFieldsetElement" {
	It 'should support the "disabled" attribute' {
		fieldset -Disabled | Should -BeExactly "<fieldset disabled></fieldset>"
	}

	It 'should support the "form" attribute' {
		fieldset -Form MyForm | Should -BeExactly '<fieldset form="MyForm"></fieldset>'
	}
}
