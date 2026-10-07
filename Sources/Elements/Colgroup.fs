namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `colgroup` element.
[<Cmdlet(VerbsCommon.New, "HtmlColgroupElement"); Alias("colgroup"); OutputType(typeof<string>)>]
type NewColgroupElement() =
  inherit NewElementCommand("colgroup", isVoid = false)

  /// The number of consecutive columns the element spans.
  [<Parameter; ValidateRange(ValidateRangeKind.Positive)>]
  member val Span = 0 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Span > 0 then attributes["span"] <- this.Span
