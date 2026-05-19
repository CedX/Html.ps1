namespace Belin.Html;

/// <summary>
/// Creates a new custom element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlCustomElement"), Alias("tag"), OutputType(typeof(string))]
public class NewCustomElementCommand(): WriteElementCommand("", isVoid: false) {

	/// <summary>
	/// The inner HTML of the element.
	/// </summary>
	[Parameter(Position = 1, ValueFromPipeline = true)]
	public override object? Content { get => base.Content; set => base.Content = value; }

	/// <summary>
	/// The tag name of the element to create.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0)]
	public required string Name { get => TagName; set => TagName = value; }
}
