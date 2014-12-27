using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ServiceWeb.DAL;
using ServiceWeb.Model;

namespace Web
{
    public class User
    {
        public ServiceWeb.Model.Member UserEntity = null;
        public ServiceWeb.Model.UserProfile UserProfileEntity = null;
        private static ServiceWeb.DAL.Member dauser = new ServiceWeb.DAL.Member();
        private static ServiceWeb.DAL.UserProfile dauserprofile = new ServiceWeb.DAL.UserProfile();
        public bool IsLogin = false;
        public bool IsAdmin = false;

        public User()
        {
            init();
        }

        private HttpCookie usercookie;
        private const string cookiename = "qyuser_tick";

        private void init()
        {
            usercookie = HttpContext.Current.Request.Cookies[cookiename];
            if (usercookie != null)
            {
                string id = usercookie.Values["uid"];
                string user = HttpContext.Current.Server.HtmlDecode(usercookie.Values["user"]);
                string[] userdata = Des.DecryptDes(user).Split('|');
                if (userdata[0] == id)
                {
                    IsLogin = true;
                    UserEntity = dauser.GetModel(Convert.ToInt32(id));
                    UserProfileEntity = dauserprofile.GetModel(Convert.ToInt32(userdata[1]));
                    if (UserEntity.AdminID.HasValue && UserEntity.AdminID.Value == 9)
                    {
                        IsAdmin = true;
                    }
                }
            }
        }

        public void Login(int uid, int pid)
        {
            string userdata = string.Format("{0}|{1}|{2}", uid, pid, DateTime.Now);
            usercookie = new HttpCookie(cookiename);
            usercookie.Values.Add("uid", uid.ToString());
            usercookie.Values.Add("user", HttpContext.Current.Server.HtmlEncode(Des.EncryptDes(userdata)));
            usercookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(usercookie);
            IsLogin = true;
        }

        public void Logout()
        {
            usercookie = HttpContext.Current.Request.Cookies[cookiename];
            if (usercookie != null)
            {
                usercookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(usercookie);
            }
            IsLogin = false;
        }

        public static bool ValidUser(string username, string password, ref ServiceWeb.Model.Member user, ref ServiceWeb.Model.UserProfile userProfile)
        {
            bool valid = false;
            DataSet dsuser = dauser.GetList("username = '" + username + "' and status = 1");
            if (dsuser != null && dsuser.Tables[0].Rows.Count > 0)
            {
                user = dauser.DataRowToModel(dsuser.Tables[0].Rows[0]);
                if (user != null && user.PassWord == Password(password, user.Salt))
                {
                    DataSet dsuserprofile = dauserprofile.GetList("uid = " + user.ID);
                    if (dsuserprofile != null && dsuserprofile.Tables[0].Rows.Count > 0)
                    {
                        userProfile = dauserprofile.DataRowToModel(dsuserprofile.Tables[0].Rows[0]);
                        valid = true;
                    }
                }
            }
            return valid;
        }

        public static string Salt()
        {
            return Helper.Left(Guid.NewGuid().ToString("N"), 8);
        }

        public static string Password(string password, string salt)
        {
            return Helper.SHA1(Helper.SHA1(password) + salt);
        }

        public static bool Delete(int uid)
        {
            DataSet dsuser = dauser.GetList("id = '" + uid + "'");
            if (dsuser != null && dsuser.Tables[0].Rows.Count > 0)
            {
                ServiceWeb.Model.Member member = dauser.DataRowToModel(dsuser.Tables[0].Rows[0]);
                member.Status = -1;
                dauser.Update(member);
                return true;
            }
            return false;
        }

        public static bool ActiveTurn(int uid)
        {
            bool trun = false;
            DataSet dsuser = dauser.GetList("id = " + uid + " and status > -1");
            if (dsuser != null && dsuser.Tables[0].Rows.Count > 0)
            {
                ServiceWeb.Model.Member member = dauser.DataRowToModel(dsuser.Tables[0].Rows[0]);
                member.Status = member.Status == 0 ? 1 : 0;
                dauser.Update(member);
                trun = true;
            }
            return trun;
        }
    }
}