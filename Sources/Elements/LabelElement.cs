namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>label</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlLabelElement"), Alias("label"), OutputType(typeof(string))]
public class NewLabelElementCommand(): WriteElementCommand("label", isVoid: false) {

	/// <summary>
	/// The identifier of the labelable form control in the same document.
	/// </summary>
	[Parameter]
	public string? For { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(For)) attributes["for"] = For;
	}
}
