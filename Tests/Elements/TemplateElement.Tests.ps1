using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TemplateElement` cmdlet.
#>
Describe "New-TemplateElement" {
	It 'should support the "shadowrootclonable" attribute' {
		template -ShadowRootClonable | Should -BeExactly '<template shadowrootclonable></template>'
	}

	It 'should support the "shadowrootdelegatesfocus" attribute' {
		template -ShadowRootDelegatesFocus | Should -BeExactly '<template shadowrootdelegatesfocus></template>'
	}

	It 'should support the "shadowrootmode" attribute' -ForEach closed, open {
		template -ShadowRootMode $_ | Should -BeExactly "<template shadowrootmode=""$_""></template>"
	}

	It 'should support the "shadowrootserializable" attribute' {
		template -ShadowRootSerializable | Should -BeExactly '<template shadowrootserializable></template>'
	}

	It "should allow inner content" {
		template (b "Hello World!") | Should -BeExactly "<template><b>Hello World!</b></template>"
		template (button OK -Type submit) | Should -BeExactly '<template><button type="submit">OK</button></template>'
	}
}
