namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `dialog` element.
[<Cmdlet(VerbsCommon.New, "HtmlDialogElement"); Alias("dialog"); OutputType(typeof<string>)>]
type NewDialogElement() =
  inherit NewElementCommand("dialog", isVoid = false)

  /// Specifies the types of user actions that can be used to close the element.
  [<Parameter; ValidateSet("any", "closerequest", "none")>]
  member val ClosedBy: string | null = null with get, set

  /// Value indicating whether the dialog box is active and is available for interaction.
  [<Parameter>]
  member val Open = SwitchParameter false with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.ClosedBy with null -> () | value -> attributes["closedby"] <- value
    if this.Open.IsPresent then attributes["open"] <- true
