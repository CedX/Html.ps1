using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-ObjectElement` cmdlet.
#>
Describe "New-ObjectElement" {
	It 'should support the "data" and "type" attributes' {
		object -Data Image.jpg -Type image/jpeg | Should -BeIn '<object data="Image.jpg" type="image/jpeg"></object>', '<object type="image/jpeg" data="Image.jpg"></object>'
	}
}
