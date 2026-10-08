namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `canvas` element.
[<Cmdlet(VerbsCommon.New, "HtmlCanvasElement"); Alias("canvas"); OutputType(typeof<string>)>]
type NewCanvasElement() =
  inherit NewElement("canvas", isVoid = false)

  /// The height of the coordinate space in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// The width of the coordinate space in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Height >= 0 then attributes["height"] <- this.Height
    if this.Width >= 0 then attributes["width"] <- this.Width
