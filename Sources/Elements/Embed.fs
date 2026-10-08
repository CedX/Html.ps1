namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `embed` element.
[<Cmdlet(VerbsCommon.New, "HtmlEmbedElement"); Alias("embed"); OutputType(typeof<string>)>]
type NewEmbedElement() =
  inherit NewElement("embed", isVoid = true)

  /// The displayed height of the resource, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// The URL of the resource being embedded.
  [<Parameter(Mandatory = true)>]
  member val Src: Uri | null = null with get, set

  /// The media type to use, optionally including a `codecs` parameter.
  [<Parameter(Mandatory = true)>]
  member val Type = "" with get, set

  /// The displayed height of the resource, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["src"] <- this.Src
    attributes["type"] <- this.Type
    if this.Height >= 0 then attributes["height"] <- this.Height
    if this.Width >= 0 then attributes["width"] <- this.Width
