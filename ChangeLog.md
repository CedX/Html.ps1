# Changelog

## Version [4.0.0](https://github.com/CedX/Html.ps1/compare/v3.0.1...v4.0.0)
- Breaking change: removed the `Format-HtmlString` cmdlet.
- Removed the dependency on [AngleSharp](https://anglesharp.github.io).

## Version [3.0.1](https://github.com/CedX/Html.ps1/compare/v3.0.0...v3.0.1)
- Fixed the `-Max`, `-Min` and `-Step` parameters of the `New-HtmlInputElement` cmdlet.

## Version [3.0.0](https://github.com/CedX/Html.ps1/compare/v2.3.0...v3.0.0)
- Breaking change: renamed the `-Encoder` parameter of the `Protect-HtmlString` cmdlet to `-Encoding`.
- Added the `Format-HtmlString` cmdlet.

## Version [2.3.0](https://github.com/CedX/Html.ps1/compare/v2.2.0...v2.3.0)
- Added the `-Aria`, `-Inert`, `-Role` and `-Slot` common parameters.

## Version [2.2.0](https://github.com/CedX/Html.ps1/compare/v2.1.1...v2.2.0)
- Added the `New-HtmlSvgElement` and `Protect-HtmlString` cmdlets.
- Added the `svg` and `esc` aliases.

## Version [2.1.1](https://github.com/CedX/Html.ps1/compare/v2.1.0...v2.1.1)
- Fixed a packaging issue: the advanced functions were not included in the release.

## Version [2.1.0](https://github.com/CedX/Html.ps1/compare/v2.0.0...v2.1.0)
- Merged the nested [PowerShell](https://learn.microsoft.com/en-us/powershell) modules into a single main module.

## Version [2.0.0](https://github.com/CedX/Html.ps1/compare/v1.2.0...v2.0.0)
- Breaking change: removed the `ValueFromPipelineByPropertyName` attribute from all cmdlet parameters.
- Breaking change: removed the `-Void` parameter from the `New-HtmlCustomElement` cmdlet.

## Version [1.2.0](https://github.com/CedX/Html.ps1/compare/v1.1.0...v1.2.0)
- Added the `Use-HtmlLayout` and `Write-HtmlView` cmdlets.

## Version [1.1.0](https://github.com/CedX/Html.ps1/compare/v1.0.1...v1.1.0)
- Added support for `[switch]` parameters in attribute values.
- The `New-HtmlDelElement`, `New-HtmlInsElement` and `New-HtmlTimeElement` cmdlets now use a non-terminating error.

## Version [1.0.1](https://github.com/CedX/Html.ps1/compare/v1.0.0...v1.0.1)
- Fixed a packaging issue: the generated cmdlets were not included in the release.

## Version [1.0.0](https://github.com/CedX/Html.ps1/compare/v0.10.0...v1.0.0)
- Added the `New-HtmlFormElement`, `New-HtmlIframeElement`, `New-HtmlInputElement`, `New-HtmlTemplateElement` and `New-HtmlTextareaElement` cmdlets.
- Added the `form`, `iframe`, `input`, `template` and `textarea` aliases.

## Version [0.10.0](https://github.com/CedX/Html.ps1/compare/v0.9.0...v0.10.0)
- Added the `New-HtmlButtonElement`, `New-HtmlQElement`, `New-HtmlSelectElement`, `New-HtmlSlotElement` and `New-HtmlSourceElement` cmdlets.
- Added the `button`, `q`, `selectTag`, `slot` and `source` aliases.
- The common parameter `-Style` is now an `OrderedHashtable`, allowing the declaration order to be preserved.

## Version [0.9.0](https://github.com/CedX/Html.ps1/compare/v0.8.0...v0.9.0)
- Added the `New-HtmlOlElement`, `New-HtmlOptgroupElement`, `New-HtmlOptionElement`, `New-HtmlOutputElement` and `New-HtmlProgressElement` cmdlets.
- Added the `ol`, `optgroup`, `option`, `output` and `progress` aliases.

## Version [0.8.0](https://github.com/CedX/Html.ps1/compare/v0.7.0...v0.8.0)
- Added the `New-HtmlLabelElement`, `New-HtmlLiElement`, `New-HtmlMapElement`, `New-HtmlMeterElement` and `New-HtmlObjectElement` cmdlets.
- Added the `label`, `li`, `map`, `meter` and `object` aliases.
- Renamed the common parameter `-Data` to `-DataSet`.

## Version [0.7.0](https://github.com/CedX/Html.ps1/compare/v0.6.0...v0.7.0)
- Added the `New-HtmlDetailsElement`, `New-HtmlDialogElement`, `New-HtmlEmbedElement`, `New-HtmlFieldsetElement` and `New-HtmlInsElement` cmdlets.
- Added the `details`, `dialog`, `embed`, `fieldset` and `ins` aliases.

## Version [0.6.0](https://github.com/CedX/Html.ps1/compare/v0.5.0...v0.6.0)
- Added the `Html` prefix to the nouns of all cmdlets.
- Added the `New-HtmlDelElement`, `New-HtmlTdElement`, `New-HtmlThElement`, `New-HtmlTimeElement` and `New-HtmlTrackElement` cmdlets.
- Added the `delTag`, `td`, `th`, `time` and `track` aliases.

## Version [0.5.0](https://github.com/CedX/Html.ps1/compare/v0.4.0...v0.5.0)
- Added the `New-HtmlColGroupElement`, `New-HtmlDataElement`, `New-HtmlStyleElement` and `New-HtmlVideoElement` cmdlets.
- Added the `colgroup`, `dataTag`, `style` and `video` aliases.

## Version [0.4.0](https://github.com/CedX/Html.ps1/compare/v0.3.0...v0.4.0)
- Added support for the `on*` and `tabindex` attributes.
- Added the `New-HtmlAudioElement`, `New-HtmlBlockquoteElement`, `New-HtmlCanvasElement` and `New-HtmlColElement` cmdlets.
- Added the `audio`, `blockquote`, `canvas` and `col` aliases.
- Renamed the `New-HtmlDoctype` cmdlet to `New-HtmlDocumentType`.

## Version [0.3.0](https://github.com/CedX/Html.ps1/compare/v0.2.0...v0.3.0)
- Added support for the `data-*`, `dir`, `lang` and `title` attributes.
- Added the `New-HtmlAElement`, `New-HtmlAreaElement`, `New-HtmlImgElement` and `New-HtmlScriptElement` cmdlets.
- Added the `a`, `area`, `img` and `script` aliases.

## Version [0.2.0](https://github.com/CedX/Html.ps1/compare/v0.1.0...v0.2.0)
- Added the `New-HtmlBaseElement`, `New-HtmlHtmlElement`, `New-HtmlLinkElement` and `New-HtmlMetaElement` cmdlets.
- Added the `base`, `html`, `link` and `meta` aliases.

## Version 0.1.0
- Initial release.
