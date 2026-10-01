namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Globalization
open System.Management.Automation

/// Creates a new `track` element.
[<Cmdlet(VerbsCommon.New, "HtmlTrackElement"); Alias("track"); OutputType(typeof<string>)>]
type NewTrackElementCommand () =
  inherit NewElementCommand ("track", isVoid = true)

  /// Value indicating whether the track should be enabled unless the user's preferences indicate that another track is more appropriate.
  [<Parameter>]
  member val Default = SwitchParameter false with get, set

  /// Value indicating how the text track is meant to be used.
  [<Parameter; ValidateSet("captions", "chapters", "descriptions", "metadata", "subtitles")>]
  member val Kind: string | null = null with get, set

  /// A user-readable title of the text track which is used by the browser when listing available text tracks.
  [<Parameter>]
  member val Label: string | null = null with get, set

  /// The address of the track (`.vtt` file).
  [<Parameter(Mandatory = true)>]
  member val Src: Uri | null = null with get, set

  /// The language of the track text data.
  [<Parameter>]
  member val SrcLang: CultureInfo | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    attributes["src"] <- this.Src
    if this.Default.IsPresent then attributes["default"] <- true
    match this.Kind with null -> () | value -> attributes["kind"] <- value
    if not (String.IsNullOrWhiteSpace "Label") then attributes["label"] <- this.Label
    match this.SrcLang with null -> () | value -> attributes["srclang"] <- value.Name
