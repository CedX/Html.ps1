namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `area` element.
[<Cmdlet(VerbsCommon.New, "HtmlAreaElement"); Alias("area"); OutputType(typeof<string>)>]
type NewAreaElement() =
  inherit NewElementCommand("area", isVoid = true)

  /// A text to display on browsers that do not display images.
  [<Parameter>]
  member val Alt: string | null = null with get, set

  /// The browsing context to show the results of navigation.
  [<Parameter; ValidateCount(3, Int32.MaxValue)>]
  member val Coords: float array = [||] with get, set

  /// The suggested filename when the browser treats the linked URL as a download.
  [<Parameter>]
  member val Download = "" with get, set

  /// The hyperlink target for the area.
  [<Parameter(Mandatory = true)>]
  member val Href: Uri | null = null with get, set

  /// A list of URLs. When the link is followed, the browser will send `POST` requests with the body `PING` to the URLs.
  [<Parameter>]
  member val Ping: Uri array = [||] with get, set

  /// The relationship of the linked URL.
  [<Parameter>]
  member val Rel: string array = [||] with get, set

  /// The browsing context to show the results of navigation.
  [<Parameter; ValidateSet("circle", "default", "poly", "rect")>]
  member val Shape: string | null = null with get, set

  /// The browsing context to show the results of navigation.
  [<Parameter>]
  member val Target = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["href"] <- this.Href
    match this.Alt with null -> () | value -> attributes["alt"] <- value
    if not (String.IsNullOrWhiteSpace this.Download) then attributes["download"] <- this.Download
    if this.Ping.Length > 0 then attributes["ping"] <- (this.Ping |> Array.map string |> String.concat " ").Trim()
    if this.Rel.Length > 0 then attributes["rel"] <- (String.concat " " this.Rel).Trim()
    if not (String.IsNullOrWhiteSpace this.Target) then attributes["target"] <- this.Target

    match this.Shape with
    | null -> ()
    | shape ->
      attributes["shape"] <- shape
      if shape <> "default" && this.Coords.Length > 0 then attributes["coords"] <- this.Coords |> Array.map string |> String.concat ","
