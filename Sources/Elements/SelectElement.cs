namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>select</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlSelectElement"), Alias("selectTag"), OutputType(typeof(string))]
public class NewSelectElementCommand(): WriteElementCommand("select", isVoid: false) {

	/// <summary>
	/// A hint for a user agent's autocomplete feature.
	/// </summary>
	[Parameter]
	public string[] AutoComplete { get; set; } = [];

	/// <summary>
	/// Value indicating whether to prevent the user from interacting with the element.
	/// </summary>
	[Parameter]
	public SwitchParameter Disabled { get; set; }

	/// <summary>
	/// The identifier of a <c>form</c> element to associate with the element.
	/// </summary>
	[Parameter]
	public string? Form { get; set; }

	/// <summary>
	/// Value indicating whether multiple options can be selected in the list.
	/// </summary>
	[Parameter]
	public SwitchParameter Multiple { get; set; }

	/// <summary>
	/// The name of the control.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Value indicating whether an option with a non-empty string value must be selected.
	/// </summary>
	[Parameter]
	public SwitchParameter Required { get; set; }

	/// <summary>
	/// The number of rows in the list that should be visible at one time.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Size { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (AutoComplete.Length > 0) attributes["autocomplete"] = string.Join(' ', AutoComplete).Trim();
		if (Disabled) attributes["disabled"] = true;
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (Multiple) attributes["multiple"] = true;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (Required) attributes["required"] = true;
		if (Size >= 0) attributes["size"] = Size;
	}
}
