namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation
open System.Net.Mime

/// Creates a new `button` element.
[<Cmdlet(VerbsCommon.New, "HtmlButtonElement"); Alias("button"); OutputType(typeof<string>)>]
type NewButtonElementCommand() =
  inherit NewElementCommand("button", isVoid = false)

  /// The action to be performed on an element being controlled via the `CommandFor` attribute.
  [<Parameter>]
  member val Command = "" with get, set

  /// The identifier of an element to control.
  [<Parameter>]
  member val CommandFor = "" with get, set

  /// Value indicating whether to prevent the user from interacting with the element.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form = "" with get, set

  /// The URL that processes the information submitted by the button.
  [<Parameter>]
  member val FormAction: Uri | null = null with get, set

  /// Value indicating how to encode the form data that is submitted.
  [<Parameter; ValidateSet(MediaTypeNames.Application.FormUrlEncoded, MediaTypeNames.Multipart.FormData, MediaTypeNames.Text.Plain)>]
  member val FormEnctype: string | null = null with get, set

  /// The HTTP method used to submit the form.
  [<Parameter; ValidateSet("dialog", "get", "post")>]
  member val FormMethod: string | null = null with get, set

  /// Value indicating whether the form is not to be validated when it is submitted.
  [<Parameter>]
  member val FormNoValidate = SwitchParameter false with get, set

  /// The browsing context to show the response after submitting the form.
  [<Parameter>]
  member val FormTarget = "" with get, set

  /// The name of the control.
  [<Parameter>]
  member val Name = "" with get, set

  /// The identifier of a popover element to control.
  [<Parameter>]
  member val PopoverTarget = "" with get, set

  /// The action to be performed on a popover element being controlled via the `PopoverTarget` attribute.
  [<Parameter; ValidateSet("hide", "show", "toggle")>]
  member val PopoverTargetAction: string | null = null with get, set

  /// The default behavior of the button.
  [<Parameter; ValidateSet("button", "reset", "submit")>]
  member val Type: string | null = null with get, set

  /// The value of the control.
  [<Parameter>]
  member val Value: objnull = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Command) then attributes["command"] <- this.Command
    if not (String.IsNullOrWhiteSpace this.CommandFor) then attributes["commandfor"] <- this.CommandFor
    if this.Disabled.IsPresent then attributes["disabled"] <- true
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    match this.FormAction with null -> () | value -> attributes["formaction"] <- value
    match this.FormEnctype with null -> () | value -> attributes["formenctype"] <- value
    match this.FormMethod with null -> () | value -> attributes["formmethod"] <- value
    if this.FormNoValidate.IsPresent then attributes["formnovalidate"] <- true
    if not (String.IsNullOrWhiteSpace this.FormTarget) then attributes["formtarget"] <- this.FormTarget
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    if not (String.IsNullOrWhiteSpace this.PopoverTarget) then attributes["popovertarget"] <- this.PopoverTarget
    match this.PopoverTargetAction with null -> () | value -> attributes["popovertargetaction"] <- value
    match this.Type with null -> () | value -> attributes["type"] <- value
    match this.Value with null -> () | value -> attributes["value"] <- value
