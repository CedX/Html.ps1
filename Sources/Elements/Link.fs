namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `link` element.
[<Cmdlet(VerbsCommon.New, "HtmlLinkElement"); Alias("link"); OutputType(typeof<string>)>]
type NewLinkElementCommand () =
  inherit NewElementCommand ("link", isVoid = true)

  /// Specifies the type of content being loaded by the `link`.
  [<Parameter>]
  member val As = "" with get, set

  /// Value indicating whether CORS must be used when fetching the resource.
  [<Parameter; ValidateSet("anonymous", "use-credentials")>]
  member val CrossOrigin: string | null = null with get, set

  /// The URL of the linked resource.
  [<Parameter(Mandatory = true)>]
  member val Href: Uri | null = null with get, set

  /// A base64-encoded cryptographic hash of the resource (file) to fetch.
  [<Parameter>]
  member val Integrity = "" with get, set

  /// The media that the linked resource applies to.
  [<Parameter>]
  member val Media = "" with get, set

  /// The relationship of the linked resource to the current document.
  [<Parameter(Mandatory = true)>]
  member val Rel: string array = [||] with get, set

  /// The sizes of the icons for visual media contained in the resource.
  [<Parameter>]
  member val Sizes: string array = [||] with get, set

  /// The media type of the content linked to.
  [<Parameter>]
  member val Type = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["rel"] <- (String.concat " " this.Rel).Trim()
    attributes["href"] <- this.Href
    if not (String.IsNullOrWhiteSpace this.As) then attributes["as"] <- this.As
    match this.CrossOrigin with null -> () | value -> attributes["crossorigin"] <- value
    if not (String.IsNullOrWhiteSpace this.Integrity) then attributes["integrity"] <- this.Integrity
    if not (String.IsNullOrWhiteSpace this.Media) then attributes["media"] <- this.Media
    if this.Sizes.Length > 0 then attributes["sizes"] <- (String.concat " " this.Sizes).Trim()
    if not (String.IsNullOrWhiteSpace this.Type) then attributes["type"] <- this.Type
