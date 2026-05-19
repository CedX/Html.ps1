namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>ins</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlInsElement"), Alias("ins"), OutputType(typeof(string))]
public class NewInsElementCommand(): WriteElementCommand("ins", isVoid: false) {

	/// <summary>
	/// A URI for a resource that explains the change.
	/// </summary>
	[Parameter]
	public Uri? Cite { get; set; }

	/// <summary>
	/// The date and time of the change.
	/// </summary>
	[Parameter]
	public object? DateTime { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Cite is not null) attributes["cite"] = Cite;

		if (DateTime is not null) {
			try {
				attributes["datetime"] = (DateTime is PSObject psObject ? psObject.BaseObject : DateTime) switch {
					DateOnly value => value.ToString("o"),
					DateTime value => value.ToString("o"),
					DateTimeOffset value => value.ToString("o"),
					_ => throw new NotSupportedException("The specified date/time value is not supported.")
				};
			}
			catch (NotSupportedException e) {
				WriteError(new ErrorRecord(e, "New-InsElement:NotSupportedException", ErrorCategory.InvalidArgument, DateTime));
			}
		}
	}
}
