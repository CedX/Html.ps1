namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>source</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlSourceElement", DefaultParameterSetName = nameof(Src)), Alias("source"), OutputType(typeof(string))]
public class NewSourceElementCommand(): WriteElementCommand("source", isVoid: true) {

	/// <summary>
	/// The intrinsic height of the image, in CSS pixels.
	/// </summary>
	[Parameter(ParameterSetName = nameof(SrcSet)), ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// The media query for the resource's intended media.
	/// </summary>
	[Parameter(ParameterSetName = nameof(SrcSet))]
	public string? Media { get; set; }

	/// <summary>
	/// A list of source sizes that describe the final rendered width of the image.
	/// </summary>
	[Parameter(ParameterSetName = nameof(SrcSet))]
	public string[] Sizes { get; set; } = [];

	/// <summary>
	/// The URL of the media resource
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(Src))]
	public required Uri Src { get; set; }

	/// <summary>
	/// A list of one or more image URLs and their descriptors.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(SrcSet))]
	public string[] SrcSet { get; set; } = [];

	/// <summary>
	/// The media type to use, optionally including a <c>codecs</c> parameter.
	/// </summary>
	[Parameter]
	public string? Type { get; set; }

	/// <summary>
	/// The intrinsic width of the image, in CSS pixels.
	/// </summary>
	[Parameter(ParameterSetName = nameof(SrcSet)), ValidateRange(ValidateRangeKind.NonNegative)]
	public int Width { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Type)) attributes["type"] = Type;

		switch (ParameterSetName) {
			case nameof(Src):
				attributes["src"] = Src;
				break;

			case nameof(SrcSet):
				attributes["srcset"] = string.Join(", ", SrcSet);
				if (Height >= 0) attributes["height"] = Height;
				if (!string.IsNullOrWhiteSpace(Media)) attributes["media"] = Media;
				if (Sizes.Length > 0) attributes["sizes"] = string.Join(", ", Sizes);
				if (Width >= 0) attributes["width"] = Width;
				break;
		}
	}
}
