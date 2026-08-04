using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-Element` cmdlet.
#>
Describe "New-Element" {
	It "should create an HTML element from the specified tag name" -ForEach @(
		@{ Tag = "b"; Expected = "<b></b>" }
		@{ Tag = "html"; Expected = "<html></html>" }
	) {
		Should-BeString $expected (& $tag) -CaseSensitive
	}

	It "should handle void elements" -ForEach @(
		@{ Tag = "br"; Expected = "<br>" }
		@{ Tag = "input"; Expected = "<input>" }
	) {
		Should-BeString $expected (& $tag) -CaseSensitive
	}

	It 'should handle the "aria" attributes' {
		Should-BeString '<div aria-atomic="true"></div>' (div -Aria @{ Atomic = "true" }) -CaseSensitive
		Should-BeString '<div aria-describedby="ID"></div>' (div -Aria @{ DescribedBy = "ID" }) -CaseSensitive
	}

	It 'should handle the "class" attribute' {
		Should-BeString '<body class="btn btn-danger"></body>' (body -Class btn, btn-danger) -CaseSensitive
		Should-BeString '<body class="btn btn-info btn-sm"></body>' (body -Class "btn btn-info", btn-sm) -CaseSensitive
	}

	It 'should support the "dir" attribute' -ForEach auto, ltr, rtl {
		Should-BeString "<html dir=""$_""></html>" (html -Dir $_) -CaseSensitive
	}

	It 'should handle the "id" attribute' {
		Should-BeString '<article id="foo"></article>' (article -Id foo) -CaseSensitive
	}

	It 'should support the "lang" attribute' -ForEach "fr-FR", "en-US" {
		Should-BeString "<html lang=""$_""></html>" (html -Lang $_) -CaseSensitive
	}

	It 'should handle the "role" attribute' {
		Should-BeString '<div role="button"></div>' (div -Role button) -CaseSensitive
	}

	It 'should handle the "style" attribute' {
		$expected = '<code style="font-family: &quot;Segoe UI&quot;; font-size: 1rem"></code>'
		Should-BeString $expected (code -Style ([ordered]@{ FontFamily = '"Segoe UI"'; FontSize = "1rem" })) -CaseSensitive
	}

	It 'should handle the "tabindex" attribute' -ForEach -1, 0 {
		Should-BeString "<div tabindex=""$_""></div>" (div -TabIndex $_) -CaseSensitive
	}

	It 'should handle the "title" attribute' -ForEach "", 'A "custom" label.' {
		Should-BeString ($_ ? '<div title="A &quot;custom&quot; label."></div>' : "<div></div>") (div -Title $_) -CaseSensitive
	}

	It "should handle custom attributes" {
		$expected = '<input data-foo="&quot;bar&quot;" required>', '<input required data-foo="&quot;bar&quot;">'
		$expected | Should-ContainCollection (input -Attributes @{ "data-foo" = '"bar"'; disabled = $false; required = $true })
	}

	It "should handle data attributes" {
		$expected = '<button data-bs-toggle="tooltip" data-push-url></button>', '<button data-push-url data-bs-toggle="tooltip"></button>'
		$expected | Should-ContainCollection (button -DataSet @{ BsToggle = "tooltip"; PushUrl = $true })
	}

	It "should htmx attributes" {
		$expected = '<button hx-confirm="Wat?" hx-post="/new"></button>', '<button hx-post="/new" hx-confirm="Wat?"></button>'
		$expected | Should-ContainCollection (button -Hx @{ Confirm = "Wat?"; Post = "/new" })
		Should-BeString '<button hx-on:app:click="alert(''Hello!'')"></button>' (button -Hx @{ "On:app:click" = "alert('Hello!')" }) -CaseSensitive
	}

	It "should handle event handler attributes" {
		$expected = '<button onclick="submit(event)" oncontextmenu="showMenu()"></button>', '<button oncontextmenu="showMenu()" onclick="submit(event)"></button>'
		$expected | Should-ContainCollection (button -On @{ Click = "submit(event)"; ContextMenu = "showMenu()" })
	}

	It "should handle switch parameters in attribute values" {
		Should-BeString "<input required>" (input -Attributes @{ disabled = $false; required = $true }) -CaseSensitive
	}

	It "should handle the inner content" {
		$expected = "<main><div>Foo &gt; Bar <span>Baz &lt; Qux</span></div></main>"
		Should-BeString $expected (main { div { "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } }) -CaseSensitive

		$expected = '<head><meta charset="utf-8"></head>'
		Should-BeString $expected (head { meta -Charset utf-8 }) -CaseSensitive
	}
}
