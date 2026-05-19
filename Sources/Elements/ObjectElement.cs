namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>object</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlObjectElement"), Alias("object"), OutputType(typeof(string))]
public class NewObjectElementCommand(): WriteElementCommand("object", isVoid: false) {

	/// <summary>
	/// The URL of the resource being embedded.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Data { get; set; }

	/// <summary>
	/// The identifier of a <c>form</c> element to associate with the element.
	/// </summary>
	[Parameter]
	public string? Form { get; set; }

	/// <summary>
	/// The height of the display resource, in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// The name of valid browsing context (HTML 5), or the name of the control (HTML 4).
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// The media type to use, optionally including a <c>codecs</c> parameter.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required string Type { get; set; }

	/// <summary>
	/// The width of the display resource, in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Width { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["data"] = Data;
		attributes["type"] = Type;
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (Height >= 0) attributes["height"] = Height;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (Width >= 0) attributes["width"] = Width;
	}
}
