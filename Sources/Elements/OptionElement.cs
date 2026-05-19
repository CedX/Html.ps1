namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>option</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlOptionElement"), Alias("option"), OutputType(typeof(string))]
public class NewOptionElementCommand(): WriteElementCommand("option", isVoid: false) {

	/// <summary>
	/// Value indicating whether the option is not checkable.
	/// </summary>
	[Parameter]
	public SwitchParameter Disabled { get; set; }

	/// <summary>
	/// The label indicating the meaning of the option.
	/// </summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>
	/// Value indicating whether the option is initially selected.
	/// </summary>
	[Parameter]
	public SwitchParameter Selected { get; set; }

	/// <summary>
	/// The value to be submitted with the form.
	/// </summary>
	[Parameter]
	public string? Value { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Disabled) attributes["disabled"] = true;
		if (!string.IsNullOrWhiteSpace(Label)) attributes["label"] = Label;
		if (Selected) attributes["selected"] = true;
		if (Value is not null) attributes["value"] = Value;
	}
}
