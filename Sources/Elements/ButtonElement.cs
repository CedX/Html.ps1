namespace Belin.Html.Elements;

using System.Net.Mime;

/// <summary>
/// Creates a new <c>button</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlButtonElement"), Alias("button"), OutputType(typeof(string))]
public class NewButtonElementCommand(): WriteElementCommand("button", isVoid: false) {

	/// <summary>
	/// The action to be performed on an element being controlled via the <see cref="CommandFor"/> attribute.
	/// </summary>
	[Parameter]
	public string? Command { get; set; }

	/// <summary>
	/// The identifier of an element to control.
	/// </summary>
	[Parameter]
	public string? CommandFor { get; set; }

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
	/// The URL that processes the information submitted by the button.
	/// </summary>
	[Parameter]
	public Uri? FormAction { get; set; }

	/// <summary>
	/// Value indicating how to encode the form data that is submitted.
	/// </summary>
	[Parameter, ValidateSet(MediaTypeNames.Application.FormUrlEncoded, MediaTypeNames.Multipart.FormData, MediaTypeNames.Text.Plain)]
	public string? FormEnctype { get; set; }

	/// <summary>
	/// The HTTP method used to submit the form.
	/// </summary>
	[Parameter, ValidateSet("dialog", "get", "post")]
	public string? FormMethod { get; set; }

	/// <summary>
	/// Value indicating whether the form is not to be validated when it is submitted.
	/// </summary>
	[Parameter]
	public SwitchParameter FormNoValidate { get; set; }

	/// <summary>
	/// The browsing context to show the response after submitting the form.
	/// </summary>
	[Parameter]
	public string? FormTarget { get; set; }

	/// <summary>
	/// The name of the control.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// The identifier of a popover element to control.
	/// </summary>
	[Parameter]
	public string? PopoverTarget { get; set; }

	/// <summary>
	/// The action to be performed on a popover element being controlled via the <see cref="PopoverTarget"/> attribute.
	/// </summary>
	[Parameter, ValidateSet("hide", "show", "toggle")]
	public string? PopoverTargetAction { get; set; }

	/// <summary>
	/// The default behavior of the button.
	/// </summary>
	[Parameter, ValidateSet("button", "reset", "submit")]
	public string? Type { get; set; }

	/// <summary>
	/// The value of the control.
	/// </summary>
	[Parameter]
	public object? Value { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Command)) attributes["command"] = Command;
		if (!string.IsNullOrWhiteSpace(CommandFor)) attributes["commandfor"] = CommandFor;
		if (Disabled) attributes["disabled"] = true;
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (FormAction is not null) attributes["formaction"] = FormAction;
		if (FormEnctype is not null) attributes["formenctype"] = FormEnctype;
		if (FormMethod is not null) attributes["formmethod"] = FormMethod;
		if (FormNoValidate) attributes["formnovalidate"] = true;
		if (!string.IsNullOrWhiteSpace(FormTarget)) attributes["formtarget"] = FormTarget;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (!string.IsNullOrWhiteSpace(PopoverTarget)) attributes["popovertarget"] = PopoverTarget;
		if (PopoverTargetAction is not null) attributes["popovertargetaction"] = PopoverTargetAction;
		if (Type is not null) attributes["type"] = Type;
		if (Value is not null) attributes["value"] = Value;
	}
}
