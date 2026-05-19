namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>{Tag}</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "Html{CapitalizedTag}Element"), Alias("{Alias}"), OutputType(typeof(string))]
public class New{CapitalizedTag}ElementCommand(): WriteElementCommand("{Tag}", isVoid: {IsVoid}) {}
