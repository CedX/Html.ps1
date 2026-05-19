namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>slot</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlSlotElement"), Alias("slot"), OutputType(typeof(string))]
public class NewSlotElementCommand(): WriteElementCommand("slot", isVoid: false) {

	/// <summary>
	/// The slot's name.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
	}
}
