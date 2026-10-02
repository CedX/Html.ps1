namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `meta` element.
[<Cmdlet(VerbsCommon.New, "HtmlMetaElement", DefaultParameterSetName = "Name"); Alias("meta"); OutputType(typeof<string>)>]
type NewMetaElementCommand () =
  inherit NewElementCommand ("meta", isVoid = true)

  /// A charset declaration, giving the character encoding in which the document is encoded.
  [<Parameter(Mandatory = true, ParameterSetName = "Charset")>]
  member val Charset = "" with get, set

  /// Contains the value for the `http-equiv` or `name attribute`, depending on which is used.
  [<Parameter(Mandatory = true, ParameterSetName = "HttpEquiv")>]
  [<Parameter(Mandatory = true, ParameterSetName = "Name")>]
  override _.Content with get() = base.Content and set(value: objnull) = base.Content <- value

  /// A pragma directive to simulate directives that could otherwise be given by an HTTP header.
  [<Parameter(Mandatory = true, ParameterSetName = "HttpEquiv")>]
  member val HttpEquiv = "" with get, set

  /// Document-level metadata that applies to the whole page.
  [<Parameter(Mandatory = true, ParameterSetName = "Name")>]
  member val Name = "" with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.ParameterSetName with
    | "Charset" -> attributes["charset"] <- this.Charset
    | "HttpEquiv" -> attributes["http-equiv"] <- this.HttpEquiv; attributes["content"] <- this.Content
    | "Name" -> attributes["name"] <- this.Name; attributes["content"] <- this.Content
    | _ -> ()
