namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>template</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlTemplateElement"), Alias("template"), OutputType(typeof(string))]
public class NewTemplateElementCommand(): WriteElementCommand("template", isVoid: false) {

	/// <summary>
	/// Value indicating whether the shadow root is clonable.
	/// </summary>
	[Parameter]
	public SwitchParameter ShadowRootClonable { get; set; }

	/// <summary>
	/// Value indicating whether the shadow root delegates focus.
	/// </summary>
	[Parameter]
	public SwitchParameter ShadowRootDelegatesFocus { get; set; }

	/// <summary>
	/// Value indicating whether to create a shadow root for the parent element.
	/// </summary>
	[Parameter, ValidateSet("closed", "open")]
	public string? ShadowRootMode { get; set; }

	/// <summary>
	/// Value indicating whether the shadow root is serializable.
	/// </summary>
	[Parameter]
	public SwitchParameter ShadowRootSerializable { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (ShadowRootMode is not null) attributes["shadowrootmode"] = ShadowRootMode;
		if (ShadowRootClonable) attributes["shadowrootclonable"] = true;
		if (ShadowRootDelegatesFocus) attributes["shadowrootdelegatesfocus"] = true;
		if (ShadowRootSerializable) attributes["shadowrootserializable"] = true;
	}
}
