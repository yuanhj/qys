using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using Web;
using System.Data;

namespace ServiceWeb.Handler
{
    public partial class HeadMenu : System.Web.UI.UserControl
    {
        private BLL.County bllcounty = new County();
        BLL.UserProfile userprofile = new BLL.UserProfile();
        public bool a = false;
        public string usernames = "";
        Web.User users = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (users.IsLogin)
            {
                DataSet ds = userprofile.GetList("UID=" + users.UserEntity.ID);
                usernames = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                usernames = users.UserEntity.UserName;
                a = true;

            }
        }
    }
}