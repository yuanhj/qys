using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using Web;
using System.Data;
namespace ServiceWeb
{
    public partial class Login : System.Web.UI.Page
    {
        Web.User users = new User();
        Model.Member usertity = new Model.Member();
        Model.UserProfile userprofiles = new Model.UserProfile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(users.IsLogin)
            {
               // DataSet ds = member.GetList("ID=" + Convert.ToInt32(user.UserEntity.ID));
                Response.Redirect("index.aspx");
            }
        }

        protected void But_OK_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["fcvalidtcode"];
            string yzm = "";
            if (cookie != null)
            {
                yzm = Request.Cookies["fcvalidtcode"].Value.ToLower();
            }
            string yanzheng = this.yanzheng.Value;
            if (yanzheng == yzm)
            {

                if (Web.User.ValidUser(this.name.Value, pswd.Value, ref usertity, ref userprofiles))
                {
                    users.Login(usertity.ID, userprofiles.ID);
                    Response.Redirect("index.aspx");
                    
                }
                else
                {
                    jsb.JsHelper.Alert(Page,"用户名或密码不正确！");
                }
            }
            else
            {
                jsb.JsHelper.Alert(Page, "验证码输入不正确！");
            }
        }
    }
}