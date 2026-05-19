namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>video</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlVideoElement"), Alias("video"), OutputType(typeof(string))]
public class NewVideoElementCommand(): WriteElementCommand("video", isVoid: false) {

	/// <summary>
	/// Value indicating whether playback should start automatically as soon as the video signal allows.
	/// </summary>
	[Parameter]
	public SwitchParameter AutoPlay { get; set; }

	/// <summary>
	/// Value indicating whether to offer controls to allow the user to control video playback.
	/// </summary>
	[Parameter]
	public SwitchParameter Controls { get; set; }

	/// <summary>
	/// Value indicating whether CORS must be used when fetching the resource.
	/// </summary>
	[Parameter, ValidateSet("anonymous", "use-credentials")]
	public string? CrossOrigin { get; set; }

	/// <summary>
	/// Value indicating whether to prevent the browser from suggesting a Picture-in-Picture context menu or to request Picture-in-Picture automatically.
	/// </summary>
	[Parameter]
	public SwitchParameter DisablePictureInPicture { get; set; }

	/// <summary>
	/// Value indicating whether to disable the capability of remote playback in devices that are attached using wired and wireless technologies.
	/// </summary>
	[Parameter]
	public SwitchParameter DisableRemotePlayback { get; set; }

	/// <summary>
	/// The height of the video's display area, in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// Value indicating whether the video player will automatically seek back to the start upon reaching the end of the video.
	/// </summary>
	[Parameter]
	public SwitchParameter Loop { get; set; }

	/// <summary>
	/// Value indicating whether the audio will be initially silenced.
	/// </summary>
	[Parameter]
	public SwitchParameter Muted { get; set; }

	/// <summary>
	/// Value indicating whether the video is to be played "inline", that is, within the element's playback area.
	/// </summary>
	[Parameter]
	public SwitchParameter PlaysInline { get; set; }

	/// <summary>
	/// The URL for an image to be shown while the video is downloading.
	/// </summary>
	[Parameter]
	public Uri? Poster { get; set; }

	/// <summary>
	/// Value providing a hint to the browser about what the author thinks will lead to the best user experience.
	/// </summary>
	[Parameter, ValidateSet("auto", "none", "metadata")]
	public string? Preload { get; set; }

	/// <summary>
	/// The URL of the video to embed.
	/// </summary>
	[Parameter]
	public Uri? Src { get; set; }

	/// <summary>
	/// The width of the video's display area, in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Width { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (AutoPlay) attributes["autoplay"] = true;
		if (Controls) attributes["controls"] = true;
		if (CrossOrigin is not null) attributes["crossorigin"] = CrossOrigin;
		if (DisablePictureInPicture) attributes["disablepictureinpicture"] = true;
		if (DisableRemotePlayback) attributes["disableremoteplayback"] = true;
		if (Height >= 0) attributes["height"] = Height;
		if (Loop) attributes["loop"] = true;
		if (Muted) attributes["muted"] = true;
		if (PlaysInline) attributes["playsinline"] = true;
		if (Poster is not null) attributes["poster"] = Poster;
		if (Preload is not null) attributes["preload"] = Preload;
		if (Src is not null) attributes["src"] = Src;
		if (Width >= 0) attributes["width"] = Width;
	}
}
