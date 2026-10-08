namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `fieldset` element.
[<Cmdlet(VerbsCommon.New, "HtmlFieldsetElement"); Alias("fieldset"); OutputType(typeof<string>)>]
type NewFieldsetElement() =
  inherit NewElement("fieldset", isVoid = false)

  /// Value indicating whether all form controls that are descendants of the element, are disabled.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form = "" with get, set

  /// The name associated with the group.
  [<Parameter>]
  member val Name = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Disabled.IsPresent then attributes["disabled"] <- true
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
