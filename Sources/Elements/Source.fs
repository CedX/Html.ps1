namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `source` element.
[<Cmdlet(VerbsCommon.New, "HtmlSourceElement", DefaultParameterSetName = "Src"); Alias("source"); OutputType(typeof<string>)>]
type NewSourceElement() =
  inherit NewElementCommand("source", isVoid = true)

  /// The intrinsic height of the image, in CSS pixels.
  [<Parameter(ParameterSetName = "SrcSet"); ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// The media query for the resource's intended media.
  [<Parameter(ParameterSetName = "SrcSet")>]
  member val Media = "" with get, set

  /// A list of source sizes that describe the final rendered width of the image.
  [<Parameter(ParameterSetName = "SrcSet")>]
  member val Sizes: string array = [||] with get, set

  /// The URL of the media resource
  [<Parameter(Mandatory = true, ParameterSetName = "Src")>]
  member val Src: Uri | null = null with get, set

  /// A list of one or more image URLs and their descriptors.
  [<Parameter(Mandatory = true, ParameterSetName = "SrcSet")>]
  member val SrcSet: string array = [||] with get, set

  /// The media type to use, optionally including a `codecs` parameter.
  [<Parameter>]
  member val Type = "" with get, set

  /// The intrinsic width of the image, in CSS pixels.
  [<Parameter(ParameterSetName = "SrcSet"); ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Type) then attributes["type"] <- this.Type

    match this.ParameterSetName with
    | "Src" -> attributes["src"] <- this.Src
    | "SrcSet" ->
      attributes["srcset"] <- String.concat ", " this.SrcSet
      if this.Height >= 0 then attributes["height"] <- this.Height
      if not (String.IsNullOrWhiteSpace this.Media) then attributes["media"] <- this.Media
      if this.Sizes.Length > 0 then attributes["sizes"] <- String.concat ", " this.Sizes
      if this.Width >= 0 then attributes["width"] <- this.Width
    | _ -> ()
