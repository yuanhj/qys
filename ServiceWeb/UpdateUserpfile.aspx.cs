using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web;
namespace ServiceWeb
{
    public partial class UpdateUserpfile : System.Web.UI.Page
    {
        BLL.UserProfile userpfile = new BLL.UserProfile();
        BLL.County county = new BLL.County();
        BLL.Member member = new BLL.Member();
        Model.Member usertity = new Model.Member();
        Web.User user = new User();
        Model.UserProfile userprofile = new Model.UserProfile();
        private int strid;
        private int istop;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (user.IsLogin)
                {
                    DataSet ds = userpfile.GetList("UID=" + user.UserEntity.ID);
                    strid = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    string cname = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    // Response.Write(user.UserEntity.UserName);
                    username.Value = user.UserEntity.UserName;
                    companyname.Value = cname;
                    txtcontext.Value = ds.Tables[0].Rows[0]["Summary"].ToString();
                    LegalPerson.Value = ds.Tables[0].Rows[0]["LegalPerson"].ToString();
                    address.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                    dwPhone.Value = ds.Tables[0].Rows[0]["Phone"].ToString();
                    website.Value = ds.Tables[0].Rows[0]["WebSite"].ToString();
                    ContactName.Value = ds.Tables[0].Rows[0]["ContactName"].ToString();
                    Mobile.Value = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    email.Value = ds.Tables[0].Rows[0]["Email"].ToString();
                    if (ds.Tables[0].Rows[0]["IsTop"].ToString() == "")
                    {
                        istop = 0;
                    }
                    else
                    {
                        istop = Convert.ToInt32(ds.Tables[0].Rows[0]["IsTop"]);

                    }
                   
                  
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void But_Update_Click(object sender, EventArgs e)
        {
            DataSet ds = userpfile.GetList("UID=" + user.UserEntity.ID);
            strid = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            if (email.Value != "" && IsValidEmail(email.Value.Trim()) == true)
            {
                userprofile.ID = strid;
                userprofile.CompanyName = companyname.Value;
                userprofile.UID = Convert.ToInt32(ds.Tables[0].Rows[0]["UID"]);
                userprofile.Summary = txtcontext.Value;
                userprofile.CLogo = ds.Tables[0].Rows[0]["CLogo"].ToString();
                userprofile.LegalPerson = LegalPerson.Value;
                userprofile.Address = address.Value;
                userprofile.Phone = dwPhone.Value;
                userprofile.WebSite = website.Value;
                userprofile.ContactName = ContactName.Value;
                userprofile.Mobile = Mobile.Value;
                userprofile.Email = email.Value;
                userprofile.IsTop = istop;

                if (userpfile.Update(userprofile) == true)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('修改信息有误！')</script>");
                }
            }
            else
            {
                jsb.JsHelper.Alert("邮箱不能为空或格式不正确！");
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