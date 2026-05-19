namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>dialog</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlDialogElement"), Alias("dialog"), OutputType(typeof(string))]
public class NewDialogElementCommand(): WriteElementCommand("dialog", isVoid: false) {

	/// <summary>
	/// Specifies the types of user actions that can be used to close the element.
	/// </summary>
	[Parameter, ValidateSet("any", "closerequest", "none")]
	public string? ClosedBy { get; set; }

	/// <summary>
	/// Value indicating whether the dialog box is active and is available for interaction.
	/// </summary>
	[Parameter]
	public SwitchParameter Open { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (ClosedBy is not null) attributes["closedby"] = ClosedBy;
		if (Open) attributes["open"] = true;
	}
}
