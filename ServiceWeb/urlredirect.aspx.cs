using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceWeb.Admin
{
    public partial class urlredirect : Web.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string time = Request.QueryString["t"];
            string message = Request.QueryString["m"];
            string url = Request.QueryString["url"];

            litMessage.Text = Server.UrlDecode(message);
            if (!string.IsNullOrEmpty(url))
            {
                Response.Write("<meta http-equiv=\"refresh\" content=\"" + (!string.IsNullOrEmpty(time) ? time : "3") + ";url=" + Server.UrlDecode(url) + "\" />");
            }
        }
    }
}