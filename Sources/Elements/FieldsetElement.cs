namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>fieldset</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlFieldsetElement"), Alias("fieldset"), OutputType(typeof(string))]
public class NewFieldsetElementCommand(): WriteElementCommand("fieldset", isVoid: false) {

	/// <summary>
	/// Value indicating whether all form controls that are descendants of the element, are disabled.
	/// </summary>
	[Parameter]
	public SwitchParameter Disabled { get; set; }

	/// <summary>
	/// The identifier of a <c>form</c> element to associate with the element.
	/// </summary>
	[Parameter]
	public string? Form { get; set; }

	/// <summary>
	/// The name associated with the group.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Disabled) attributes["disabled"] = true;
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
	}
}
