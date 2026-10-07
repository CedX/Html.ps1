namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `slot` element.
[<Cmdlet(VerbsCommon.New, "HtmlSlotElement"); Alias("slot"); OutputType(typeof<string>)>]
type NewSlotElement() =
  inherit NewElementCommand("slot", isVoid = false)

  /// The slot's name.
  [<Parameter>]
  member val Name = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
