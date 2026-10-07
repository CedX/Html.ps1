namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `select` element.
[<Cmdlet(VerbsCommon.New, "HtmlSelectElement"); Alias("selectTag"); OutputType(typeof<string>)>]
type NewSelectElement() =
  inherit NewElementCommand("select", isVoid = false)

  /// A hint for a user agent's autocomplete feature.
  [<Parameter>]
  member val AutoComplete: string array = [||] with get, set

  /// Value indicating whether to prevent the user from interacting with the element.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form = "" with get, set

  /// Value indicating whether multiple options can be selected in the list.
  [<Parameter>]
  member val Multiple = SwitchParameter false with get, set

  /// The name of the control.
  [<Parameter>]
  member val Name = "" with get, set

  /// Value indicating whether an option with a non-empty string value must be selected.
  [<Parameter>]
  member val Required = SwitchParameter false with get, set

  /// The number of rows in the list that should be visible at one time.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Size = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.AutoComplete.Length > 0 then attributes["autocomplete"] <- (String.concat " " this.AutoComplete).Trim()
    if this.Disabled.IsPresent then attributes["disabled"] <- true
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    if this.Multiple.IsPresent then attributes["multiple"] <- true
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    if this.Required.IsPresent then attributes["required"] <- true
    if this.Size >= 0 then attributes["size"] <- this.Size
