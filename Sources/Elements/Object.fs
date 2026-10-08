namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `object` element.
[<Cmdlet(VerbsCommon.New, "HtmlObjectElement"); Alias("object"); OutputType(typeof<string>)>]
type NewObjectElement() =
  inherit NewElement("object", isVoid = false)

  /// The URL of the resource being embedded.
  [<Parameter(Mandatory = true)>]
  member val Data: Uri | null = null with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form = "" with get, set

  /// The height of the display resource, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// The name of valid browsing context (HTML 5), or the name of the control (HTML 4).
  [<Parameter>]
  member val Name = "" with get, set

  /// The media type to use, optionally including a `codecs` parameter.
  [<Parameter(Mandatory = true)>]
  member val Type = "" with get, set

  /// The width of the display resource, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["data"] <- this.Data
    attributes["type"] <- this.Type
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    if this.Height >= 0 then attributes["height"] <- this.Height
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    if this.Width >= 0 then attributes["width"] <- this.Width
