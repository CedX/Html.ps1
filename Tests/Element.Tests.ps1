using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-CustomElement` cmdlet.
#>
Describe "New-CustomElement" {
	It "should create a custom HTML element from the specified tag name" {
		tag my-element | Should-BeString "<my-element></my-element>" -CaseSensitive
	}

	It 'should handle the "id" attribute' {
		tag my-element -Id foo | Should-BeString '<my-element id="foo"></my-element>' -CaseSensitive
	}

	It 'should handle the "class" attribute' {
		tag my-element -Class btn, btn-danger | Should-BeString '<my-element class="btn btn-danger"></my-element>' -CaseSensitive
		tag my-element -Class "btn btn-info", btn-sm | Should-BeString '<my-element class="btn btn-info btn-sm"></my-element>' -CaseSensitive
	}

	It 'should handle the "style" attribute' {
		$expected = '<my-element style="font-family: &quot;Segoe UI&quot;; font-size: 1rem"></my-element>'
		tag my-element -Style ([ordered]@{ FontFamily = '"Segoe UI"'; FontSize = "1rem" }) | Should-BeString $expected -CaseSensitive
	}

	It 'should handle the "tabindex" attribute' -ForEach -1, 0 {
		tag my-element -TabIndex $_ | Should-BeString "<my-element tabindex=""$_""></my-element>" -CaseSensitive
	}

	It 'should handle the "title" attribute' -ForEach "", 'A "custom" label.' {
		tag my-element -Title $_ | Should-BeString ($_ ? '<my-element title="A &quot;custom&quot; label."></my-element>' : "<my-element></my-element>") -CaseSensitive
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
		tag outer-element { tag inner-element { "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } } | Should-BeString $expected -CaseSensitive
		{ "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } | tag inner-element | tag outer-element | Should-BeString $expected -CaseSensitive
	}
}

<#
.SYNOPSIS
	Tests the features of the `New-Element` base cmdlet.
#>
Describe "New-Element" {
	It "should create an HTML element from the specified tag name" -ForEach @(
		@{ Tag = "b"; Expected = "<b></b>" }
		@{ Tag = "html"; Expected = "<html></html>" }
	) {
		& $tag | Should-BeString $expected -CaseSensitive
	}

	It "should handle void elements" -ForEach @(
		@{ Tag = "br"; Expected = "<br>" }
		@{ Tag = "input"; Expected = "<input>" }
	) {
		& $tag | Should-BeString $expected -CaseSensitive
	}

	It 'should handle the "aria" attributes' {
		div -Aria @{ Atomic = "true" } | Should-BeString '<div aria-atomic="true"></div>' -CaseSensitive
		div -Aria @{ DescribedBy = "ID" } | Should-BeString '<div aria-describedby="ID"></div>' -CaseSensitive
	}

	It 'should handle the "class" attribute' {
		body -Class btn, btn-danger | Should-BeString '<body class="btn btn-danger"></body>' -CaseSensitive
		body -Class "btn btn-info", btn-sm | Should-BeString '<body class="btn btn-info btn-sm"></body>' -CaseSensitive
	}

	It 'should support the "dir" attribute' -ForEach auto, ltr, rtl {
		html -Dir $_ | Should-BeString "<html dir=""$_""></html>" -CaseSensitive
	}

	It 'should handle the "id" attribute' {
		article -Id foo | Should-BeString '<article id="foo"></article>' -CaseSensitive
	}

	It 'should support the "lang" attribute' -ForEach "fr-FR", "en-US" {
		html -Lang $_ | Should-BeString "<html lang=""$_""></html>" -CaseSensitive
	}

	It 'should handle the "role" attribute' {
		div -Role button | Should-BeString '<div role="button"></div>' -CaseSensitive
	}

	It 'should handle the "style" attribute' {
		$expected = '<code style="font-family: &quot;Segoe UI&quot;; font-size: 1rem"></code>'
		code -Style ([ordered]@{ FontFamily = '"Segoe UI"'; FontSize = "1rem" }) | Should-BeString $expected -CaseSensitive
	}

	It 'should handle the "tabindex" attribute' -ForEach -1, 0 {
		div -TabIndex $_ | Should-BeString "<div tabindex=""$_""></div>" -CaseSensitive
	}

	It 'should handle the "title" attribute' -ForEach "", 'A "custom" label.' {
		div -Title $_ | Should-BeString ($_ ? '<div title="A &quot;custom&quot; label."></div>' : "<div></div>") -CaseSensitive
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
		button -Hx @{ "On:app:click" = "alert('Hello!')" } | Should-BeString '<button hx-on:app:click="alert(''Hello!'')"></button>' -CaseSensitive
	}

	It "should handle event handler attributes" {
		$expected = '<button onclick="submit(event)" oncontextmenu="showMenu()"></button>', '<button oncontextmenu="showMenu()" onclick="submit(event)"></button>'
		$expected | Should-ContainCollection (button -On @{ Click = "submit(event)"; ContextMenu = "showMenu()" })
	}

	It "should handle switch parameters in attribute values" {
		input -Attributes @{ disabled = $false; required = $true } | Should-BeString "<input required>" -CaseSensitive
	}

	It "should handle the inner content" {
		$expected = "<main><div>Foo &gt; Bar <span>Baz &lt; Qux</span></div></main>"
		main { div { "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } } | Should-BeString $expected -CaseSensitive
		{ "Foo &gt; Bar"; " "; span "Baz &lt; Qux" } | div | main | Should-BeString $expected -CaseSensitive

		$expected = '<head><meta charset="utf-8"></head>'
		head { meta -Charset utf-8 } | Should-BeString $expected -CaseSensitive
		meta -Charset utf-8 | head | Should-BeString $expected -CaseSensitive
	}
}
