using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-EmbedElement` cmdlet.
#>
Describe "New-EmbedElement" {
	It 'should support the "src" and "type" attributes' {
		embed -Src Image.jpg -Type image/jpeg | Should -BeIn '<embed src="Image.jpg" type="image/jpeg">', '<embed type="image/jpeg" src="Image.jpg">'
	}
}
