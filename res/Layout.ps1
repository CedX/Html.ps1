param ([string] $Content, [hashtable] $Data)

doctype
html -Lang $PSCulture {
	head {
		meta -Charset utf-8
		title $Data.AppName

		meta -Name color-scheme -Content light
		meta -Name viewport -Content "initial-scale=1, width=device-width"

		link -Rel icon -Href Favicon.ico
		link -Rel preload -Href Assets/Font.woff2 -As font -CrossOrigin anonymous -Type font/woff2

		link -Rel stylesheet -Href "https://cdn.jsdelivr.net/npm/bootstrap@5/dist/css/bootstrap.css" -Integrity "sha256-2FMn2Zx6PuH5tdBQDRNwrOo60ts5wWPC9R8jK67b3t4"
		link -Rel stylesheet -Href Assets/Styles.css

		script -Src "https://cdn.jsdelivr.net/npm/bootstrap@5/dist/js/bootstrap.js" -Integrity "sha256-ew8UiV1pJH/YjpOEBInP1HxVvT/SfrCmwSoUzF9JIgc="
		script -Src Assets/Scripts.js -Type module
	}

	body {
		& "$PSScriptRoot/Header.ps1" @{ AppName = $Data.AppName }

		main {
			noscript { p "This application requires $(b JavaScript) to be enabled in your browser." }
			article -Class container-xl { $Content }
		}

		& "$PSScriptRoot/Footer.ps1" @{ Year = $Data.Year }
	}
}
