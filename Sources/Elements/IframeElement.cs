namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>iframe</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlIframeElement"), Alias("iframe"), OutputType(typeof(string))]
public class NewIframeElementCommand(): WriteElementCommand("iframe", isVoid: false) {

	/// <summary>
	/// Specifies a permissions policy thaht defines what features are available to the frame based on the origin of the request.
	/// </summary>
	[Parameter]
	public string? Allow { get; set; }

	/// <summary>
	/// The height of the frame in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// Value indicating how the browser should load the frame.
	/// </summary>
	[Parameter, ValidateSet("eager", "lazy")]
	public string? Loading { get; set; }

	/// <summary>
	/// A targetable name for the embedded browsing context.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Value indicating which referrer to send when fetching the frame's resource.
	/// </summary>
	[Parameter, ValidateSet(
		"no-referrer-when-downgrade", "no-referrer", "origin-when-cross-origin", "origin",
		"same-origin", "strict-origin-when-cross-origin", "strict-origin", "unsafe-url"
	)]
	public string? ReferrerPolicy { get; set; }

	/// <summary>
	/// The restrictions applied to the content embedded in the frame.
	/// </summary>
	[Parameter]
	public string[] Sandbox { get; set; } = [];

	/// <summary>
	/// The URL of the page to embed.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Src { get; set; }

	/// <summary>
	/// The width of the frame in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Width { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["src"] = Src;
		if (!string.IsNullOrWhiteSpace(Allow)) attributes["allow"] = Allow;
		if (Height >= 0) attributes["height"] = Height;
		if (Loading is not null) attributes["loading"] = Loading;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (ReferrerPolicy is not null) attributes["referrerpolicy"] = ReferrerPolicy;
		if (Sandbox.Length > 0) attributes["sandbox"] = string.Join(' ', Sandbox).Trim();
		if (Width >= 0) attributes["width"] = Width;
	}
}
