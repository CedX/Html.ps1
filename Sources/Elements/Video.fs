namespace Belin.Html.Elements

open Belin.Html
open System
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `video` element.
[<Cmdlet(VerbsCommon.New, "HtmlVideoElement"); Alias("video"); OutputType(typeof<string>)>]
type NewVideoElement() =
  inherit NewElementCommand("video", isVoid = false)

  /// Value indicating whether playback should start automatically as soon as the video signal allows.
  [<Parameter>]
  member val AutoPlay = SwitchParameter false with get, set

  /// Value indicating whether to offer controls to allow the user to control video playback.
  [<Parameter>]
  member val Controls = SwitchParameter false with get, set

  /// Value indicating whether CORS must be used when fetching the resource.
  [<Parameter; ValidateSet("anonymous", "use-credentials")>]
  member val CrossOrigin: string | null = null with get, set

  /// Value indicating whether to prevent the browser from suggesting a Picture-in-Picture context menu or to request Picture-in-Picture automatically.
  [<Parameter>]
  member val DisablePictureInPicture = SwitchParameter false with get, set

  /// Value indicating whether to disable the capability of remote playback in devices that are attached using wired and wireless technologies.
  [<Parameter>]
  member val DisableRemotePlayback = SwitchParameter false with get, set

  /// The height of the video's display area, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Height = -1 with get, set

  /// Value indicating whether the video player will automatically seek back to the start upon reaching the end of the video.
  [<Parameter>]
  member val Loop = SwitchParameter false with get, set

  /// Value indicating whether the audio will be initially silenced.
  [<Parameter>]
  member val Muted = SwitchParameter false with get, set

  /// Value indicating whether the video is to be played "inline", that is, within the element's playback area.
  [<Parameter>]
  member val PlaysInline = SwitchParameter false with get, set

  /// The URL for an image to be shown while the video is downloading.
  [<Parameter>]
  member val Poster: Uri | null = null with get, set

  /// Value providing a hint to the browser about what the author thinks will lead to the best user experience.
  [<Parameter; ValidateSet("auto", "none", "metadata")>]
  member val Preload: string | null = null with get, set

  /// The URL of the video to embed.
  [<Parameter>]
  member val Src: Uri | null = null with get, set

  /// The width of the video's display area, in CSS pixels.
  [<Parameter; ValidateRange(ValidateRangeKind.NonNegative)>]
  member val Width = -1 with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    if this.AutoPlay.IsPresent then attributes["autoplay"] <- true
    if this.Controls.IsPresent then attributes["controls"] <- true
    match this.CrossOrigin with null -> () | value -> attributes["crossorigin"] <- value
    if this.DisablePictureInPicture.IsPresent then attributes["disablepictureinpicture"] <- true
    if this.DisableRemotePlayback.IsPresent then attributes["disableremoteplayback"] <- true
    if this.Height >= 0 then attributes["height"] <- this.Height
    if this.Loop.IsPresent then attributes["loop"] <- true
    if this.Muted.IsPresent then attributes["muted"] <- true
    if this.PlaysInline.IsPresent then attributes["playsinline"] <- true
    match this.Poster with null -> () | value -> attributes["poster"] <- value
    match this.Preload with null -> () | value -> attributes["preload"] <- value
    match this.Src with null -> () | value -> attributes["src"] <- value
    if this.Width >= 0 then attributes["width"] <- this.Width
