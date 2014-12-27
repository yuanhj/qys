using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using Web;
using System.Data;
namespace ServiceWeb.Admin
{
    public partial class index :BasePage
    {
        private Web.RequestBase rb = new RequestBase();
        private BLL.Member bmember = new Member();
        private Web.User users = new User();
        private HttpCookie usercookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser != null && CurrentUser.IsAdmin)
            {
                usercookie = new HttpCookie("county_id");
                DataSet ds = bmember.GetList("ID=" +users.UserEntity.ID);
                usercookie.Values.Add("countyid", ds.Tables[0].Rows[0]["CountyID"].ToString());
                usercookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(usercookie);
                btnLogout.Visible = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Logout();
            ClientScript.RegisterClientScriptBlock(GetType(), "relogin", "<script type='text/javascript'>location.href = 'login.aspx';</script>");
        }
    }
}