namespace Belin.Html.Elements;

using System.Net.Mime;
using System.Text.RegularExpressions;

/// <summary>
/// Creates a new <c>input</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlInputElement"), Alias("input"), OutputType(typeof(string))]
public class NewInputElementCommand(): WriteElementCommand("input", isVoid: true) {

	/// <summary>
	/// Defines which file types are selectable in a file upload control.
	/// Valid for the <c>file</c> input type only.
	/// </summary>
	[Parameter]
	public string? Accept { get; set; }

	/// <summary>
	/// A text to display on browsers that do not display images.
	/// Valid for the <c>image</c> input type only.
	/// </summary>
	[Parameter]
	public string? Alt { get; set; }

	/// <summary>
	/// A hint for a user agent's autocomplete feature.
	/// </summary>
	[Parameter]
	public string[] AutoComplete { get; set; } = [];

	/// <summary>
	/// Value indicating which camera to use for capture of image or video data.
	/// </summary>
	[Parameter, ValidateSet("environment", "user")]
	public string? Capture { get; set; }

	/// <summary>
	/// Value indicating whether the checkbox is checked or the radio button is the currently selected one.
	/// </summary>
	[Parameter]
	public SwitchParameter Checked { get; set; }

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
	/// The URL that processes the information submitted by the button.
	/// Valid for the <c>image</c> and <c>submit</c> input types only.
	/// </summary>
	[Parameter]
	public Uri? FormAction { get; set; }

	/// <summary>
	/// Value indicating how to encode the form data that is submitted.
	/// Valid for the <c>image</c> and <c>submit</c> input types only.
	/// </summary>
	[Parameter, ValidateSet(MediaTypeNames.Application.FormUrlEncoded, MediaTypeNames.Multipart.FormData, MediaTypeNames.Text.Plain)]
	public string? FormEnctype { get; set; }

	/// <summary>
	/// The HTTP method used to submit the form.
	/// Valid for the <c>image</c> and <c>submit</c> input types only.
	/// </summary>
	[Parameter, ValidateSet("dialog", "get", "post")]
	public string? FormMethod { get; set; }

	/// <summary>
	/// Value indicating whether the form is not to be validated when it is submitted.
	/// Valid for the <c>image</c> and <c>submit</c> input types only.
	/// </summary>
	[Parameter]
	public SwitchParameter FormNoValidate { get; set; }

	/// <summary>
	/// The browsing context to show the response after submitting the form.
	/// Valid for the <c>image</c> and <c>submit</c> input types only.
	/// </summary>
	[Parameter]
	public string? FormTarget { get; set; }

	/// <summary>
	/// The intrinsic height of the image, in CSS pixels.
	/// Valid for the <c>image</c> input type only.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Height { get; set; } = -1;

	/// <summary>
	/// The identifier of a <c>datalist</c> element located in the same document..
	/// </summary>
	[Parameter]
	public string? List { get; set; }

	/// <summary>
	/// The greatest value in the range of permitted values.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public string? Max { get; set; }

	/// <summary>
	/// The maximum string length that the user can enter.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int MaxLength { get; set; } = -1;

	/// <summary>
	/// The lowest value in the range of permitted values.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public string? Min { get; set; }

	/// <summary>
	/// The minimum string length required that the user should enter.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int MinLength { get; set; } = -1;

	/// <summary>
	/// Value indicating whether the user can enter comma separated email addresses in the <c>email</c> widget or can choose more than one file with the <c>file</c> input.
	/// </summary>
	[Parameter]
	public SwitchParameter Multiple { get; set; }

	/// <summary>
	/// The name of the control.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// The regular expression that the <see cref="Value"/> must match in order for the value to pass constraint validation.
	/// </summary>
	[Parameter]
	public Regex? Pattern { get; set; }

	/// <summary>
	/// A hint to the user of what can be entered in the control.
	/// </summary>
	[Parameter]
	public string? Placeholder { get; set; }

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
	/// Value indicating how much of the input is shown.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.Positive)]
	public int Size { get; set; }

	/// <summary>
	/// The URL of the image file to display to represent the graphical button.
	/// Valid for the <c>image</c> input type only.
	/// </summary>
	[Parameter]
	public Uri? Src { get; set; }

	/// <summary>
	/// A number that specifies the granularity that the value must adhere to, or the special value <c>any</c>.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public string? Step { get; set; }

	/// <summary>
	/// The type of control to render.
	/// </summary>
	[Parameter, ValidateSet(
		"button", "checkbox", "color", "date", "datetime-local", "email",
		"file", "hidden", "image", "month", "number", "password",
		"radio", "range", "reset", "search", "submit", "tel",
		"text", "time", "url", "week"
	)]
	public string? Type { get; set; }

	/// <summary>
	/// The value of the control.
	/// </summary>
	[Parameter]
	public object? Value { get; set; }

	/// <summary>
	/// The intrinsic width of the image, in CSS pixels.
	/// Valid for the <c>image</c> input type only.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Width { get; set; } = -1;

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Accept)) attributes["accept"] = Accept;
		if (Alt is not null) attributes["alt"] = Alt;
		if (AutoComplete.Length > 0) attributes["autocomplete"] = string.Join(' ', AutoComplete).Trim();
		if (Capture is not null) attributes["capture"] = Capture;
		if (Checked) attributes["checked"] = true;
		if (!string.IsNullOrWhiteSpace(DirName)) attributes["dirname"] = DirName;
		if (Disabled) attributes["disabled"] = true;
		if (!string.IsNullOrWhiteSpace(Form)) attributes["form"] = Form;
		if (FormAction is not null) attributes["formaction"] = FormAction;
		if (FormEnctype is not null) attributes["formenctype"] = FormEnctype;
		if (FormMethod is not null) attributes["formmethod"] = FormMethod;
		if (FormNoValidate) attributes["formnovalidate"] = true;
		if (!string.IsNullOrWhiteSpace(FormTarget)) attributes["formtarget"] = FormTarget;
		if (Height >= 0) attributes["height"] = Height;
		if (!string.IsNullOrWhiteSpace(List)) attributes["list"] = List;
		if (!string.IsNullOrWhiteSpace(Max)) attributes["max"] = Max;
		if (MaxLength >= 0) attributes["maxlength"] = MaxLength;
		if (!string.IsNullOrWhiteSpace(Min)) attributes["min"] = Min;
		if (MinLength >= 0) attributes["minlength"] = MinLength;
		if (Multiple) attributes["multiple"] = true;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (Pattern is not null) attributes["pattern"] = Pattern.ToString().Replace(@"\", @"\\");
		if (!string.IsNullOrWhiteSpace(Placeholder)) attributes["placeholder"] = Placeholder;
		if (!string.IsNullOrWhiteSpace(PopoverTarget)) attributes["popovertarget"] = PopoverTarget;
		if (PopoverTargetAction is not null) attributes["popovertargetaction"] = PopoverTargetAction;
		if (ReadOnly) attributes["readonly"] = true;
		if (Required) attributes["required"] = true;
		if (Size > 0) attributes["size"] = Size;
		if (!string.IsNullOrWhiteSpace(Step)) attributes["step"] = Step;
		if (Type is not null) attributes["type"] = Type;
		if (Value is not null) attributes["value"] = Value;
		if (Width >= 0) attributes["width"] = Width;
	}
}
