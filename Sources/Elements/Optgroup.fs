namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `optgroup` element.
[<Cmdlet(VerbsCommon.New, "HtmlOptgroupElement"); Alias("optgroup"); OutputType(typeof<string>)>]
type NewOptgroupElement() =
  inherit NewElement("optgroup", isVoid = false)

  /// Value indicating whether none of the items in the option group is selectable.
  [<Parameter>]
  member val Disabled = SwitchParameter false with get, set

  /// The name of the group of options.
  [<Parameter(Mandatory = true)>]
  member val Label = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["label"] <- this.Label
    if this.Disabled.IsPresent then attributes["disabled"] <- true
