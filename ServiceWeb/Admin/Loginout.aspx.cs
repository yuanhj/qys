using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace ServiceWeb.Admin
{
    public partial class Loginout : System.Web.UI.Page
    {
        Web.User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            user.Logout();
            Response.Redirect("index.aspx");
            
        }
    }
}