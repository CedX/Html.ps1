using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `Use-Layout` cmdlet.
#>
Describe "Use-Layout" {
	It "should render the specified HTML content inside the given layout" {
		$data = @{ AppName = "My Application"; Title = "The headline"; Year = 2025 }
		$html = layout "$PSScriptRoot/../Resources/Views/Layout.ps1" (& "$PSScriptRoot/../Resources/Views/Content.ps1" $data) -Data $data
		$html | Should -BeLikeExactly '<!doctype html><html lang="*"><head>*<title>My Application</title>*'
		$html | Should -BeLikeExactly '*<header>*<div class="ms-2">My Application</div>*</header>*'
		$html | Should -BeLikeExactly '*<h1>The headline</h1><div class="alert alert-success">Welcome to my website!</div>*'
		$html | Should -BeLikeExactly '*<footer class="text-center">Copyright &copy; 2025 - All rights reserved.</footer></body></html>'
	}
}
