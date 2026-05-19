namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>canvas</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlCanvasElement"), Alias("canvas"), OutputType(typeof(string))]
public class NewCanvasElementCommand(): WriteElementCommand("canvas", isVoid: false) {

	/// <summary>
	/// The height of the coordinate space in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// The width of the coordinate space in CSS pixels.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Width { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Height >= 0) attributes["height"] = Height;
		if (Width >= 0) attributes["width"] = Width;
	}
}
