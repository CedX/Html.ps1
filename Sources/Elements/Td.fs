namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `th` element.
[<Cmdlet(VerbsCommon.New, "HtmlTdElement"); Alias("td"); OutputType(typeof<string>)>]
type NewTdElement() =
  inherit NewElementCommand("td", isVoid = false)

  /// An integer indicating how many columns the header cell spans or extends.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val ColSpan = -1 with get, set

  /// A list of strings corresponding to the `id` attributes of the `th` elements that provide the headers for this header cell.
  [<Parameter>]
  member val Headers: string array = [||] with get, set

  /// An integer indicating how many rows the header cell spans or extends.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val RowSpan = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.ColSpan >= 0 then attributes["colspan"] <- this.ColSpan
    if this.Headers.Length > 0 then attributes["headers"] <- (String.concat " " this.Headers).Trim()
    if this.RowSpan >= 0 then attributes["rowspan"] <- this.RowSpan
