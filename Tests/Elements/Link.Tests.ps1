using module ../../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-LinkElement` cmdlet.
#>
Describe "New-LinkElement" {
	It 'should support the "href" and "rel" attributes' {
		Should-BeString '<link rel="icon" href="/Favicon.ico">' (link -Rel icon -Href /Favicon.ico) -CaseSensitive
		Should-BeString '<link rel="stylesheet" href="/Assets/Styles.css">' (link -Rel stylesheet -Href /Assets/Styles.css) -CaseSensitive
	}

	It 'should support the "media" attribute' {
		Should-BeString '<link rel="alternate stylesheet" href="Styles.css" media="print">' (link -Rel alternate, stylesheet -Href Styles.css -Media print) -CaseSensitive
		Should-BeString '<link rel="stylesheet" href="Styles.css" media="screen and (width >= 600px)">' (link -Rel stylesheet -Href Styles.css -Media "screen and (width >= 600px)") -CaseSensitive
	}

	It 'should support the "sizes" attribute' {
		Should-BeString '<link rel="icon" href="Favicon.ico" sizes="any">' (link -Rel icon -Href Favicon.ico -Sizes any) -CaseSensitive
		Should-BeString '<link rel="icon" href="Favicon.ico" sizes="320x200 160x100">' (link -Rel icon -Href Favicon.ico -Sizes 320x200, 160x100) -CaseSensitive
	}
}
