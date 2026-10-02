namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `audio` element.
[<Cmdlet(VerbsCommon.New, "HtmlAudioElement"); Alias("audio"); OutputType(typeof<string>)>]
type NewAudioElementCommand() =
  inherit NewElementCommand("audio", isVoid = false)

  /// Value indicating whether playback should start automatically as soon as the audio signal allows.
  [<Parameter>]
  member val AutoPlay = SwitchParameter false with get, set

  /// Value indicating whether to offer controls to allow the user to control audio playback.
  [<Parameter>]
  member val Controls = SwitchParameter false with get, set

  /// Value indicating whether CORS must be used when fetching the resource.
  [<Parameter; ValidateSet("anonymous", "use-credentials")>]
  member val CrossOrigin: string | null = null with get, set

  /// Value indicating whether to disable the capability of remote playback in devices that are attached using wired and wireless technologies.
  [<Parameter>]
  member val DisableRemotePlayback = SwitchParameter false with get, set

  /// Value indicating whether the audio player will automatically seek back to the start upon reaching the end of the audio.
  [<Parameter>]
  member val Loop = SwitchParameter false with get, set

  /// Value indicating whether the audio will be initially silenced.
  [<Parameter>]
  member val Muted = SwitchParameter false with get, set

  /// Value providing a hint to the browser about what the author thinks will lead to the best user experience.
  [<Parameter; ValidateSet("auto", "none", "metadata")>]
  member val Preload: string | null = null with get, set

  /// The URL of the audio to embed.
  [<Parameter>]
  member val Src: Uri | null = null with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.AutoPlay.IsPresent then attributes["autoplay"] <- true
    if this.Controls.IsPresent then attributes["controls"] <- true
    match this.CrossOrigin with null -> () | value -> attributes["crossorigin"] <- value
    if this.DisableRemotePlayback.IsPresent then attributes["disableremoteplayback"] <- true
    if this.Loop.IsPresent then attributes["loop"] <- true
    if this.Muted.IsPresent then attributes["muted"] <- true
    match this.Preload with null -> () | value -> attributes["preload"] <- value
    match this.Src with null -> () | value -> attributes["src"] <- value
