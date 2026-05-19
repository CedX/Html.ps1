param ([hashtable] $Data)

header {
	nav -Class navbar, navbar-expand-xl {
		div -Class container-fluid {
			button -Class navbar-toggler -DataSet @{ BsTarget = "#menu"; BsToggle = "offcanvas" } {
				span -Class navbar-toggler-icon
			}

			div -Class navbar-brand, d-flex, align-items-center {
				a -Href Index.html { img -Alt "" -Src Favicon.ico -Width 30 -Height 30 }
				div -Class ms-2 $Data.AppName
			}
		}
	}
}
