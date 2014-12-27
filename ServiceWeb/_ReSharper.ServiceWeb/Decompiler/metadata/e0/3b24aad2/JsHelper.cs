// Type: jsb.JsHelper
// Assembly: jsb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: D:\git\webser2012\ServiceWeb\ServiceWeb\bin\jsb.dll

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace jsb
{
  public class JsHelper
  {
    public static void Run(Page Page, string strCode, bool isTop);
    public static void Run(Page Page, string strCode, bool isTop, string IDStr);
    public static void Run(Page Page, bool isTop, string IDStr);
    public static void Alert(string msg);
    public static void Alert(Page Page, string msg);
    public static void Alert(Page Page, string msg, bool isTop);
    public static void AlertAndRedirect(string message, string toURL);
    public static void Import(Page Page, string filePath, bool isTop);
    public static void JsLoadCss(Page page, string cssFile);
    public static void LoadCss(PlaceHolder placeHolder, string cssFile);
    public static void LoadCss(Page page, string cssFile);
    public static void AddAttr(WebControl Control, string eventStr, string MsgStr);
    public static void AddAttr(HtmlGenericControl Control, string eventStr, string MsgStr);
    public static void AddAttr(HtmlControl Control, string eventStr, string MsgStr);
  }
}
