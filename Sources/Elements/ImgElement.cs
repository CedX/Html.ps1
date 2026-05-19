namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>img</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlImgElement"), Alias("img"), OutputType(typeof(string))]
public class NewImgElementCommand(): WriteElementCommand("img", isVoid: true) {

	/// <summary>
	/// A text to display on browsers that do not display images.
	/// </summary>
	[Parameter]
	public string? Alt { get; set; }

	/// <summary>
	/// The intrinsic height of the image, in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// Value indicating whether the image is part of a server-side map.
	/// </summary>
	[Parameter]
	public SwitchParameter IsMap { get; set; }

	/// <summary>
	/// Value indicating how the browser should load the image.
	/// </summary>
	[Parameter, ValidateSet("eager", "lazy")]
	public string? Loading { get; set; }

	/// <summary>
	/// The intended display sizes of the image.
	/// </summary>
	[Parameter]
	public string[] Sizes { get; set; } = [];

	/// <summary>
	/// The image URL.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Src { get; set; }

	/// <summary>
	/// The possible image sources for the user agent to use.
	/// </summary>
	[Parameter]
	public string[] SrcSet { get; set; } = [];

	/// <summary>
	/// The partial URL (starting with <c>#</c>) of an image map associated with the element.
	/// </summary>
	[Parameter]
	public string? UseMap { get; set; }

	/// <summary>
	/// The intrinsic width of the image, in CSS pixels.
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
		if (Alt is not null) attributes["alt"] = Alt;
		if (Height >= 0) attributes["height"] = Height;
		if (IsMap) attributes["ismap"] = true;
		if (Loading is not null) attributes["loading"] = Loading;
		if (Sizes.Length > 0) attributes["sizes"] = string.Join(", ", Sizes);
		if (SrcSet.Length > 0) attributes["srcset"] = string.Join(", ", SrcSet);
		if (!string.IsNullOrWhiteSpace(UseMap)) attributes["usemap"] = UseMap.StartsWith('#') ? UseMap : $"#{UseMap}";
		if (Width >= 0) attributes["width"] = Width;
	}
}
