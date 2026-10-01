namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `output` element.
[<Cmdlet(VerbsCommon.New, "HtmlOutputElement"); Alias("output"); OutputType(typeof<string>)>]
type NewOutputElementCommand () =
  inherit NewElementCommand ("output", isVoid = false)

  /// A list of other elements' identifiers, indicating that those elements contributed input values to the calculation.
  [<Parameter>]
  member val For: string array = [||] with get, set

  /// The identifier of a `form` element to associate with the element.
  [<Parameter>]
  member val Form: string | null = null with get, set

  /// The element's name.
  [<Parameter>]
  member val Name: string | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.For.Length > 0 then attributes["for"] <- (String.concat " " this.For).Trim()
    if not (String.IsNullOrWhiteSpace this.Form) then attributes["form"] <- this.Form
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
