using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web
{
    public class BasePage : System.Web.UI.Page
    {
        public Web.User CurrentUser = null;
        private void BaseLoad()
        {
            if (!Valid())
            {
                HttpContext.Current.Response.Write("<script type='text/javascript'>parent.location.href='/admin/login.aspx';</script>");
                HttpContext.Current.Response.End();
            }
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            BaseLoad();
        }

        private bool Valid()
        {
            bool valid = false;
            CurrentUser = new User();
            if (CurrentUser.IsLogin && CurrentUser.IsAdmin)
            {
                valid = true;
            }
            return valid;
        }

        public void ReWrite(string url, string mesage, int time)
        {
            Response.Redirect("/admin/urlredirect.aspx?url=" + Server.UrlEncode(url) + "&m=" + Server.UrlEncode(mesage) + "&t=" + time);
            Response.End();
        }
    }
}
