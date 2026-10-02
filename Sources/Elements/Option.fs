namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `option` element.
[<Cmdlet(VerbsCommon.New, "HtmlOptionElement"); Alias("option"); OutputType(typeof<string>)>]
type NewOptionElementCommand () =
  inherit NewElementCommand ("option", isVoid = false)

  /// Value indicating whether the option is not checkable.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The label indicating the meaning of the option.
  [<Parameter>]
  member val Label = "" with get, set

  /// Value indicating whether the option is initially selected.
  [<Parameter>]
  member val Selected = SwitchParameter false with get, set

  /// The value to be submitted with the form.
  [<Parameter>]
  member val Value: string | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Disabled.IsPresent then attributes["disabled"] <- true
    if not (String.IsNullOrWhiteSpace this.Label) then attributes["label"] <- this.Label
    if this.Selected.IsPresent then attributes["selected"] <- true
    match this.Value with null -> () | value -> attributes["value"] <- value
