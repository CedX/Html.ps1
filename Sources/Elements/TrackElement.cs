namespace Belin.Html.Elements;

using System.Globalization;

/// <summary>
/// Creates a new <c>track</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlTrackElement"), Alias("track"), OutputType(typeof(string))]
public class NewTrackElementCommand(): WriteElementCommand("track", isVoid: true) {

	/// <summary>
	/// Value indicating whether the track should be enabled unless the user's preferences indicate that another track is more appropriate.
	/// </summary>
	[Parameter]
	public SwitchParameter Default { get; set; }

	/// <summary>
	/// Value indicating how the text track is meant to be used.
	/// </summary>
	[Parameter, ValidateSet("captions", "chapters", "descriptions", "metadata", "subtitles")]
	public string? Kind { get; set; }

	/// <summary>
	/// A user-readable title of the text track which is used by the browser when listing available text tracks.
	/// </summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>
	/// The address of the track (<c>.vtt</c> file).
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Src { get; set; }

	/// <summary>
	/// The language of the track text data.
	/// </summary>
	[Parameter]
	public CultureInfo? SrcLang { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["src"] = Src;
		if (Default) attributes["default"] = true;
		if (Kind is not null) attributes["kind"] = Kind;
		if (!string.IsNullOrWhiteSpace(Label)) attributes["label"] = Label;
		if (SrcLang is not null) attributes["srclang"] = SrcLang.Name;
	}
}
