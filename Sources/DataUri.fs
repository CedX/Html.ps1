namespace Belin.Html

open System
open System.IO
open System.Management.Automation
open System.Net.Mime

/// Creates a new data URI from the specified file or byte stream.
[<Cmdlet(VerbsCommon.New, "HtmlDataUri", DefaultParameterSetName = "Path"); OutputType(typeof<Uri>)>]
type NewDataUri() =
  inherit PSCmdlet()

  /// The path to a file to convert.
  [<Parameter(Mandatory = true, ParameterSetName = "Path", Position = 1, ValueFromPipeline = true)>]
  member val Path = "" with get, set

  /// The byte stream to convert.
  [<Parameter(Mandatory = true, ParameterSetName = "ByteStream", Position = 1)>]
  member val ByteStream: byte array = [||] with get, set

  /// The media type to associate with the data URI.
  [<Parameter(Position = 2); ValidateNotNullOrWhiteSpace>]
  member val MediaType = MediaTypeNames.Application.Octet with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    let bytes =
      match this.ParameterSetName with
      | "ByteStream" -> this.ByteStream
      | _ -> this.Path |> this.GetUnresolvedProviderPathFromPSPath |> File.ReadAllBytes

    this.WriteObject (Uri $"data:{this.MediaType};base64,{Convert.ToBase64String bytes}")
