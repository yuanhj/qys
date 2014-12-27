using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb;
using ServiceWeb.BLL;
using Web;
using System.Data;

namespace ServiceWeb.Admin
{
    public partial class Login : Web.RequestBase
    {
        private Web.User user;
        private Model.Member userentity;
        private Model.UserProfile userProfile;
        private BLL.Member bmember = new Member();
        private string ac = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ac = Request.QueryString["ac"];
            Pre_Load();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string username = tbUserName.Value.Trim();
            string password = tbPassWord.Value.Trim();
            string yanzheng = yzm.Value.Trim();
            HttpCookie cookie = Request.Cookies["fcvalidtcode"];
            string stryzm ="";
            if (cookie != null)
            {
                stryzm = Request.Cookies["fcvalidtcode"].Value.ToLower();
            }

            if (yanzheng == stryzm)
            {

                if (Web.User.ValidUser(username, password, ref userentity, ref userProfile))
                {

                    Web.User user = new User();
                    user.Login(userentity.ID, userProfile.ID);
                    DataSet ds = bmember.GetList("ID=" + userentity.ID);
                    Response.Redirect("~/admin/index.aspx?cid="+ds.Tables[0].Rows[0]["CountyID"]);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "login-error", "<script>alert('用户名或密码错误');</script>");

                }

            }
            else
            {
                
                jsb.JsHelper.AlertAndRedirect("验证码不正确！","Login.aspx");
            }
            
        }
        private void Pre_Load()
        {
            user=new User();
            if (!string.IsNullOrEmpty(ac) && ac.Equals("logout"))
            {
                user.Logout();
            }
            if (user.IsLogin && user.IsAdmin)
            {
                Response.Redirect("~/admin/index.aspx");
                Response.End();
            }
        }
    }
}