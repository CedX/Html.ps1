namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>audio</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlAudioElement"), Alias("audio"), OutputType(typeof(string))]
public class NewAudioElementCommand(): WriteElementCommand("audio", isVoid: false) {

	/// <summary>
	/// Value indicating whether playback should start automatically as soon as the audio signal allows.
	/// </summary>
	[Parameter]
	public SwitchParameter AutoPlay { get; set; }

	/// <summary>
	/// Value indicating whether to offer controls to allow the user to control audio playback.
	/// </summary>
	[Parameter]
	public SwitchParameter Controls { get; set; }

	/// <summary>
	/// Value indicating whether CORS must be used when fetching the resource.
	/// </summary>
	[Parameter, ValidateSet("anonymous", "use-credentials")]
	public string? CrossOrigin { get; set; }

	/// <summary>
	/// Value indicating whether to disable the capability of remote playback in devices that are attached using wired and wireless technologies.
	/// </summary>
	[Parameter]
	public SwitchParameter DisableRemotePlayback { get; set; }

	/// <summary>
	/// Value indicating whether the audio player will automatically seek back to the start upon reaching the end of the audio.
	/// </summary>
	[Parameter]
	public SwitchParameter Loop { get; set; }

	/// <summary>
	/// Value indicating whether the audio will be initially silenced.
	/// </summary>
	[Parameter]
	public SwitchParameter Muted { get; set; }

	/// <summary>
	/// Value providing a hint to the browser about what the author thinks will lead to the best user experience.
	/// </summary>
	[Parameter, ValidateSet("auto", "none", "metadata")]
	public string? Preload { get; set; }

	/// <summary>
	/// The URL of the audio to embed.
	/// </summary>
	[Parameter]
	public Uri? Src { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (AutoPlay) attributes["autoplay"] = true;
		if (Controls) attributes["controls"] = true;
		if (CrossOrigin is not null) attributes["crossorigin"] = CrossOrigin;
		if (DisableRemotePlayback) attributes["disableremoteplayback"] = true;
		if (Loop) attributes["loop"] = true;
		if (Muted) attributes["muted"] = true;
		if (Preload is not null) attributes["preload"] = Preload;
		if (Src is not null) attributes["src"] = Src;
	}
}
