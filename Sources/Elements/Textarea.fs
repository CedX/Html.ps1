namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `textarea` element.
[<Cmdlet(VerbsCommon.New, "HtmlTextareaElement"); Alias("textarea"); OutputType(typeof<string>)>]
type NewTextareaElementCommand () =
  inherit NewElementCommand ("textarea", isVoid = false)

  /// A hint for a user agent's autocomplete feature.
  [<Parameter>]
  member val AutoComplete: string array = [||] with get, set

  /// Value indicating whether automatic spelling correction and processing of text is enabled.
  [<Parameter; ValidateSet("off", "on")>]
  member val AutoCorrect: string | null = null with get, set

  /// The visible width of the text control, in average character widths.
  [<Parameter; ValidateRange(ValidateRangeKind.Positive)>]
  member val Cols = 0 with get, set

  /// The field name to use for sending the element's directionality in form submission.
  [<Parameter>]
  member val DirName = "" with get, set

  /// Value indicating whether to prevent the user from interacting with the element.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form = "" with get, set

  /// The maximum string length that the user can enter.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val MaxLength = -1 with get, set

  /// The minimum string length required that the user should enter.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val MinLength = -1 with get, set

  /// The name of the control.
  [<Parameter>]
  member val Name = "" with get, set

  /// A hint to the user of what can be entered in the control.
  [<Parameter>]
  member val Placeholder = "" with get, set

  /// Value indicating whether the user cannot modify the value of the control.
  [<Parameter>]
  member val ReadOnly = SwitchParameter false with get, set

  /// Value indicating whether the user must fill in a value before submitting a form.
  [<Parameter>]
  member val Required = SwitchParameter false with get, set

  /// The number of visible text lines for the control.
  [<Parameter; ValidateRange(ValidateRangeKind.Positive)>]
  member val Rows = 0 with get, set

  /// Value indicating whether the control should wrap the value for form submission.
  [<Parameter; ValidateSet("hard", "soft")>]
  member val Wrap: string | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.AutoComplete.Length > 0 then attributes["autocomplete"] <- (String.concat " " this.AutoComplete).Trim()
    match this.AutoCorrect with null -> () | value -> attributes["autocorrect"] <- value
    if this.Cols > 0 then attributes["cols"] <- this.Cols
    if not (String.IsNullOrWhiteSpace this.DirName) then attributes["dirname"] <- this.DirName
    if this.Disabled.IsPresent then attributes["disabled"] <- true
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    if this.MaxLength >= 0 then attributes["maxlength"] <- this.MaxLength
    if this.MinLength >= 0 then attributes["minlength"] <- this.MinLength
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    if not (String.IsNullOrWhiteSpace this.Placeholder) then attributes["placeholder"] <- this.Placeholder
    if this.ReadOnly.IsPresent then attributes["readonly"] <- true
    if this.Required.IsPresent then attributes["required"] <- true
    if this.Rows > 0 then attributes["rows"] <- this.Rows
    match this.Wrap with null -> () | value -> attributes["wrap"] <- value
