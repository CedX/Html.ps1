using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `Format-HtmlString` cmdlet.
#>
Describe "Format-HtmlString" {
	It "should format the specified HTML string" -ForEach @(
		@{ Value = $null; AsDocument = $true; Expected = "" }
		@{ Value = $null; AsDocument = $false; Expected = "" }
		@{ Value = "<span>Hello World!</span>"; AsDocument = $true; Expected = "<html>`n`t<head></head>`n`t<body>`n`t`t<span>Hello World!</span>`n`t</body>`n</html>" }
		@{ Value = "<span>Hello World!</span>"; AsDocument = $false; Expected = "<span>Hello World!</span>" }
		@{ Value = "<div><b>FooBar</b></div>"; AsDocument = $true; Expected = "<html>`n`t<head></head>`n`t<body>`n`t`t<div>`n`t`t`t<b>FooBar</b>`n`t`t</div>`n`t</body>`n</html>" }
		@{ Value = "<div><b>FooBar</b></div>"; AsDocument = $false; Expected = "<div>`n`t<b>FooBar</b>`n</div>" }
		@{ Value = "<button>Foo</button> <button>Bar</button>"; AsDocument = $true; Expected = "<html>`n`t<head></head>`n`t<body>`n`t`t<button>Foo</button>`n`t`t<button>Bar</button>`n`t</body>`n</html>" }
		@{ Value = "<button>Foo</button> <button>Bar</button>"; AsDocument = $false; Expected = "<button>Foo</button>`n<button>Bar</button>" }
	) {
		Format-HtmlString $value -AsDocument:$asDocument | Should -BeExactly $expected
	}
}
