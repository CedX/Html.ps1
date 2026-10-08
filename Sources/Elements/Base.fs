namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `base` element.
[<Cmdlet(VerbsCommon.New, "HtmlBaseElement"); Alias("base"); OutputType(typeof<string>)>]
type NewBaseElement() =
  inherit NewElement("base", isVoid = true)

  /// The base URL to be used throughout the document for relative URLs.
  [<Parameter(Mandatory = true)>]
  member val Href: Uri | null = null with get, set

  /// The default browsing context to show the results of navigation from elements without explicit `target` attribute.
  [<Parameter>]
  member val Target = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["href"] <- this.Href
    if not (String.IsNullOrWhiteSpace this.Target) then attributes["target"] <- this.Target
