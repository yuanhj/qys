using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web;
using System.Data;
namespace ServiceWeb.Handler
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
    {
        Web.User user = new User();
        Model.Member usertity = new Model.Member();
        Model.UserProfile userprofile = new Model.UserProfile();
        BLL.Member blluser = new BLL.Member();
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                string username = System.Web.HttpUtility.HtmlDecode(context.Request.QueryString["username"]);
                string pwd = context.Request.QueryString["pwd"];
                string county = context.Request.QueryString["county"];
                usertity.UserName = username;
                usertity.Salt = Web.User.Salt();
                usertity.PassWord = Web.User.Password(pwd, usertity.Salt);
                usertity.RegTime = System.DateTime.Now;
                usertity.CountyID = Convert.ToInt32(county);
                usertity.RegIp = context.Request.UserHostAddress;
                usertity.LastLoginIp = context.Request.UserHostAddress;
                usertity.LastActiveTime = System.DateTime.Now;
                usertity.LastLoginTime = System.DateTime.Now;
                usertity.Status = 1;
                usertity.AdminID = 0;//9为管理员 其它为普通用户
                DataSet ds = blluser.GetList("UserName='" + username + "' and status > -1");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    context.Response.Write("no");
                }
                else
                {
                    int uid = blluser.Add(usertity);
                    AddProfile(uid);
                    // context.Response.Redirect("zhuce2.html?uid="+uid);
                    context.Response.Write(uid.ToString());
                }
            }
            catch
            {
                context.Response.Write("no");
            }

        }
        private int AddProfile(int uid)
        {
            Model.UserProfile profile = new Model.UserProfile();
            profile.UID = uid;
            DAL.UserProfile dProfile = new DAL.UserProfile();
            return dProfile.Add(profile);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}