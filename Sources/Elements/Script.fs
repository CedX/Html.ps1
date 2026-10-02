namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `script` element.
[<Cmdlet(VerbsCommon.New, "HtmlScriptElement"); Alias("script"); OutputType(typeof<string>)>]
type NewScriptElementCommand () =
  inherit NewElementCommand ("script", isVoid = false)

  /// Value indicating whether the script will be fetched in parallel to parsing and evaluated as soon as it is available.
  [<Parameter>]
  member val Async = SwitchParameter false with get, set

  /// Value indicating whether CORS must be used when fetching the resource.
  [<Parameter; ValidateSet("anonymous", "use-credentials")>]
  member val CrossOrigin: string | null = null with get, set

  /// Value indicating whether the script is meant to be executed after the document has been parsed, but before firing `DOMContentLoaded` event.
  [<Parameter>]
  member val Defer = SwitchParameter false with get, set

  /// A base64-encoded cryptographic hash of the resource (file) to fetch.
  [<Parameter>]
  member val Integrity = "" with get, set

  /// The URI of an external script.
  [<Parameter>]
  member val Src: Uri | null = null with get, set

  /// The type of script represented.
  [<Parameter>]
  member val Type = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.Src with null -> () | value -> attributes["src"] <- value
    if this.Async.IsPresent then attributes["async"] <- true
    match this.CrossOrigin with null -> () | value -> attributes["crossorigin"] <- value
    if this.Defer.IsPresent then attributes["defer"] <- true
    if not (String.IsNullOrWhiteSpace this.Integrity) then attributes["integrity"] <- this.Integrity
    if not (String.IsNullOrWhiteSpace this.Type) then attributes["type"] <- this.Type
