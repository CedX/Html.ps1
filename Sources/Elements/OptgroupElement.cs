namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>optgroup</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlOptgroupElement"), Alias("optgroup"), OutputType(typeof(string))]
public class NewOptgroupElementCommand(): WriteElementCommand("optgroup", isVoid: false) {

	/// <summary>
	/// Value indicating whether none of the items in the option group is selectable.
	/// </summary>
	[Parameter]
	public SwitchParameter Disabled { get; set; }

	/// <summary>
	/// The name of the group of options.
	/// </summary>
	[Parameter]
	public required string Label { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["label"] = Label;
		if (Disabled) attributes["disabled"] = true;
	}
}
