namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `map` element.
[<Cmdlet(VerbsCommon.New, "HtmlMapElement"); Alias("map"); OutputType(typeof<string>)>]
type NewMapElementCommand () =
  inherit NewElementCommand ("map", isVoid = false)

  /// The map name so that it can be referenced.
  [<Parameter>]
  member val Name: string | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
