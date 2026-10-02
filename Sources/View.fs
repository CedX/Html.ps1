namespace Belin.Html

open System.Collections
open System.Management.Automation

/// Encodes a string using the specified character encoding.
[<Cmdlet(VerbsOther.Use, "HtmlLayout"); Alias("layout"); OutputType(typeof<string>)>]
type UseLayoutCommand() =
  inherit Cmdlet()

  /// The path to the layout file.
  [<Parameter(Mandatory = true, Position = 1)>]
  member val Path = "" with get, set

  /// The child content of the layout.
  [<Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)>]
  member val Content: objnull = null with get, set

  /// The layout data.
  [<Parameter; ValidateNotNull>]
  member val Data: IDictionary = Hashtable() with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    let content = Element.renderContent this.Content
      // match this.Content with
      // | null -> Seq.empty
      // // TODO | :? PSObject as psObject -> seq { psObject.BaseObject }
      // | :? ScriptBlock as scriptBlock -> scriptBlock.Invoke() |> Seq.map (fun psObject -> psObject.BaseObject)
      // | value -> seq { value }

    // System.Console.WriteLine (content.GetType())
    // System.Console.WriteLine (Seq.head content)
    let childContent = content |> Seq.map string |> String.concat ""
    // System.Console.WriteLine childContent

    let output = ScriptBlock.Create("& $args[0] $args[1] $args[2]").Invoke(this.Path, childContent, this.Data)
    output |> Seq.map string |> String.concat "" |> this.WriteObject

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
