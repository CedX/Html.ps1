namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `meter` element.
[<Cmdlet(VerbsCommon.New, "HtmlMeterElement"); Alias("meter"); OutputType(typeof<string>)>]
type NewMeterElementCommand() =
  inherit NewElementCommand("meter", isVoid = false)

  /// The lower numeric bound of the high end of the measured range.
  [<Parameter>]
  member val High = Nullable<double>() with get, set

  /// The upper numeric bound of the low end of the measured range.
  [<Parameter>]
  member val Low = Nullable<double>() with get, set

  /// The upper numeric bound of the measured range.
  [<Parameter>]
  member val Max = Nullable<double>() with get, set

  /// The lower numeric bound of the measured range.
  [<Parameter>]
  member val Min = Nullable<double>() with get, set

  /// The optimal numeric value.
  [<Parameter>]
  member val Optimum = Nullable<double>() with get, set

  /// The current numeric value.
  [<Parameter>]
  member val Value = Nullable<double>() with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.High.HasValue then attributes["high"] <- this.High.Value
    if this.Low.HasValue then attributes["low"] <- this.Low.Value
    if this.Max.HasValue then attributes["max"] <- this.Max.Value
    if this.Min.HasValue then attributes["min"] <- this.Min.Value
    if this.Optimum.HasValue then attributes["optimum"] <- this.Optimum.Value
    if this.Value.HasValue then attributes["value"] <- this.Value.Value
