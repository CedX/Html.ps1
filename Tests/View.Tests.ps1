using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `Use-Layout` cmdlet.
#>
Describe "Use-Layout" {
	It "should render the specified HTML content inside the given layout" {
		$data = @{ AppName = "My Application"; Title = "The headline"; Year = 2025 }
		$html = layout "$PSScriptRoot/../Resources/Views/Layout.ps1" (& "$PSScriptRoot/../Resources/Views/Content.ps1" $data) -Data $data
		Should-BeLikeString '<!doctype html><html lang="*"><head>*<title>My Application</title>*' $html -CaseSensitive
		Should-BeLikeString '*<header>*<div class="ms-2">My Application</div>*</header>*' $html -CaseSensitive
		Should-BeLikeString '*<h1>The headline</h1><div class="alert alert-success">Welcome to my website!</div>*' $html -CaseSensitive
		Should-BeLikeString '*<footer class="text-center">Copyright &copy; 2025 - All rights reserved.</footer></body></html>' $html -CaseSensitive
	}
}

<#
.SYNOPSIS
	Tests the features of the `Write-View` cmdlet.
#>
Describe "Write-View" {
	It "should render the specified view file as an HTML string" -ForEach @(
		@{ View = "Header"; Data = @{ AppName = "My Application" }; Expected = '<header>*<div class="ms-2">My Application</div>*</header>' }
		@{ View = "Content"; Data = @{ Title = "The headline" }; Expected = '<h1>The headline</h1><div class="alert alert-success">Welcome to my website!</div>' }
		@{ View = "Footer"; Data = @{ Year = 2025 }; Expected = '<footer class="text-center">Copyright &copy; 2025 - All rights reserved.</footer>' }
	) {
		Should-BeLikeString $expected (Write-HtmlView "$PSScriptRoot/../Resources/Views/$view.ps1" -Data $data) -CaseSensitive
	}
}
