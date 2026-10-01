namespace Belin.Html.Elements

open Belin.Html
open System.Management.Automation

/// Creates a new `{Tag}` element.
[<Cmdlet(VerbsCommon.New, "Html{CapitalizedTag}Element"); Alias("{Alias}")>]
[<OutputType(typeof<string>)>]
type New{CapitalizedTag}ElementCommand () =
  inherit NewElementCommand ("{Tag}", isVoid = {IsVoid})
