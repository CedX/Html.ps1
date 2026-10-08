namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `ol` element.
[<Cmdlet(VerbsCommon.New, "HtmlOlElement"); Alias("ol"); OutputType(typeof<string>)>]
type NewOlElement() =
  inherit NewElement("ol", isVoid = false)

  /// Value indicating whether the list's items are in reverse order.
  [<Parameter>]
  member val Reversed = SwitchParameter false with get, set

  /// An integer to start counting from for the list items.
  [<Parameter>]
  member val Start = Nullable<int>() with get, set

  /// Value indicating the current ordinal value of the list item as defined by the `ol` element.
  [<Parameter; ValidateSet("1", "A", "a", "I", "i")>]
  member val Type: string | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Reversed.IsPresent then attributes["reversed"] <- true
    if this.Start.HasValue then attributes["start"] <- this.Start.Value
    match this.Type with null -> () | value -> attributes["type"] <- value
