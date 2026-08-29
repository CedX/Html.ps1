using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ScriptElement` cmdlet.
#>
Describe "New-ScriptElement" {
	It 'should support the "src" and "type" attributes' -ForEach @(
		@{ Src = "Scripts.js"; Type = "module" }
		@{ Src = "Scripts._hs"; Type = "text/hyperscript" }
	) {
		Should-BeString "<script src=""$src"" type=""$type""></script>" (script -Src $src -Type $type) -CaseSensitive
	}

	It 'should support the "async" and "defer" attributes' -ForEach @(
		@{ Async = $true; Defer = $false }
		@{ Async = $false; Defer = $true }
	) {
		Should-BeString ($async ? '<script src="Scripts.js" async></script>' : '<script src="Scripts.js" defer></script>') (script -Src Scripts.js -Async:$async -Defer:$defer) -CaseSensitive
	}

	It "should allow inner content" -ForEach @(
		@{ Content = "alert('Hello World!');"; Type = "" }
		@{ Content = "on click call alert('Hello World!')"; Type = "text/hyperscript" }
	) {
		Should-BeString ($type ? "<script type=""$type"">$content</script>" : "<script>$content</script>") (script $content -Type $type) -CaseSensitive
	}
}
