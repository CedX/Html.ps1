namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `label` element.
[<Cmdlet(VerbsCommon.New, "HtmlLabelElement"); Alias("label"); OutputType(typeof<string>)>]
type NewLabelElementCommand() =
  inherit NewElementCommand("label", isVoid = false)

  /// The identifier of the labelable form control in the same document.
  [<Parameter>]
  member val For = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.For) then attributes["for"] <- this.For
