using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-AElement` cmdlet.
#>
Describe "New-AElement" {
	It 'should support the "download" attribute' {
		$expected = '<a href="Index.html" download="Evil.js">Click me</a>', '<a download="Evil.js" href="Index.html">Click me</a>'
		a "Click me" -Href Index.html -Download Evil.js | Should -BeIn $expected
	}

	It 'should support the "href" attribute' -ForEach "./Index.html", "mailto:dummy@example.com", "tel:+33123456789" {
		a "Click me" -Href $_ | Should -BeExactly "<a href=""$_"">Click me</a>"
	}

	It 'should support the "ping" attribute' {
		$expected = '<a href="Index.html" ping="https://example.com/ Tracking.php"></a>', '<a ping="https://example.com/ Tracking.php" href="Index.html"></a>'
		a -Href Index.html -Ping "https://example.com/", Tracking.php | Should -BeIn $expected
	}

	It 'should support the "rel" attribute' {
		$expected = '<a href="Index.html" rel="external nofollow"></a>', '<a rel="external nofollow" href="Index.html"></a>'
		a -Href Index.html -Rel external, nofollow | Should -BeIn $expected
	}

	It 'should support the "target" attribute' -ForEach "_blank", "my-iframe" {
		$expected = "<a href=""Index.html"" target=""$_"">Click me</a>", "<a target=""$_"" href=""Index.html"">Click me</a>"
		a "Click me" -Href Index.html -Target $_ | Should -BeIn $expected
	}
}
