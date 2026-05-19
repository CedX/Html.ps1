namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>a</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlAElement"), Alias("a"), OutputType(typeof(string))]
public class NewAElementCommand(): WriteElementCommand("a", isVoid: false) {

	/// <summary>
	/// The suggested filename when the browser treats the linked URL as a download.
	/// </summary>
	[Parameter]
	public string? Download { get; set; }

	/// <summary>
	/// The URL that the hyperlink points to.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Href { get; set; }

	/// <summary>
	/// A list of URLs. When the link is followed, the browser will send <c>POST</c> requests with the body <c>PING</c> to the URLs.
	/// </summary>
	[Parameter]
	public Uri[] Ping { get; set; } = [];

	/// <summary>
	/// The relationship of the linked URL.
	/// </summary>
	[Parameter]
	public string[] Rel { get; set; } = [];

	/// <summary>
	/// The browsing context to show the results of navigation.
	/// </summary>
	[Parameter]
	public string? Target { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["href"] = Href;
		if (!string.IsNullOrWhiteSpace(Download)) attributes["download"] = Download;
		if (Ping.Length > 0) attributes["ping"] = string.Join(' ', Ping).Trim();
		if (Rel.Length > 0) attributes["rel"] = string.Join(' ', Rel).Trim();
		if (!string.IsNullOrWhiteSpace(Target)) attributes["target"] = Target;
	}
}
