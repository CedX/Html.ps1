namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `q` element.
[<Cmdlet(VerbsCommon.New, "HtmlQElement"); Alias("q"); OutputType(typeof<string>)>]
type NewQElement() =
  inherit NewElement("q", isVoid = false)

  /// A URL that designates a source document or message for the information quoted.
  [<Parameter>]
  member val Cite: Uri | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.Cite with null -> () | value -> attributes["cite"] <- value
