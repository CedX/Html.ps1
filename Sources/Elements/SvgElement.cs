namespace Belin.Html.Elements;

using System.Globalization;

/// <summary>
/// Creates a new <c>svg</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlSvgElement"), Alias("svg"), OutputType(typeof(string))]
public class NewSvgElementCommand(): WriteElementCommand("svg", isVoid: false) {

	/// <summary>
	/// The intrinsic height of the image, in CSS pixels.
	/// </summary>
	[Parameter]
	public string? Height { get; set; }

	/// <summary>
	/// Value indicating how the SVG fragment must be deformed if it is displayed with a different aspect ratio.
	/// </summary>
	[Parameter]
	public string? PreserveAspectRatio { get; set; }

	/// <summary>
	/// The SVG viewport coordinates for the current SVG fragment.
	/// </summary>
	[Parameter, ValidateCount(4, 4)]
	public double[]? ViewBox { get; set; }

	/// <summary>
	/// The intrinsic width of the image, in CSS pixels.
	/// </summary>
	[Parameter]
	public string? Width { get; set; }

	/// <summary>
	/// The displayed X coordinate of the SVG container.
	/// </summary>
	[Parameter]
	public string? X { get; set; }

	/// <summary>
	/// The displayed Y coordinate of the SVG container.
	/// </summary>
	[Parameter]
	public string? Y { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Height)) attributes["height"] = Height;
		if (!string.IsNullOrWhiteSpace(PreserveAspectRatio)) attributes["preserveAspectRatio"] = PreserveAspectRatio;
		if (ViewBox is not null) attributes["viewBox"] = string.Join(" ", ViewBox.Select(number => number.ToString(CultureInfo.InvariantCulture)));
		if (!string.IsNullOrWhiteSpace(Width)) attributes["width"] = Width;
		if (!string.IsNullOrWhiteSpace(X)) attributes["x"] = X;
		if (!string.IsNullOrWhiteSpace(Y)) attributes["y"] = Y;
	}
}
