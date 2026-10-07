namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `img` element.
[<Cmdlet(VerbsCommon.New, "HtmlImgElement"); Alias("img"); OutputType(typeof<string>)>]
type NewImgElement() =
  inherit NewElementCommand("img", isVoid = true)

  /// A text to display on browsers that do not display images.
  [<Parameter>]
  member val Alt: string | null = null with get, set

  /// The intrinsic height of the image, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// Value indicating whether the image is part of a server-side map.
  [<Parameter>]
  member val IsMap = SwitchParameter false with get, set

  /// Value indicating how the browser should load the image.
  [<Parameter; ValidateSet("eager", "lazy")>]
  member val Loading: string | null = null with get, set

  /// The intended display sizes of the image.
  [<Parameter>]
  member val Sizes: string array = [||] with get, set

  /// The image URL.
  [<Parameter(Mandatory = true)>]
  member val Src: Uri | null = null with get, set

  /// The possible image sources for the user agent to use.
  [<Parameter>]
  member val SrcSet: string array = [||] with get, set

  /// The partial URL (starting with `#`) of an image map associated with the element.
  [<Parameter>]
  member val UseMap = "" with get, set

  /// The intrinsic width of the image, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["src"] <- this.Src
    match this.Alt with null -> () | value -> attributes["alt"] <- value
    if this.Height >= 0 then attributes["height"] <- this.Height
    if this.IsMap.IsPresent then attributes["ismap"] <- true
    match this.Loading with null -> () | value -> attributes["loading"] <- value
    if this.Sizes.Length > 0 then attributes["sizes"] <- String.concat ", " this.Sizes
    if this.SrcSet.Length > 0 then attributes["srcset"] <- String.concat ", " this.SrcSet
    if not (String.IsNullOrWhiteSpace this.UseMap) then attributes["usemap"] <- if this.UseMap.StartsWith '#' then this.UseMap else $"#{this.UseMap}"
    if this.Width >= 0 then attributes["width"] <- this.Width
