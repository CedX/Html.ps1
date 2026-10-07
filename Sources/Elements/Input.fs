namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation
open System.Net.Mime
open System.Text.RegularExpressions

/// Creates a new `input` element.
[<Cmdlet(VerbsCommon.New, "HtmlInputElement"); Alias("input"); OutputType(typeof<string>)>]
type NewInputElement() =
  inherit NewElementCommand("input", isVoid = true)

  /// Defines which file types are selectable in a file upload control.
  /// Valid for the `file` input type only.
  [<Parameter>]
  member val Accept = "" with get, set

  /// A text to display on browsers that do not display images.
  /// Valid for the `image` input type only.
  [<Parameter>]
  member val Alt: string | null = null with get, set

  /// A hint for a user agent's autocomplete feature.
  [<Parameter>]
  member val AutoComplete: string array = [||] with get, set

  /// Value indicating which camera to use for capture of image or video data.
  [<Parameter; ValidateSet("environment", "user")>]
  member val Capture: string | null = null with get, set

  /// Value indicating whether the checkbox is checked or the radio button is the currently selected one.
  [<Parameter>]
  member val Checked = SwitchParameter false with get, set

  /// The field name to use for sending the element's directionality in form submission.
  [<Parameter>]
  member val DirName = "" with get, set

  /// Value indicating whether to prevent the user from interacting with the element.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form = "" with get, set

  /// The URL that processes the information submitted by the button.
  /// Valid for the `image` and `submit` input types only.
  [<Parameter>]
  member val FormAction: Uri | null = null with get, set

  /// Value indicating how to encode the form data that is submitted.
  /// Valid for the `image` and `submit` input types only.
  [<Parameter; ValidateSet(MediaTypeNames.Application.FormUrlEncoded, MediaTypeNames.Multipart.FormData, MediaTypeNames.Text.Plain)>]
  member val FormEnctype: string | null = null with get, set

  /// The HTTP method used to submit the form.
  /// Valid for the `image` and `submit` input types only.
  [<Parameter; ValidateSet("dialog", "get", "post")>]
  member val FormMethod: string | null = null with get, set

  /// Value indicating whether the form is not to be validated when it is submitted.
  /// Valid for the `image` and `submit` input types only.
  [<Parameter>]
  member val FormNoValidate = SwitchParameter false with get, set

  /// The browsing context to show the response after submitting the form.
  /// Valid for the `image` and `submit` input types only.
  [<Parameter>]
  member val FormTarget = "" with get, set

  /// The intrinsic height of the image, in CSS pixels.
  /// Valid for the `image` input type only.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// The identifier of a `datalist` element located in the same document..
  [<Parameter>]
  member val List = "" with get, set

  /// The greatest value in the range of permitted values.
  [<Parameter>]
  member val Max = "" with get, set

  /// The maximum string length that the user can enter.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val MaxLength = -1 with get, set

  /// The lowest value in the range of permitted values.
  [<Parameter>]
  member val Min = "" with get, set

  /// The minimum string length required that the user should enter.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val MinLength = -1 with get, set

  /// Value indicating whether the user can enter comma separated email addresses in the `email` widget or can choose more than one file with the `file` input.
  [<Parameter>]
  member val Multiple = SwitchParameter false with get, set

  /// The name of the control.
  [<Parameter>]
  member val Name = "" with get, set

  /// The regular expression that the `Value` must match in order for the value to pass constraint validation.
  [<Parameter>]
  member val Pattern: Regex | null = null with get, set

  /// A hint to the user of what can be entered in the control.
  [<Parameter>]
  member val Placeholder = "" with get, set

  /// The identifier of a popover element to control.
  [<Parameter>]
  member val PopoverTarget = "" with get, set

  /// The action to be performed on a popover element being controlled via the `PopoverTarget` attribute.
  [<Parameter; ValidateSet("hide", "show", "toggle")>]
  member val PopoverTargetAction: string | null = null with get, set

  /// Value indicating whether the user cannot modify the value of the control.
  [<Parameter>]
  member val ReadOnly = SwitchParameter false with get, set

  /// Value indicating whether the user must fill in a value before submitting a form.
  [<Parameter>]
  member val Required = SwitchParameter false with get, set

  /// Value indicating how much of the input is shown.
  [<Parameter; ValidateRange(ValidateRangeKind.Positive)>]
  member val Size = 0 with get, set

  /// The URL of the image file to display to represent the graphical button.
  /// Valid for the `image` input type only.
  [<Parameter>]
  member val Src: Uri | null = null with get, set

  /// A number that specifies the granularity that the value must adhere to, or the special value `any`.
  [<Parameter>]
  member val Step = "" with get, set

  /// The type of control to render.
  [<Parameter; ValidateSet(
    "button", "checkbox", "color", "date", "datetime-local", "email",
    "file", "hidden", "image", "month", "number", "password",
    "radio", "range", "reset", "search", "submit", "tel",
    "text", "time", "url", "week"
  )>]
  member val Type: string | null = null with get, set

  /// The value of the control.
  [<Parameter>]
  member val Value: objnull = null with get, set

  /// The intrinsic width of the image, in CSS pixels.
  /// Valid for the `image` input type only.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Accept) then attributes["accept"] <- this.Accept
    match this.Alt with null -> () | value -> attributes["alt"] <- value
    if this.AutoComplete.Length > 0 then attributes["autocomplete"] <- (String.concat " " this.AutoComplete).Trim()
    match this.Capture with null -> () | value -> attributes["capture"] <- value
    if this.Checked.IsPresent then attributes["checked"] <- true
    if not (String.IsNullOrWhiteSpace this.DirName) then attributes["dirname"] <- this.DirName
    if this.Disabled.IsPresent then attributes["disabled"] <- true
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    match this.FormAction with null -> () | value -> attributes["formaction"] <- value
    match this.FormEnctype with null -> () | value -> attributes["formenctype"] <- value
    match this.FormMethod with null -> () | value -> attributes["formmethod"] <- value
    if this.FormNoValidate.IsPresent then attributes["formnovalidate"] <- true
    if not (String.IsNullOrWhiteSpace this.FormTarget) then attributes["formtarget"] <- this.FormTarget
    if this.Height >= 0 then attributes["height"] <- this.Height
    if not (String.IsNullOrWhiteSpace this.List) then attributes["list"] <- this.List
    if not (String.IsNullOrWhiteSpace this.Max) then attributes["max"] <- this.Max
    if this.MaxLength >= 0 then attributes["maxlength"] <- this.MaxLength
    if not (String.IsNullOrWhiteSpace this.Min) then attributes["min"] <- this.Min
    if this.MinLength >= 0 then attributes["minlength"] <- this.MinLength
    if this.Multiple.IsPresent then attributes["multiple"] <- true
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    match this.Pattern with null -> () | value -> attributes["pattern"] <- (string value).Replace(@"\", @"\\")
    if not (String.IsNullOrWhiteSpace this.Placeholder) then attributes["placeholder"] <- this.Placeholder
    if not (String.IsNullOrWhiteSpace this.PopoverTarget) then attributes["popovertarget"] <- this.PopoverTarget
    match this.PopoverTargetAction with null -> () | value -> attributes["popovertargetaction"] <- value
    if this.ReadOnly.IsPresent then attributes["readonly"] <- true
    if this.Required.IsPresent then attributes["required"] <- true
    if this.Size > 0 then attributes["size"] <- this.Size
    if not (String.IsNullOrWhiteSpace this.Step) then attributes["step"] <- this.Step
    match this.Type with null -> () | value -> attributes["type"] <- value
    match this.Value with null -> () | value -> attributes["value"] <- value
    if this.Width >= 0 then attributes["width"] <- this.Width
