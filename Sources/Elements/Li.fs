namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `li` element.
[<Cmdlet(VerbsCommon.New, "HtmlLiElement"); Alias("li"); OutputType(typeof<string>)>]
type NewLiElementCommand () =
  inherit NewElementCommand ("li", isVoid = false)

  /// The ordinal value of the list item as defined by the `ol` element.
  [<Parameter>]
  member val Value = Nullable<int>() with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Value.HasValue then attributes["value"] <- this.Value.Value
