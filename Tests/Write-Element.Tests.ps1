using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `Write-Element` cmdlet.
#>
Describe "Write-Element" {
	It "should create an HTML element from the specified tag name" -ForEach @(
		@{ Tag = "b"; Expected = "<b></b>" }
		@{ Tag = "html"; Expected = "<html></html>" }
	) {
		& $tag | Should -BeExactly $expected
	}

	It "should handle void elements" -ForEach @(
		@{ Tag = "br"; Expected = "<br>" }
		@{ Tag = "input"; Expected = "<input>" }
	) {
		& $tag | Should -BeExactly $expected
	}

	It 'should handle the "aria" attributes' {
		div -Aria @{ Atomic = "true" } | Should -BeExactly '<div aria-atomic="true"></div>'
		div -Aria @{ DescribedBy = "ID" } | Should -BeExactly '<div aria-describedby="ID"></div>'
	}

	It 'should handle the "class" attribute' {
		body -Class btn, btn-danger | Should -BeExactly '<body class="btn btn-danger"></body>'
		body -Class "btn btn-info", btn-sm | Should -BeExactly '<body class="btn btn-info btn-sm"></body>'
	}

	It 'should support the "dir" attribute' -ForEach auto, ltr, rtl {
		html -Dir $_ | Should -BeExactly "<html dir=""$_""></html>"
	}

	It 'should handle the "id" attribute' {
		article -Id foo | Should -BeExactly '<article id="foo"></article>'
	}

	It 'should support the "lang" attribute' -ForEach "fr-FR", "en-US" {
		html -Lang $_ | Should -BeExactly "<html lang=""$_""></html>"
	}

	It 'should handle the "role" attribute' {
		div -Role button | Should -BeExactly '<div role="button"></div>'
	}

	It 'should handle the "style" attribute' {
		$expected = '<code style="font-family: &quot;Segoe UI&quot;; font-size: 1rem"></code>'
		code -Style ([ordered]@{ FontFamily = '"Segoe UI"'; FontSize = "1rem" }) | Should -BeExactly $expected
	}

	It 'should handle the "tabindex" attribute' -ForEach -1, 0 {
		div -TabIndex $_ | Should -BeExactly "<div tabindex=""$_""></div>"
	}

	It 'should handle the "title" attribute' -ForEach "", 'A "custom" label.' {
		div -Title $_ | Should -BeExactly ($_ ? '<div title="A &quot;custom&quot; label."></div>' : "<div></div>")
	}

	It "should handle custom attributes" {
		$expected = '<input data-foo="&quot;bar&quot;" required>', '<input required data-foo="&quot;bar&quot;">'
		input -Attributes @{ "data-foo" = '"bar"'; disabled = $false; required = $true } | Should -BeIn $expected
	}

	It "should handle data attributes" {
		$expected = '<button data-bs-toggle="tooltip" data-push-url></button>', '<button data-push-url data-bs-toggle="tooltip"></button>'
		button -DataSet @{ BsToggle = "tooltip"; PushUrl = $true } | Should -BeIn $expected
	}

	It "should handle event handler attributes" {
		$expected = '<button onclick="submit(event)" oncontextmenu="showMenu()"></button>', '<button oncontextmenu="showMenu()" onclick="submit(event)"></button>'
		button -On @{ Click = "submit(event)"; ContextMenu = "showMenu()" } | Should -BeIn $expected
	}

	It "should handle switch parameters in attribute values" {
		input -Attributes @{ disabled = [switch] $false; required = [switch] $true } | Should -BeExactly "<input required>"
	}

	It "should handle the inner content" {
		$expected = "<main><div>Foo &gt; Bar <span>Baz &lt; Qux</span></div></main>"
		main { div { "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } } | Should -BeExactly $expected

		$expected = '<head><meta charset="utf-8"></head>'
		head { meta -Charset utf-8 } | Should -BeExactly $expected
	}
}
