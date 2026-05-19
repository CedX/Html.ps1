namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>output</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlOutputElement"), Alias("output"), OutputType(typeof(string))]
public class NewOutputElementCommand(): WriteElementCommand("output", isVoid: false) {

	/// <summary>
	/// A list of other elements' identifiers, indicating that those elements contributed input values to the calculation.
	/// </summary>
	[Parameter]
	public string[] For { get; set; } = [];

	/// <summary>
	/// The identifier of a <c>form</c> element to associate with the element.
	/// </summary>
	[Parameter]
	public string? Form { get; set; }

	/// <summary>
	/// The element's name.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (For.Length > 0) attributes["for"] = string.Join(' ', For).Trim();
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
	}
}
