using module ../Html.psd1

<#
.SYNOPSIS
	Tests the features of the `New-DataUri` cmdlet.
#>
Describe "New-DataUri" {
	It "should create a data URI from the specified file" {
		$file = "$PSScriptRoot/../Resources/DataUri.gif"
		$dataUri = New-HtmlDataUri $file -MediaType image/gif
		Should-BeString "data:image/gif;base64,R0lGODlhAQABAHAAACwAAAAAAQABAIH///8AAAAAAAAAAAACAkQBADs=" $dataUri.ToString()
	}

	It "should create a data URI from the specified byte stream" {
		$bytes = Get-Content "$PSScriptRoot/../Resources/DataUri.gif" -AsByteStream
		$dataUri = New-HtmlDataUri $bytes -MediaType image/gif
		Should-BeString "data:image/gif;base64,R0lGODlhAQABAHAAACwAAAAAAQABAIH///8AAAAAAAAAAAACAkQBADs=" $dataUri.ToString()
	}
}
