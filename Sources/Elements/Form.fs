namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation
open System.Net.Mime

/// Creates a new `form` element.
[<Cmdlet(VerbsCommon.New, "HtmlFormElement"); Alias("form"); OutputType(typeof<string>)>]
type NewFormElement() =
  inherit NewElementCommand("form", isVoid = false)

  /// The URL that processes the form submission.
  [<Parameter>]
  member val Action: Uri | null = null with get, set

  /// Value indicating whether input elements can by default have their values automatically completed by the browser.
  [<Parameter; ValidateSet("off", "on")>]
  member val AutoComplete: string | null = null with get, set

  /// The media type of the form submission.
  [<Parameter; ValidateSet(MediaTypeNames.Application.FormUrlEncoded, MediaTypeNames.Multipart.FormData, MediaTypeNames.Text.Plain)>]
  member val EncType: string | null = null with get, set

  /// The HTTP method to submit the form with.
  [<Parameter; ValidateSet("dialog", "get", "post")>]
  member val Method: string | null = null with get, set

  /// The name of the form.
  [<Parameter>]
  member val Name = "" with get, set

  /// Value indicating whether the form shouldn't be validated when submitted.
  [<Parameter>]
  member val NoValidate = SwitchParameter false with get, set

  /// The annotations and what kinds of links the form creates.
  [<Parameter>]
  member val Rel: string array = [||] with get, set

  /// The browsing context to show the response after submitting the form.
  [<Parameter>]
  member val Target = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.Action with null -> () | value -> attributes["action"] <- value
    match this.AutoComplete with null -> () | value -> attributes["autocomplete"] <- value
    match this.EncType with null -> () | value -> attributes["enctype"] <- value
    match this.Method with null -> () | value -> attributes["method"] <- value
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    if this.NoValidate.IsPresent then attributes["novalidate"] <- true
    if this.Rel.Length > 0 then attributes["rel"] <- (String.concat " " this.Rel).Trim()
    if not (String.IsNullOrWhiteSpace this.Target) then attributes["target"] <- this.Target
