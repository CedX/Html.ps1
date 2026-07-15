using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-TemplateElement` cmdlet.
#>
Describe "New-TemplateElement" {
	It 'should support the "shadowrootclonable" attribute' {
		Should-BeString '<template shadowrootclonable></template>' (template -ShadowRootClonable) -CaseSensitive
	}

	It 'should support the "shadowrootdelegatesfocus" attribute' {
		Should-BeString '<template shadowrootdelegatesfocus></template>' (template -ShadowRootDelegatesFocus) -CaseSensitive
	}

	It 'should support the "shadowrootmode" attribute' -ForEach closed, open {
		Should-BeString "<template shadowrootmode=""$_""></template>" (template -ShadowRootMode $_) -CaseSensitive
	}

	It 'should support the "shadowrootserializable" attribute' {
		Should-BeString '<template shadowrootserializable></template>' (template -ShadowRootSerializable) -CaseSensitive
	}

	It "should allow inner content" {
		Should-BeString "<template><b>Hello World!</b></template>" (template (b "Hello World!")) -CaseSensitive
		Should-BeString '<template><button type="submit">OK</button></template>' (template (button OK -Type submit)) -CaseSensitive
	}
}
