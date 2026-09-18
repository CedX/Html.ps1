namespace Belin.Html.Elements;

using System.Management.Automation;

/// <summary>
/// Creates a new <c>{Tag}</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "Html{CapitalizedTag}Element"), Alias("{Alias}"), OutputType(typeof(string))]
public class New{CapitalizedTag}ElementCommand(): NewElementCommand("{Tag}", isVoid: {IsVoid}) {}
