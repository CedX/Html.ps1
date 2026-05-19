using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-CustomElement` cmdlet.
#>
Describe "New-CustomElement" {
	It "should create a custom HTML element from the specified tag name" {
		tag my-element | Should -BeExactly "<my-element></my-element>"
	}

	It 'should handle the "id" attribute' {
		tag my-element -Id foo | Should -BeExactly '<my-element id="foo"></my-element>'
	}

	It 'should handle the "class" attribute' {
		tag my-element -Class btn, btn-danger | Should -BeExactly '<my-element class="btn btn-danger"></my-element>'
		tag my-element -Class "btn btn-info", btn-sm | Should -BeExactly '<my-element class="btn btn-info btn-sm"></my-element>'
	}

	It 'should handle the "style" attribute' {
		$expected = '<my-element style="font-family: &quot;Segoe UI&quot;; font-size: 1rem"></my-element>'
		tag my-element -Style ([ordered]@{ FontFamily = '"Segoe UI"'; FontSize = "1rem" }) | Should -BeExactly $expected
	}

	It 'should handle the "tabindex" attribute' -ForEach -1, 0 {
		tag my-element -TabIndex $_ | Should -BeExactly "<my-element tabindex=""$_""></my-element>"
	}

	It 'should handle the "title" attribute' -ForEach "", 'A "custom" label.' {
		tag my-element -Title $_ | Should -BeExactly ($_ ? '<my-element title="A &quot;custom&quot; label."></my-element>' : "<my-element></my-element>")
	}

	It "should handle custom attributes" {
		$expected = '<my-element data-foo="&quot;bar&quot;" required></my-element>', '<my-element required data-foo="&quot;bar&quot;"></my-element>'
		tag my-element -Attributes @{ "data-foo" = '"bar"'; disabled = $false; required = $true } | Should -BeIn $expected
	}

	It "should handle data attributes" {
		$expected = '<my-element data-bs-toggle="tooltip" data-push-url></my-element>', '<my-element data-push-url data-bs-toggle="tooltip"></my-element>'
		tag my-element -DataSet @{ BsToggle = "tooltip"; PushUrl = $true } | Should -BeIn $expected
	}

	It "should handle event handler attributes" {
		$expected = '<my-element onclick="submit(event)" oncontextmenu="showMenu()"></my-element>', '<my-element oncontextmenu="showMenu()" onclick="submit(event)"></my-element>'
		tag my-element -On @{ Click = "submit(event)"; ContextMenu = "showMenu()" } | Should -BeIn $expected
	}

	It "should handle the inner content" {
		$expected = "<outer-element><inner-element>Foo &gt; Bar <span>Baz &lt; Qux</span></inner-element></outer-element>"
		tag outer-element { tag inner-element { "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } } | Should -BeExactly $expected
	}
}
