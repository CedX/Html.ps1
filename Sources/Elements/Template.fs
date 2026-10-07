namespace Belin.Html.Elements

open Belin.Html
open System.Collections.Generic
open System.Management.Automation

/// Creates a new `template` element.
[<Cmdlet(VerbsCommon.New, "HtmlTemplateElement"); Alias("template"); OutputType(typeof<string>)>]
type NewTemplateElement() =
  inherit NewElementCommand("template", isVoid = false)

  /// Value indicating whether the shadow root is clonable.
  [<Parameter>]
  member val ShadowRootClonable = SwitchParameter false with get, set

  /// Value indicating whether the shadow root delegates focus.
  [<Parameter>]
  member val ShadowRootDelegatesFocus = SwitchParameter false with get, set

  /// Value indicating whether to create a shadow root for the parent element.
  [<Parameter; ValidateSet("closed", "open")>]
  member val ShadowRootMode: string | null = null with get, set

  /// Value indicating whether the shadow root is serializable.
  [<Parameter>]
  member val ShadowRootSerializable = SwitchParameter false with get, set

  /// Populates the specified attribute collection with the element attributes.
  override this.RenderAttributes (attributes: IDictionary<string, objnull>) =
    base.RenderAttributes attributes
    match this.ShadowRootMode with null -> () | value -> attributes["shadowrootmode"] <- value
    if this.ShadowRootClonable.IsPresent then attributes["shadowrootclonable"] <- true
    if this.ShadowRootDelegatesFocus.IsPresent then attributes["shadowrootdelegatesfocus"] <- true
    if this.ShadowRootSerializable.IsPresent then attributes["shadowrootserializable"] <- true
