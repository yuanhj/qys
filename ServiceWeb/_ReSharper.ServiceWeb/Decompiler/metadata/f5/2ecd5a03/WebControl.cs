// Type: System.Web.UI.WebControls.WebControl
// Assembly: System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll

using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Web;
using System.Web.UI;

namespace System.Web.UI.WebControls
{
  [ParseChildren(true)]
  [PersistChildren(false)]
  [Themeable(true)]
  public class WebControl : Control, IAttributeAccessor
  {
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected WebControl();
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public WebControl(HtmlTextWriterTag tag);
    protected WebControl(string tag);
    protected virtual void AddAttributesToRender(HtmlTextWriter writer);
    public void ApplyStyle(Style s);
    public void CopyBaseAttributes(WebControl controlSrc);
    protected virtual Style CreateControlStyle();
    protected override void LoadViewState(object savedState);
    protected override void TrackViewState();
    public void MergeStyle(Style s);
    protected internal override void Render(HtmlTextWriter writer);
    public virtual void RenderBeginTag(HtmlTextWriter writer);
    public virtual void RenderEndTag(HtmlTextWriter writer);
    protected internal virtual void RenderContents(HtmlTextWriter writer);
    protected override object SaveViewState();
    string IAttributeAccessor.GetAttribute(string name);
    void IAttributeAccessor.SetAttribute(string name, string value);
    [WebCategory("Accessibility")]
    [WebSysDescription("WebControl_AccessKey")]
    [DefaultValue("")]
    public virtual string AccessKey { get; set; }
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [WebSysDescription("WebControl_Attributes")]
    public System.Web.UI.AttributeCollection Attributes { get; }
    [TypeConverter(typeof (WebColorConverter))]
    [WebCategory("Appearance")]
    [DefaultValue(typeof (Color), "")]
    [WebSysDescription("WebControl_BackColor")]
    public virtual Color BackColor { get; set; }
    [DefaultValue(typeof (Color), "")]
    [WebSysDescription("WebControl_BorderColor")]
    [TypeConverter(typeof (WebColorConverter))]
    [WebCategory("Appearance")]
    public virtual Color BorderColor { get; set; }
    [WebCategory("Appearance")]
    [DefaultValue(typeof (Unit), "")]
    [WebSysDescription("WebControl_BorderWidth")]
    public virtual Unit BorderWidth { get; set; }
    [WebCategory("Appearance")]
    [WebSysDescription("WebControl_BorderStyle")]
    [DefaultValue(BorderStyle.NotSet)]
    public virtual BorderStyle BorderStyle { get; set; }
    [Browsable(false)]
    [WebSysDescription("WebControl_ControlStyle")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Style ControlStyle { get; }
    [WebSysDescription("WebControl_ControlStyleCreated")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool ControlStyleCreated { get; }
    [WebCategory("Appearance")]
    [CssClassProperty]
    [WebSysDescription("WebControl_CSSClassName")]
    [DefaultValue("")]
    public virtual string CssClass { get; set; }
    public static string DisabledCssClass { get; [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [WebSysDescription("WebControl_Style")]
    [Browsable(false)]
    public CssStyleCollection Style { get; }
    [WebSysDescription("WebControl_Enabled")]
    [Themeable(false)]
    [WebCategory("Behavior")]
    [DefaultValue(true)]
    [Bindable(true)]
    public virtual bool Enabled { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get; set; }
    [Browsable(true)]
    public override bool EnableTheming { get; set; }
    [NotifyParentProperty(true)]
    [WebCategory("Appearance")]
    [WebSysDescription("WebControl_Font")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public virtual FontInfo Font { get; }
    [DefaultValue(typeof (Color), "")]
    [WebCategory("Appearance")]
    [WebSysDescription("WebControl_ForeColor")]
    [TypeConverter(typeof (WebColorConverter))]
    public virtual Color ForeColor { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool HasAttributes { get; }
    [WebSysDescription("WebControl_Height")]
    [WebCategory("Layout")]
    [DefaultValue(typeof (Unit), "")]
    public virtual Unit Height { get; set; }
    protected internal bool IsEnabled { get; }
    [Browsable(false)]
    public virtual bool SupportsDisabledAttribute { get; }
    [Browsable(true)]
    public override string SkinID { get; set; }
    [DefaultValue(0)]
    [WebCategory("Accessibility")]
    [WebSysDescription("WebControl_TabIndex")]
    public virtual short TabIndex { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    protected virtual HtmlTextWriterTag TagKey { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get; }
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual string TagName { get; }
    [Localizable(true)]
    [DefaultValue("")]
    [WebSysDescription("WebControl_Tooltip")]
    [WebCategory("Behavior")]
    public virtual string ToolTip { get; set; }
    [WebSysDescription("WebControl_Width")]
    [WebCategory("Layout")]
    [DefaultValue(typeof (Unit), "")]
    public virtual Unit Width { get; set; }
  }
}
