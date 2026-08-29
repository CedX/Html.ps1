using module ../Html.psd1

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
