namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>script</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlScriptElement"), Alias("script"), OutputType(typeof(string))]
public class NewScriptElementCommand(): WriteElementCommand("script", isVoid: false) {

	/// <summary>
	/// Value indicating whether the script will be fetched in parallel to parsing and evaluated as soon as it is available.
	/// </summary>
	[Parameter]
	public SwitchParameter Async { get; set; }

	/// <summary>
	/// Value indicating whether CORS must be used when fetching the resource.
	/// </summary>
	[Parameter, ValidateSet("anonymous", "use-credentials")]
	public string? CrossOrigin { get; set; }

	/// <summary>
	/// Value indicating whether the script is meant to be executed after the document has been parsed, but before firing <c>DOMContentLoaded</c> event.
	/// </summary>
	[Parameter]
	public SwitchParameter Defer { get; set; }

	/// <summary>
	/// A base64-encoded cryptographic hash of the resource (file) to fetch.
	/// </summary>
	[Parameter]
	public string? Integrity { get; set; }

	/// <summary>
	/// The URI of an external script.
	/// </summary>
	[Parameter]
	public Uri? Src { get; set; }

	/// <summary>
	/// The type of script represented.
	/// </summary>
	[Parameter]
	public string? Type { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Src is not null) attributes["src"] = Src;
		if (Async) attributes["async"] = true;
		if (CrossOrigin is not null) attributes["crossorigin"] = CrossOrigin;
		if (Defer) attributes["defer"] = true;
		if (!string.IsNullOrWhiteSpace(Integrity)) attributes["integrity"] = Integrity;
		if (!string.IsNullOrWhiteSpace(Type)) attributes["type"] = Type;
	}
}
