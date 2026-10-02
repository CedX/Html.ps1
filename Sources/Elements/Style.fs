namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `style` element.
[<Cmdlet(VerbsCommon.New, "HtmlStyleElement"); Alias("style"); OutputType(typeof<string>)>]
type NewStyleElementCommand () =
  inherit NewElementCommand ("style", isVoid = false)

  /// Defines which media the style should be applied to.
  [<Parameter>]
  member val Media = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if not (String.IsNullOrWhiteSpace this.Media) then attributes["media"] <- this.Media
