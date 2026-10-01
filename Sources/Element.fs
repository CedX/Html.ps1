namespace Belin.Html

open System
open System.Collections
open System.Collections.Generic
open System.Collections.Specialized
open System.Globalization
open System.Linq
open System.Management.Automation
open System.Text
open System.Text.Encodings.Web
open System.Text.Json

/// Contains operations for working with validation rules.
module private Element =

  /// The HTML-encoded string corresponding to a double quote.
  let encodedDoubleQuote = HtmlEncoder.Default.Encode "\""

  /// Converts the specified according to the lowercase kebab-casing.
  let kebabCase = JsonNamingPolicy.KebabCaseLower.ConvertName

  /// Converts the specified key/value pair to a CSS property.
  let toCssProperty (entry: DictionaryEntry): string =
    let value = (string entry.Value).Replace("\"", encodedDoubleQuote)
    $"{kebabCase (string entry.Key)}: {value}"

  /// Converts the specified key/value pair to an HTML attribute.
  let toHtmlAttribute (entry: KeyValuePair<string, objnull>): string =
    match entry.Value with
    | :? bool as value -> if value then $" {entry.Key}" else ""
    | :? SwitchParameter as value -> if value.IsPresent then $" {entry.Key}" else ""
    | value ->
      let encodedValue = (string value).Replace("\"", encodedDoubleQuote)
      $@" {entry.Key}=""{encodedValue}"""

/// Provides the abstract base class for a cmdlet rendering an HTML element.
[<AbstractClass>]
type NewElementCommand (tagName: string, isVoid: bool) =
  inherit PSCmdlet ()

  /// The child content of the element.
  let mutable content: objnull = null

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
  abstract member Content: objnull with get, set
  default _.Content with get() = content and set(value: objnull) = content <- value

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
    let builder = StringBuilder()
    let tag = this.TagName.ToLowerInvariant()

    // Build the map of attributes to render.
    let attributes =
      this.Attributes
        .Cast<DictionaryEntry>()
        .ToDictionary((fun entry -> string entry.Key), (fun entry -> entry.Value), StringComparer.OrdinalIgnoreCase)

    this.RenderAttributes attributes

    // Render the opening tag.
    let htmlAttributes =
      attributes
      |> Seq.filter (fun entry -> not (isNull entry.Value))
      |> Seq.map Element.toHtmlAttribute

    builder.Append($"<{tag}").AppendJoin("", htmlAttributes).Append '>' |> ignore<StringBuilder>

    // Render the child content and the closing tag.
    if not this.IsVoid then
      let output =
        match this.Content with
        | null -> Seq.empty
        | :? ScriptBlock as scriptBlock -> scriptBlock.Invoke() |> Seq.map (fun psObject -> psObject.BaseObject)
        | content -> seq { content }

      builder.AppendJoin("", output).Append $"</{tag}>" |> ignore<StringBuilder>

    this.WriteObject (string builder)

  /// Populates the specified attribute collection with the element attributes.
  abstract member RenderAttributes: IDictionary<string, objnull> -> unit
  default this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    for entry in Seq.cast<DictionaryEntry> this.Aria do attributes[$"aria-{(string entry.Key).ToLowerInvariant()}"] <- entry.Value
    match this.AutoCapitalize with null -> () | value -> attributes["autocapitalize"] <- value
    if this.AutoFocus.IsPresent then attributes["autofocus"] <- true
    if this.Class.Length > 0 then attributes["class"] <- (String.concat " " this.Class).Trim()
    match this.ContentEditable with null -> () | value -> attributes["contenteditable"] <- value
    for entry in Seq.cast<DictionaryEntry> this.DataSet do attributes[$"data-{Element.kebabCase (string entry.Key)}"] <- entry.Value
    match this.Dir with null -> () | value -> attributes["dir"] <- value
    match this.Draggable with null -> () | value -> attributes["draggable"] <- value
    if this.Hidden.IsPresent then attributes["hidden"] <- true
    for entry in Seq.cast<DictionaryEntry> this.Hx do attributes[$"hx-{Element.kebabCase (string entry.Key)}"] <- entry.Value
    if not (String.IsNullOrWhiteSpace this.Id) then attributes["id"] <- this.Id
    if this.Inert.IsPresent then attributes["inert"] <- true
    match this.InputMode with null -> () | value -> attributes["inputmode"] <- value
    match this.Lang with null -> () | value -> attributes["lang"] <- value.Name
    for entry in Seq.cast<DictionaryEntry> this.On do attributes[$"on{(string entry.Key).ToLowerInvariant()}"] <- entry.Value
    match this.Popover with null -> () | value -> attributes["popover"] <- value
    if not (String.IsNullOrWhiteSpace this.Role) then attributes["role"] <- this.Role
    if not (String.IsNullOrWhiteSpace this.Slot) then attributes["slot"] <- this.Slot
    match this.SpellCheck with null -> () | value -> attributes["spellcheck"] <- value
    if this.Style.Count > 0 then attributes["style"] <- this.Style |> Seq.cast<DictionaryEntry> |> Seq.map Element.toCssProperty |> String.concat "; "
    if this.TabIndex.HasValue then attributes["tabindex"] <- this.TabIndex.Value
    if not (String.IsNullOrWhiteSpace this.Title) then attributes["title"] <- this.Title
    match this.Translate with null -> () | value -> attributes["translate"] <- value

/// Creates a new custom element.
[<Cmdlet(VerbsCommon.New, "HtmlCustomElement"); Alias("tag"); OutputType(typeof<string>)>]
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
    and set(value: objnull) = base.Content <- value
