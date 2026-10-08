namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `a` element.
[<Cmdlet(VerbsCommon.New, "HtmlAElement"); Alias("a"); OutputType(typeof<string>)>]
type NewAElement() =
  inherit NewElement("a", isVoid = false)

  /// The suggested filename when the browser treats the linked URL as a download.
  [<Parameter>]
  member val Download = "" with get, set

  /// The URL that the hyperlink points to.
  [<Parameter(Mandatory = true)>]
  member val Href: Uri | null = null with get, set

  /// A list of URLs. When the link is followed, the browser will send `POST` requests with the body `PING` to the URLs.
  [<Parameter>]
  member val Ping: Uri array = [||] with get, set

  /// The relationship of the linked URL.
  [<Parameter>]
  member val Rel: string array = [||] with get, set

  /// The browsing context to show the results of navigation.
  [<Parameter>]
  member val Target = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["href"] <- this.Href
    if not (String.IsNullOrWhiteSpace this.Download) then attributes["download"] <- this.Download
    if this.Ping.Length > 0 then attributes["ping"] <- (this.Ping |> Array.map string |> String.concat " ").Trim()
    if this.Rel.Length > 0 then attributes["rel"] <- (String.concat " " this.Rel).Trim()
    if not (String.IsNullOrWhiteSpace this.Target) then attributes["target"] <- this.Target
