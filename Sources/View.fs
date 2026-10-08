namespace Belin.Html

open System.Collections
open System.IO
open System.Management.Automation

/// Renders the specified view file as an HTML string.
[<Cmdlet(VerbsCommunications.Write, "HtmlView"); OutputType(typeof<string>)>]
type WriteView() =
  inherit Cmdlet()

  /// The script block used to invoke the view.
  static let scriptBlock = ScriptBlock.Create "& $args[0] $args[1]"

  /// The path to the view file.
  [<Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)>]
  member val Path = "" with get, set

  /// The view data.
  [<Parameter; ValidateNotNull>]
  member val Data: IDictionary = Hashtable() with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    let path = Path.GetFullPath this.Path
    scriptBlock.Invoke(path, this.Data) |> Seq.map string |> String.concat "" |> this.WriteObject
