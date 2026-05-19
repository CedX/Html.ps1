namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>meta</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlMetaElement", DefaultParameterSetName = nameof(Name)), Alias("meta"), OutputType(typeof(string))]
public class NewMetaElementCommand(): WriteElementCommand("meta", isVoid: true) {

	/// <summary>
	/// A charset declaration, giving the character encoding in which the document is encoded.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(Charset))]
	public required string Charset { get; set; }

	/// <summary>
	/// Contains the value for the <c>http-equiv</c> or <c>name attribute</c>, depending on which is used.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(HttpEquiv))]
	[Parameter(Mandatory = true, ParameterSetName = nameof(Name))]
	public override object? Content { get => base.Content; set => base.Content = value; }

	/// <summary>
	/// A pragma directive to simulate directives that could otherwise be given by an HTTP header.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(HttpEquiv))]
	public required string HttpEquiv { get; set; }

	/// <summary>
	/// Document-level metadata that applies to the whole page.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(Name))]
	public required string Name { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);

		switch (ParameterSetName) {
			case nameof(Charset):
				attributes["charset"] = Charset;
				break;
			case nameof(HttpEquiv):
				attributes["http-equiv"] = HttpEquiv;
				attributes["content"] = Content;
				break;
			case nameof(Name):
				attributes["name"] = Name;
				attributes["content"] = Content;
				break;
		}
	}
}
