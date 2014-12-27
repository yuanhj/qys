using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Web;
using System.Text.RegularExpressions;

namespace ServiceWeb
{
    public partial class RegisterSecond : System.Web.UI.Page
    {
        BLL.UserProfile userpfile = new BLL.UserProfile();
        BLL.County county = new BLL.County();
        BLL.Member member = new BLL.Member();
        Model.Member usertity=new Model.Member ();
        Model.UserProfile userprofile=new Model.UserProfile ();
        private Web.User user = new User();
        private string ac = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.QueryString["uid"];
            if (uid != null)
            {
                this.username.Value = member.GetList("ID="+Convert.ToInt32(uid)).Tables[0].Rows[0]["UserName"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }    
        }

        protected void Reg_OK_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string cname=companyname.Value.Trim();
                string faren = this.LegalPerson.Value.Trim();
                string emails= email.Value;
                if (cname == "")
                {
                    //Response.Write("<script>alert('公司名称不能为空！')</script>");
                }
                else if (faren == "")
                {
                    //Response.Write("<script>alert('法人不能为空！')</script>");
                }
                else if(emails=="")
                {
                    //jsb.JsHelper.Alert("邮箱不能为空！");
                }
                else
                {
                    if (IsValidEmail(emails) == true)
                    {
                        int uid = Convert.ToInt32(Request.QueryString["uid"]);
                        DataSet ds = userpfile.GetList("UID=" + uid);
                        userprofile.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                        userprofile.UID = uid;
                        userprofile.CompanyName = this.companyname.Value;
                        userprofile.Summary ="";
                        userprofile.LegalPerson = this.LegalPerson.Value;
                        userprofile.Address = this.address.Value;
                        userprofile.Phone = dwPhone.Value;
                        userprofile.WebSite = "";
                        userprofile.ContactName = ContactName.Value;
                        userprofile.Mobile = Mobile.Value;
                        userprofile.CLogo = "";
                        userprofile.Email = email.Value;
                        userprofile.IsTop = 0;
                        if (userpfile.Update(userprofile) == true)
                        {
                            user.Login(uid, uid);
                            Response.Redirect("RegisterThird .aspx");

                        }
                    }
                    else
                    {
                        //jsb.JsHelper.Alert("邮箱格式不正确！");
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        ///.NET 正则验证邮箱

        public bool IsValidEmail(string strIn)
        {
            //   Return   true   if   strIn   is   in   valid   e-mail   format. 
            return System.Text.RegularExpressions.Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
       
    }
}