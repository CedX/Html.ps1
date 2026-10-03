using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-BaseElement` cmdlet.
#>
Describe "New-BaseElement" {
	It 'should support the "href" attribute' -ForEach "/base/", "https://localhost/base/" {
		base -Href $_ | Should-BeString "<base href=""$_"">" -CaseSensitive
	}

	It 'should support the "target" attribute' -ForEach "_blank", "my-iframe" {
		base -Href /base/ -Target $_ | Should-BeString "<base href=""/base/"" target=""$_"">" -CaseSensitive
	}
}
