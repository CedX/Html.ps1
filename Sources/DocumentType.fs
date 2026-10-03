namespace Belin.Html

open System
open System.Management.Automation

/// Creates a new document type declaration.
[<Cmdlet(VerbsCommon.New, "HtmlDocumentType"); Alias("doctype"); OutputType(typeof<string>)>]
type NewDocumentTypeCommand() =
  inherit Cmdlet()

  /// The value of the document type.
  [<Parameter(Position = 1, ValueFromPipeline = true)>]
  member val Value = "html" with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    let doctype = if String.IsNullOrWhiteSpace this.Value then "html" else this.Value
    this.WriteObject $"<!doctype {doctype}>"
