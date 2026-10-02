namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `data` element.
[<Cmdlet(VerbsCommon.New, "HtmlDataElement"); Alias("dataTag"); OutputType(typeof<string>)>]
type NewDataElementCommand () =
  inherit NewElementCommand ("data", isVoid = false)

  /// The machine-readable translation of the content of the element.
  [<Parameter(Mandatory = true)>]
  member val Value = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["value"] <- this.Value
