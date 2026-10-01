namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `progress` element.
[<Cmdlet(VerbsCommon.New, "HtmlProgressElement"); Alias("progress"); OutputType(typeof<string>)>]
type NewProgressElementCommand () =
  inherit NewElementCommand ("progress", isVoid = false)

  /// Describes how much work the task requires.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Max = Nullable<double>() with get, set

  /// Specifies how much of the task that has been completed.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Value = Nullable<double>() with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.Max.HasValue then attributes["max"] <- this.Max.Value
    if this.Value.HasValue then attributes["value"] <- this.Value.Value
