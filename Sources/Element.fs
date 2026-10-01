namespace Belin.Html

open System
open System.Collections
open System.Collections.Specialized
open System.Globalization
open System.Collections.Generic
open System.Management.Automation
open System.Text
open System.Text.Json
open System.Text.Encodings.Web

/// Provides the abstract base class for a cmdlet rendering an HTML element.
[<AbstractClass>]
type NewElementCommand (tagName: string, isVoid: bool) =
  inherit PSCmdlet ()

  /// The HTML-encoded string corresponding to a double quote.
  static let encodedDoubleQuote = HtmlEncoder.Default.Encode "\""

  /// The child content of the element.
  let mutable content: obj | null = null

  /// Value indicating whether the element to create is a void element.
  member val internal IsVoid: bool = isVoid with get, set

  /// The tag name of the element to create.
  member val internal TagName: string = tagName with get, set

  /// The ARIA attributes to render.
  [<Parameter>]
  member val Aria = Hashtable() with get, set

  /// The custom attributes to render.
  [<Parameter>]
  member val Attributes = Hashtable() with get, set

  /// Value indicating whether inputted text is automatically capitalized.
  [<Parameter; ValidateSet("characters", "none", "off", "on", "sentences", "words")>]
  member val AutoCapitalize: string | null = null with get, set

  /// Value indicating whether the element should have input focus when the page loads.
  [<Parameter>]
  member val AutoFocus = SwitchParameter false with get, set

  /// The CSS class names applied to the element.
  [<Parameter>]
  member val Class: string array = [||] with get, set

  /// The child content of the element.
  [<Parameter(Position = 1, ValueFromPipeline = true)>]
  abstract member Content: obj | null with get, set
    default _.Content
      with get() = content
      and set(value: obj | null) = content <- value

  /// Value indicating whether the element is editable by the user.
  [<Parameter; ValidateSet("false", "plaintext-only", "true")>]
  member val ContentEditable: string | null = null with get, set

  /// The data attributes to render.
  [<Parameter>]
  member val DataSet = Hashtable() with get, set

  /// The directionality of the element's text.
  [<Parameter; ValidateSet("auto", "ltr", "rtl")>]
  member val Dir: string | null = null with get, set

  /// Value indicating whether the element can be dragged.
  [<Parameter; ValidateSet("false", "true")>]
  member val Draggable: string | null = null with get, set

  /// Value indicating whether the browser should not render the contents of this element.
  [<Parameter>]
  member val Hidden = SwitchParameter false with get, set

  /// The `htmx` attributes to render.
  [<Parameter>]
  member val Hx = Hashtable() with get, set

  /// The element identifier.
  [<Parameter>]
  member val Id: string | null = null with get, set

  /// Value indicating whether the browser should disregard user input events for the element.
  [<Parameter>]
  member val Inert = SwitchParameter false with get, set

  /// A hint at the type of data that might be entered by the user while editing the element or its contents.
  [<Parameter; ValidateSet("decimal", "email", "none", "numeric", "search", "tel", "text", "url")>]
  member val InputMode: string | null = null with get, set

  /// The element's language.
  [<Parameter>]
  member val Lang: CultureInfo | null = null with get, set

  /// Value indicating whether the element is a popover element.
  [<Parameter; ValidateSet("auto", "hint", "manual")>]
  member val Popover: string | null = null with get, set

  /// The event handler attributes to render.
  [<Parameter>]
  member val On = Hashtable() with get, set

  /// Defines the semantic meaning of content.
  [<Parameter>]
  member val Role: string | null = null with get, set

  /// Assigns a slot in a shadow DOM shadow tree to the element.
  [<Parameter>]
  member val Slot: string | null = null with get, set

  /// Value indicating whether the element is subject to spell-checking by the underlying browser/OS.
  [<Parameter; ValidateSet("false", "true")>]
  member val SpellCheck: string | null = null with get, set

  /// The CSS styling declarations applied to the element.
  [<Parameter>]
  member val Style: IDictionary = OrderedDictionary() with get, set

  /// Determines the relative ordering of the element for sequential focus navigation.
  [<Parameter>]
  member val TabIndex = Nullable<int>() with get, set

  /// A text representing advisory information related to the element.
  [<Parameter>]
  member val Title: string | null = null with get, set

  /// Value indicating whether the element's text should be translated when the page is localized.
  [<Parameter; ValidateSet("no", "yes")>]
  member val Translate: string | null = null with get, set

  /// Performs execution of this command.
  override this.ProcessRecord () =
    // var attributes = Attributes.Cast<DictionaryEntry>().ToDictionary(entry => entry.Key.ToString() ?? "", entry => entry.Value, StringComparer.OrdinalIgnoreCase)
    // RenderAttributes(attributes)

    // var tag = TagName.ToLowerInvariant()
    // var builder = new StringBuilder($"<{tag}")

    // foreach (var (key, value) in attributes.Where(attribute => attribute.Value is not null)) {
    //   if (value is bool booleanValue) {
    //     if (booleanValue) builder.Append($" {key}")
    //   }
    //   else if (value is SwitchParameter switchParameter) {
    //     if (switchParameter) builder.Append($" {key}")
    //   }
    //   else {
    //     var stringValue = Convert.ToString(value, CultureInfo.InvariantCulture)?.Replace("\"", encodedDoubleQuote)
    //     builder.Append($" {key}=\"{stringValue}\"")
    //   }
    // }

    // if (IsVoid) builder.Append('>')
    // else {
    //   var output = Content is ScriptBlock scriptBlock ? scriptBlock.Invoke().Select(psObject => psObject.BaseObject) : (Content is not null ? [Content] : [])
    //   builder.Append('>')
    //   foreach (var value in output) builder.Append(value)
    //   builder.Append($"</{tag}>")
    // }

    // WriteObject(builder.ToString())
    ()

  /// Populates the specified attribute collection with the element attributes.
  member this.RenderAttributes (attributes: IDictionary<string, obj | null>) = // TODO protected virtual void
    let kebabCase = JsonNamingPolicy.KebabCaseLower.ConvertName

  //   foreach (DictionaryEntry entry in Aria) attributes[$"aria-{entry.Key.ToString()?.ToLowerInvariant()}"] = entry.Value
  //   if (AutoCapitalize is not null) attributes["autocapitalize"] = AutoCapitalize
  //   if (AutoFocus) attributes["autofocus"] = true
  //   if (Class.Length > 0) attributes["class"] = string.Join(' ', Class).Trim()
  //   if (ContentEditable is not null) attributes["contenteditable"] = ContentEditable
  //   foreach (DictionaryEntry entry in DataSet) attributes[$"data-{kebabCase(entry.Key.ToString() ?? "")}"] = entry.Value
  //   if (Dir is not null) attributes["dir"] = Dir
  //   if (Draggable is not null) attributes["draggable"] = Draggable
  //   if (Hidden) attributes["hidden"] = true
  //   foreach (DictionaryEntry entry in Hx) attributes[$"hx-{kebabCase(entry.Key.ToString() ?? "")}"] = entry.Value
  //   if (!string.IsNullOrWhiteSpace(Id)) attributes["id"] = Id
  //   if (Inert) attributes["inert"] = true
  //   if (InputMode is not null) attributes["inputmode"] = InputMode
  //   if (Lang is not null) attributes["lang"] = Lang.Name
  //   foreach (DictionaryEntry entry in On) attributes[$"on{entry.Key.ToString()?.ToLowerInvariant()}"] = entry.Value
  //   if (Popover is not null) attributes["popover"] = Popover
  //   if (!string.IsNullOrWhiteSpace(Role)) attributes["role"] = Role
  //   if (!string.IsNullOrWhiteSpace(Slot)) attributes["slot"] = Slot
  //   if (SpellCheck is not null) attributes["spellcheck"] = SpellCheck
  //   if (TabIndex is not null) attributes["tabindex"] = TabIndex.Value
  //   if (!string.IsNullOrWhiteSpace(Title)) attributes["title"] = Title
  //   if (Translate is not null) attributes["translate"] = Translate

  //   if (Style.Count > 0) attributes["style"] = string.Join("; ", Style.Cast<DictionaryEntry>()
  //     .Select(entry => $"{kebabCase(entry.Key.ToString() ?? "")}: {Convert.ToString(entry.Value, CultureInfo.InvariantCulture)?.Replace("\"", encodedDoubleQuote)}"))
    ()

/// Creates a new custom element.
[<Cmdlet(VerbsCommon.New, "HtmlCustomElement"); OutputType(typeof<string>)>]
type NewCustomElementCommand () =
  inherit NewElementCommand ("", isVoid = false)

  /// The tag name of the element to create.
  [<Parameter(Mandatory = true, Position = 1)>]
  member this.Name
    with get() = this.TagName
    and set(value: string) = this.TagName <- value

  /// The child content of the element.
  [<Parameter(Position = 2, ValueFromPipeline = true)>]
  override _.Content
    with get() = base.Content
    and set(value: obj | null) = base.Content <- value
