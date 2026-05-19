namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>link</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlLinkElement"), Alias("link"), OutputType(typeof(string))]
public class NewLinkElementCommand(): WriteElementCommand("link", isVoid: true) {

	/// <summary>
	/// Specifies the type of content being loaded by the <c>link</c>.
	/// </summary>
	[Parameter]
	public string? As { get; set; }

	/// <summary>
	/// Value indicating whether CORS must be used when fetching the resource.
	/// </summary>
	[Parameter, ValidateSet("anonymous", "use-credentials")]
	public string? CrossOrigin { get; set; }

	/// <summary>
	/// The URL of the linked resource.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Href { get; set; }

	/// <summary>
	/// A base64-encoded cryptographic hash of the resource (file) to fetch.
	/// </summary>
	[Parameter]
	public string? Integrity { get; set; }

	/// <summary>
	/// The media that the linked resource applies to.
	/// </summary>
	[Parameter]
	public string? Media { get; set; }

	/// <summary>
	/// The relationship of the linked resource to the current document.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required string[] Rel { get; set; }

	/// <summary>
	/// The sizes of the icons for visual media contained in the resource.
	/// </summary>
	[Parameter]
	public string[] Sizes { get; set; } = [];

	/// <summary>
	/// The media type of the content linked to.
	/// </summary>
	[Parameter]
	public string? Type { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["rel"] = string.Join(' ', Rel).Trim();
		attributes["href"] = Href;
		if (!string.IsNullOrWhiteSpace(As)) attributes["as"] = As;
		if (CrossOrigin is not null) attributes["crossorigin"] = CrossOrigin;
		if (!string.IsNullOrWhiteSpace(Integrity)) attributes["integrity"] = Integrity;
		if (!string.IsNullOrWhiteSpace(Media)) attributes["media"] = Media;
		if (Sizes.Length > 0) attributes["sizes"] = string.Join(' ', Sizes).Trim();
		if (!string.IsNullOrWhiteSpace(Type)) attributes["type"] = Type;
	}
}
