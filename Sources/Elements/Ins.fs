namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation
open System.Xml

/// Creates a new `ins` element.
[<Cmdlet(VerbsCommon.New, "HtmlInsElement"); Alias("ins"); OutputType(typeof<string>)>]
type NewInsElementCommand () =
  inherit NewElementCommand ("ins", isVoid = false)

  /// A URI for a resource that explains the change.
  [<Parameter>]
  member val Cite: Uri | null = null with get, set

  /// The date and time of the change.
  [<Parameter>]
  member val DateTime: objnull = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.Cite with null -> () | value -> attributes["cite"] <- value

    let result: Result<string | null, NotSupportedException> =
      match this.DateTime with
      | null -> Ok null
      | dateTime ->
        match (match dateTime with :? PSObject as psObject -> psObject.BaseObject | value -> value) with
        | :? DateOnly as value -> Ok (value.ToString "o")
        | :? DateTime as value -> Ok (value.ToString "o")
        | :? DateTimeOffset as value -> Ok (value.ToString "o")
        | _ -> Error (NotSupportedException "The specified date/time value is not supported.")

    match result with
    | Error ex -> this.WriteError (ErrorRecord(ex, "DateTime.ToString", ErrorCategory.InvalidArgument, this.DateTime))
    | Ok value -> attributes["datetime"] <- value
