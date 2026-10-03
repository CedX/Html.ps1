using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TemplateElement` cmdlet.
#>
Describe "New-TemplateElement" {
	It 'should support the "shadowrootclonable" attribute' {
		template -ShadowRootClonable | Should-BeString '<template shadowrootclonable></template>' -CaseSensitive
	}

	It 'should support the "shadowrootdelegatesfocus" attribute' {
		template -ShadowRootDelegatesFocus | Should-BeString '<template shadowrootdelegatesfocus></template>' -CaseSensitive
	}

	It 'should support the "shadowrootmode" attribute' -ForEach closed, open {
		template -ShadowRootMode $_ | Should-BeString "<template shadowrootmode=""$_""></template>" -CaseSensitive
	}

	It 'should support the "shadowrootserializable" attribute' {
		template -ShadowRootSerializable | Should-BeString '<template shadowrootserializable></template>' -CaseSensitive
	}

	It "should allow inner content" {
		template (b "Hello World!") | Should-BeString "<template><b>Hello World!</b></template>" -CaseSensitive
		button OK -Type submit | template | Should-BeString '<template><button type="submit">OK</button></template>' -CaseSensitive
	}
}
