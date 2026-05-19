namespace Belin.Html.Elements;

using System.Xml;

/// <summary>
/// Creates a new <c>time</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlTimeElement"), Alias("time"), OutputType(typeof(string))]
public class NewTimeElementCommand(): WriteElementCommand("time", isVoid: false) {

	/// <summary>
	/// The time and/or date of the element.
	/// </summary>
	[Parameter]
	public object? DateTime { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);

		if (DateTime is not null) {
			try {
				attributes["datetime"] = (DateTime is PSObject psObject ? psObject.BaseObject : DateTime) switch {
					DateOnly value => value.ToString("o"),
					DateTime value => value.ToString("o"),
					DateTimeOffset value => value.ToString("o"),
					TimeOnly value => value.ToString("o"),
					TimeSpan value => XmlConvert.ToString(value),
					_ => throw new NotSupportedException("The specified date/time value is not supported.")
				};
			}
			catch (NotSupportedException e) {
				WriteError(new ErrorRecord(e, "New-TimeElement:NotSupportedException", ErrorCategory.InvalidArgument, DateTime));
			}
		}
	}
}
