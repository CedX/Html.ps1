namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>textarea</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlTextareaElement"), Alias("textarea"), OutputType(typeof(string))]
public class NewTextareaElementCommand(): WriteElementCommand("textarea", isVoid: false) {

	/// <summary>
	/// A hint for a user agent's autocomplete feature.
	/// </summary>
	[Parameter]
	public string[] AutoComplete { get; set; } = [];

	/// <summary>
	/// Value indicating whether automatic spelling correction and processing of text is enabled.
	/// </summary>
	[Parameter, ValidateSet("off", "on")]
	public string? AutoCorrect { get; set; }

	/// <summary>
	/// The visible width of the text control, in average character widths.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.Positive)]
	public int Cols { get; set; }

	/// <summary>
	/// The field name to use for sending the element's directionality in form submission.
	/// </summary>
	[Parameter]
	public string? DirName { get; set; }

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
	/// The maximum string length that the user can enter.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int MaxLength { get; set; } = -1;

	/// <summary>
	/// The minimum string length required that the user should enter.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int MinLength { get; set; } = -1;

	/// <summary>
	/// The name of the control.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// A hint to the user of what can be entered in the control.
	/// </summary>
	[Parameter]
	public string? Placeholder { get; set; }

	/// <summary>
	/// Value indicating whether the user cannot modify the value of the control.
	/// </summary>
	[Parameter]
	public SwitchParameter ReadOnly { get; set; }

	/// <summary>
	/// Value indicating whether the user must fill in a value before submitting a form.
	/// </summary>
	[Parameter]
	public SwitchParameter Required { get; set; }

	/// <summary>
	/// The number of visible text lines for the control.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.Positive)]
	public int Rows { get; set; }

	/// <summary>
	/// Value indicating whether the control should wrap the value for form submission.
	/// </summary>
	[Parameter, ValidateSet("hard", "soft")]
	public string? Wrap { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (AutoComplete.Length > 0) attributes["autocomplete"] = string.Join(' ', AutoComplete).Trim();
		if (AutoCorrect is not null) attributes["autocorrect"] = AutoCorrect;
		if (Cols > 0) attributes["cols"] = Cols;
		if (!string.IsNullOrWhiteSpace(DirName)) attributes["dirname"] = DirName;
		if (Disabled) attributes["disabled"] = true;
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (MaxLength >= 0) attributes["maxlength"] = MaxLength;
		if (MinLength >= 0) attributes["minlength"] = MinLength;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (!string.IsNullOrWhiteSpace(Placeholder)) attributes["placeholder"] = Placeholder;
		if (ReadOnly) attributes["readonly"] = true;
		if (Required) attributes["required"] = true;
		if (Rows > 0) attributes["rows"] = Rows;
		if (Wrap is not null) attributes["wrap"] = Wrap;
	}
}
