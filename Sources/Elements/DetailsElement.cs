namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>details</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlDetailsElement"), Alias("details"), OutputType(typeof(string))]
public class NewDetailsElementCommand(): WriteElementCommand("details", isVoid: false) {

	/// <summary>
	/// The group name allowing multiple <c>details</c> elements to be connected, with only one open at a time.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Value indicating whether the details are currently visible.
	/// </summary>
	[Parameter]
	public SwitchParameter Open { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
		if (Open) attributes["open"] = true;
	}
}
