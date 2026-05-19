namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>th</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlTdElement"), Alias("td"), OutputType(typeof(string))]
public class NewTdElementCommand(): WriteElementCommand("td", isVoid: false) {

	/// <summary>
	/// An integer indicating how many columns the header cell spans or extends.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int ColSpan { get; set; } = -1;

	/// <summary>
	/// A list of strings corresponding to the <c>id</c> attributes of the <c>th</c> elements that provide the headers for this header cell.
	/// </summary>
	[Parameter]
	public string[] Headers { get; set; } = [];

	/// <summary>
	/// An integer indicating how many rows the header cell spans or extends.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int RowSpan { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (ColSpan >= 0) attributes["colspan"] = ColSpan;
		if (Headers.Length > 0) attributes["headers"] = string.Join(' ', Headers).Trim();
		if (RowSpan >= 0) attributes["rowspan"] = RowSpan;
	}
}
