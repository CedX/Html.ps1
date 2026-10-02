namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `svg` element.
[<Cmdlet(VerbsCommon.New, "HtmlSvgElement"); Alias("svg"); OutputType(typeof<string>)>]
type NewSvgElementCommand() =
  inherit NewElementCommand("svg", isVoid = false)

  /// The intrinsic height of the image, in CSS pixels.
  [<Parameter>]
  member val Height = "" with get, set

  /// Value indicating how the SVG fragment must be deformed if it is displayed with a different aspect ratio.
  [<Parameter>]
  member val PreserveAspectRatio = "" with get, set

  /// The SVG viewport coordinates for the current SVG fragment.
  [<Parameter; ValidateCount(4, 4)>]
  member val ViewBox: float array = [||] with get, set

  /// The intrinsic width of the image, in CSS pixels.
  [<Parameter>]
  member val Width = "" with get, set

  /// The displayed X coordinate of the SVG container.
  [<Parameter>]
  member val X = "" with get, set

  /// The displayed Y coordinate of the SVG container.
  [<Parameter>]
  member val Y = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Height) then attributes["height"] <- this.Height
    if not (String.IsNullOrWhiteSpace this.PreserveAspectRatio) then attributes["preserveAspectRatio"] <- this.PreserveAspectRatio
    if this.ViewBox.Length > 0 then attributes["viewBox"] <- this.ViewBox |> Array.map string |> String.concat " "
    if not (String.IsNullOrWhiteSpace this.Width) then attributes["width"] <- this.Width
    if not (String.IsNullOrWhiteSpace this.X) then attributes["x"] <- this.X
    if not (String.IsNullOrWhiteSpace this.Y) then attributes["y"] <- this.Y
