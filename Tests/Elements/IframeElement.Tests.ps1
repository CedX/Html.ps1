using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-IframeElement` cmdlet.
#>
Describe "New-IframeElement" {
	It 'should support the "width" and "height" attributes' {
		iframe -Src Index.php -Height 200 | Should -BeIn '<iframe height="200" src="Index.php"></iframe>', '<iframe src="Index.php" height="200"></iframe>'
		iframe -Src Index.php -Width 460 | Should -BeIn '<iframe width="460" src="Index.php"></iframe>', '<iframe src="Index.php" width="460"></iframe>'
	}

	It 'should support the "loading" attribute' -ForEach eager, lazy {
		iframe -Src Index.php -Loading $_ | Should -BeIn "<iframe loading=""$_"" src=""Index.php""></iframe>", "<iframe src=""Index.php"" loading=""$_""></iframe>"
	}

	It 'should support the "sandbox" attribute' {
		$expected = '<iframe sandbox="allow-downloads allow-popups" src="Index.php"></iframe>', '<iframe src="Index.php" sandbox="allow-downloads allow-popups"></iframe>'
		iframe -Src Index.php -Sandbox allow-downloads, allow-popups | Should -BeIn $expected
	}
}
