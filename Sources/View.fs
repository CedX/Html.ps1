namespace Belin.Html

open System.Collections
open System.Management.Automation

/// Encodes a string using the specified character encoding.
[<Cmdlet(VerbsCommunications.Write, "HtmlView"); OutputType(typeof<string>)>]
type WriteViewCommand() =
  inherit Cmdlet()

  /// The path to the view file.
  [<Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)>]
  member val Path = "" with get, set

  /// The view data.
  [<Parameter; ValidateNotNull>]
  member val Data: IDictionary = Hashtable() with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    let output = ScriptBlock.Create("& $args[0] $args[1]").Invoke(this.Path, this.Data)
    output |> Seq.map string |> String.concat "" |> this.WriteObject
