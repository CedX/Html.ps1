using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-LinkElement` cmdlet.
#>
Describe "New-LinkElement" {
	It 'should support the "href" and "rel" attributes' {
		link -Rel icon -Href /Favicon.ico | Should-BeString '<link rel="icon" href="/Favicon.ico">' -CaseSensitive
		link -Rel stylesheet -Href /Assets/Styles.css | Should-BeString '<link rel="stylesheet" href="/Assets/Styles.css">' -CaseSensitive
	}

	It 'should support the "media" attribute' {
		link -Rel alternate, stylesheet -Href Styles.css -Media print | Should-BeString '<link rel="alternate stylesheet" href="Styles.css" media="print">' -CaseSensitive
		link -Rel stylesheet -Href Styles.css -Media "screen and (width >= 600px)" | Should-BeString '<link rel="stylesheet" href="Styles.css" media="screen and (width >= 600px)">' -CaseSensitive
	}

	It 'should support the "sizes" attribute' {
		link -Rel icon -Href Favicon.ico -Sizes any | Should-BeString '<link rel="icon" href="Favicon.ico" sizes="any">' -CaseSensitive
		link -Rel icon -Href Favicon.ico -Sizes 320x200, 160x100 | Should-BeString '<link rel="icon" href="Favicon.ico" sizes="320x200 160x100">' -CaseSensitive
	}
}
