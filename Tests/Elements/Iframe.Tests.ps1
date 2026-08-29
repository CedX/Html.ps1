using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-IframeElement` cmdlet.
#>
Describe "New-IframeElement" {
	It 'should support the "width" and "height" attributes' {
		'<iframe height="200" src="Index.php"></iframe>', '<iframe src="Index.php" height="200"></iframe>' | Should-ContainCollection (iframe -Src Index.php -Height 200)
		'<iframe width="460" src="Index.php"></iframe>', '<iframe src="Index.php" width="460"></iframe>' | Should-ContainCollection (iframe -Src Index.php -Width 460)
	}

	It 'should support the "loading" attribute' -ForEach eager, lazy {
		"<iframe loading=""$_"" src=""Index.php""></iframe>", "<iframe src=""Index.php"" loading=""$_""></iframe>" | Should-ContainCollection (iframe -Src Index.php -Loading $_)
	}

	It 'should support the "sandbox" attribute' {
		$expected = '<iframe sandbox="allow-downloads allow-popups" src="Index.php"></iframe>', '<iframe src="Index.php" sandbox="allow-downloads allow-popups"></iframe>'
		$expected | Should-ContainCollection (iframe -Src Index.php -Sandbox allow-downloads, allow-popups)
	}
}
