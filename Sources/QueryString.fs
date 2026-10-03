namespace Belin.Html

open System.Collections
open System.Collections.Specialized
open System.Management.Automation
open System.Web

/// Creates a new query string.
[<Cmdlet(VerbsCommon.New, "HtmlQueryString", DefaultParameterSetName = "Default"); OutputType(typeof<string>, typeof<NameValueCollection>)>]
type NewQueryStringCommand() =
  inherit Cmdlet()

  /// The name/value pairs providing the query parameters.
  [<Parameter(Position = 1, ValueFromPipeline = true); ValidateNotNull>]
  member val InputObject: IDictionary = Hashtable() with get, set

  /// The initial query string.
  [<Parameter>]
  member val Value: string | null = null with get, set

  /// Value indicating whether to include the question mark.
  [<Parameter(ParameterSetName = "AddQuestionMark")>]
  member val AddQuestionMark = SwitchParameter false with get, set

  /// Value indicating whether to return the name/value collection.
  [<Parameter(ParameterSetName = "AsCollection")>]
  member val AsCollection = SwitchParameter false with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    let collection = HttpUtility.ParseQueryString (defaultIfNull "" this.Value)
    for entry in Seq.cast<DictionaryEntry> this.InputObject do
      collection.Add (string entry.Key, match entry.Value with null -> null | value -> string value)

    if this.AsCollection.IsPresent then this.WriteObject (collection, enumerateCollection = false)
    else
      let queryString = string collection
      this.WriteObject (if queryString.Length > 0 && this.AddQuestionMark.IsPresent then $"?{queryString}" else queryString)
