namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `iframe` element.
[<Cmdlet(VerbsCommon.New, "HtmlIframeElement"); Alias("iframe"); OutputType(typeof<string>)>]
type NewIframeElement() =
  inherit NewElementCommand("iframe", isVoid = false)

  /// Specifies a permissions policy thaht defines what features are available to the frame based on the origin of the request.
  [<Parameter>]
  member val Allow = "" with get, set

  /// The height of the frame in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// Value indicating how the browser should load the frame.
  [<Parameter; ValidateSet("eager", "lazy")>]
  member val Loading: string | null = null with get, set

  /// A targetable name for the embedded browsing context.
  [<Parameter>]
  member val Name = "" with get, set

  /// Value indicating which referrer to send when fetching the frame's resource.
  [<Parameter; ValidateSet(
    "no-referrer-when-downgrade", "no-referrer", "origin-when-cross-origin", "origin",
    "same-origin", "strict-origin-when-cross-origin", "strict-origin", "unsafe-url"
  )>]
  member val ReferrerPolicy: string | null = null with get, set

  /// The restrictions applied to the content embedded in the frame.
  [<Parameter>]
  member val Sandbox: string array = [||] with get, set

  /// The URL of the page to embed.
  [<Parameter(Mandatory = true)>]
  member val Src: Uri | null = null with get, set

  /// The width of the frame in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["src"] <- this.Src
    if not (String.IsNullOrWhiteSpace this.Allow) then attributes["allow"] <- this.Allow
    if this.Height >= 0 then attributes["height"] <- this.Height
    match this.Loading with null -> () | value -> attributes["loading"] <- value
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    match this.ReferrerPolicy with null -> () | value -> attributes["referrerpolicy"] <- value
    if this.Sandbox.Length > 0 then attributes["sandbox"] <- (String.concat " " this.Sandbox).Trim()
    if this.Width >= 0 then attributes["width"] <- this.Width
