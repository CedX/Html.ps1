namespace Belin.Html

open System.Management.Automation
open System.Text.Encodings.Web

/// Encodes a string using the specified character encoding.
[<Cmdlet(VerbsSecurity.Protect, "HtmlString"); Alias("esc")>]
[<OutputType(typeof<string>)>]
type ProtectHtmlStringCommand () =
  inherit Cmdlet ()

  /// The encoder used to process the string.
  let mutable encoder: TextEncoder = HtmlEncoder.Default

  /// The string to encode.
  [<Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)>]
  [<AllowEmptyString; AllowNull>]
  member val Value: string | null = "" with get, set

  /// The character encoding to use.
  [<Parameter; ValidateSet("Html", "Url")>]
  member val Encoding = "Html" with get, set

  /// Performs initialization of the command execution.
  override this.BeginProcessing () =
    encoder <- if this.Encoding = "Url" then UrlEncoder.Default :> TextEncoder else HtmlEncoder.Default

  /// Performs execution of this command.
  override this.ProcessRecord () =
    this.WriteObject (match this.Value with null -> "" | value -> encoder.Encode value)
