namespace Belin.Html.Elements;

using System.Net.Mime;

/// <summary>
/// Creates a new <c>form</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlFormElement"), Alias("form"), OutputType(typeof(string))]
public class NewFormElementCommand(): WriteElementCommand("form", isVoid: false) {

	/// <summary>
	/// The URL that processes the form submission.
	/// </summary>
	[Parameter]
	public Uri? Action { get; set; }

	/// <summary>
	/// Value indicating whether input elements can by default have their values automatically completed by the browser.
	/// </summary>
	[Parameter, ValidateSet("off", "on")]
	public string? AutoComplete { get; set; }

	/// <summary>
	/// The media type of the form submission.
	/// </summary>
	[Parameter, ValidateSet(MediaTypeNames.Application.FormUrlEncoded, MediaTypeNames.Multipart.FormData, MediaTypeNames.Text.Plain)]
	public string? EncType { get; set; }

	/// <summary>
	/// The HTTP method to submit the form with.
	/// </summary>
	[Parameter, ValidateSet("dialog", "get", "post")]
	public string? Method { get; set; }

	/// <summary>
	/// The name of the form.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Value indicating whether the form shouldn't be validated when submitted.
	/// </summary>
	[Parameter]
	public SwitchParameter NoValidate { get; set; }

	/// <summary>
	/// The annotations and what kinds of links the form creates.
	/// </summary>
	[Parameter]
	public string[] Rel { get; set; } = [];

	/// <summary>
	/// The browsing context to show the response after submitting the form.
	/// </summary>
	[Parameter]
	public string? Target { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Action is not null) attributes["action"] = Action;
		if (AutoComplete is not null) attributes["autocomplete"] = AutoComplete;
		if (EncType is not null) attributes["enctype"] = EncType;
		if (Method is not null) attributes["method"] = Method;
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (NoValidate) attributes["novalidate"] = true;
		if (Rel.Length > 0) attributes["rel"] = string.Join(' ', Rel).Trim();
		if (!string.IsNullOrWhiteSpace(Target)) attributes["target"] = Target;
	}
}
