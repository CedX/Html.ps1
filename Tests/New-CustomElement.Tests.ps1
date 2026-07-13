using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-CustomElement` cmdlet.
#>
Describe "New-CustomElement" {
	It "should create a custom HTML element from the specified tag name" {
		Should-BeString "<my-element></my-element>" (tag my-element) -CaseSensitive
	}

	It 'should handle the "id" attribute' {
		Should-BeString '<my-element id="foo"></my-element>' (tag my-element -Id foo) -CaseSensitive
	}

	It 'should handle the "class" attribute' {
		Should-BeString '<my-element class="btn btn-danger"></my-element>' (tag my-element -Class btn, btn-danger) -CaseSensitive
		Should-BeString '<my-element class="btn btn-info btn-sm"></my-element>' (tag my-element -Class "btn btn-info", btn-sm) -CaseSensitive
	}

	It 'should handle the "style" attribute' {
		$expected = '<my-element style="font-family: &quot;Segoe UI&quot;; font-size: 1rem"></my-element>'
		Should-BeString $expected (tag my-element -Style ([ordered]@{ FontFamily = '"Segoe UI"'; FontSize = "1rem" })) -CaseSensitive
	}

	It 'should handle the "tabindex" attribute' -ForEach -1, 0 {
		Should-BeString "<my-element tabindex=""$_""></my-element>" (tag my-element -TabIndex $_) -CaseSensitive
	}

	It 'should handle the "title" attribute' -ForEach "", 'A "custom" label.' {
		Should-BeString ($_ ? '<my-element title="A &quot;custom&quot; label."></my-element>' : "<my-element></my-element>") (tag my-element -Title $_) -CaseSensitive
	}

	It "should handle custom attributes" {
		$expected = '<my-element data-foo="&quot;bar&quot;" required></my-element>', '<my-element required data-foo="&quot;bar&quot;"></my-element>'
		$expected | Should-ContainCollection (tag my-element -Attributes @{ "data-foo" = '"bar"'; disabled = $false; required = $true })
	}

	It "should handle data attributes" {
		$expected = '<my-element data-bs-toggle="tooltip" data-push-url></my-element>', '<my-element data-push-url data-bs-toggle="tooltip"></my-element>'
		$expected | Should-ContainCollection (tag my-element -DataSet @{ BsToggle = "tooltip"; PushUrl = $true })
	}

	It "should handle event handler attributes" {
		$expected = '<my-element onclick="submit(event)" oncontextmenu="showMenu()"></my-element>', '<my-element oncontextmenu="showMenu()" onclick="submit(event)"></my-element>'
		$expected | Should-ContainCollection (tag my-element -On @{ Click = "submit(event)"; ContextMenu = "showMenu()" })
	}

	It "should handle the inner content" {
		$expected = "<outer-element><inner-element>Foo &gt; Bar <span>Baz &lt; Qux</span></inner-element></outer-element>"
		Should-BeString $expected (tag outer-element { tag inner-element { "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } }) -CaseSensitive
	}
}
