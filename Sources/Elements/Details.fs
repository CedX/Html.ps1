namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `details` element.
[<Cmdlet(VerbsCommon.New, "HtmlDetailsElement"); Alias("details"); OutputType(typeof<string>)>]
type NewDetailsElement() =
  inherit NewElement("details", isVoid = false)

  /// The group name allowing multiple `details` elements to be connected, with only one open at a time.
  [<Parameter>]
  member val Name = "" with get, set

  /// Value indicating whether the details are currently visible.
  [<Parameter>]
  member val Open = SwitchParameter false with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Name) then attributes["name"] <- this.Name
    if this.Open.IsPresent then attributes["open"] <- true
