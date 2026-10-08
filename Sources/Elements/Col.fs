namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `col` element.
[<Cmdlet(VerbsCommon.New, "HtmlColElement"); Alias("col"); OutputType(typeof<string>)>]
type NewColElement() =
  inherit NewElement("col", isVoid = true)

  /// The number of consecutive columns the element spans.
  [<Parameter; ValidateRange(ValidateRangeKind.Positive)>]
  member val Span = 0 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Span > 0 then attributes["span"] <- this.Span
