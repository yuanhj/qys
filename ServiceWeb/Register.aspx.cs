using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Web;
using System.Text.RegularExpressions;

namespace ServiceWeb
{
    public partial class Register : System.Web.UI.Page
    {
        BLL.County countys = new BLL.County();
        Web.User user = new User();
        Model.Member usertity = new Model.Member();
        Model.UserProfile userprofile = new Model.UserProfile();
        BLL.Member blluser = new BLL.Member();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader sdr = countys.DataRead2();
                while (sdr.Read())
                {
                    county.Items.Add(new ListItem(sdr["Name"].ToString(), sdr["ID"].ToString()));
                }
                county.Items.Insert(0, new ListItem("请选择...", "0"));
            }
            
        }

        protected void But_Add_Click(object sender, ImageClickEventArgs e)
        {

            string uname=username.Value.Trim();
            string pwds="";
            string pwdrep = pwd_repet.Value.Trim();

            //Regex reg = new Regex(@"^[A-Za-z0-9]+$");
            //if (reg.IsMatch(pwd.Value))
            //{
                pwds = pwd.Value.Trim();
           //}
           // else
          //  {
               
               // jsb.JsHelper.Alert("密码输入格式不正确！");
           // }

            if (uname == "")
            {
               // jsb.JsHelper.Alert("用户名不为空！");
            }
            else if (uname.Length < 4)
            {
               
                //jsb.JsHelper.Alert("长度不小于4！");
            }
            else if (uname.Length > 16)
            {
                //jsb.JsHelper.Alert("长度不能超过16个字符！");
            }
            else if (pwds == "")
            {
                //jsb.JsHelper.Alert("密码不能为空！");
            }
            else if (pwdrep != pwds)
            {
               // jsb.JsHelper.Alert("两次密码输入不一致！");
            }
            else if (county.SelectedValue == "0")
            {
                //jsb.JsHelper.Alert("请选择区县！");
            }
            else
            {
                DataSet ds = blluser.GetList("UserName='" + uname + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    jsb.JsHelper.Alert("用户名已存在！");
                }
                else
                {
                    usertity.UserName = uname;
                    usertity.Salt = Web.User.Salt();
                    usertity.PassWord = Web.User.Password(pwds, usertity.Salt);
                    usertity.RegTime = System.DateTime.Now;
                    usertity.CountyID = Convert.ToInt32(county.SelectedValue);
                    usertity.RegIp = Request.UserHostAddress;
                    usertity.LastLoginIp = Request.UserHostAddress;
                    usertity.LastActiveTime = System.DateTime.Now;
                    usertity.LastLoginTime = System.DateTime.Now;
                    usertity.Status = 1;
                    usertity.AdminID = 0;//9为管理员 其它为普通用户
                    int uid = blluser.Add(usertity);
                    AddProfile(uid);
                    Response.Redirect("RegisterSecond.aspx?uid=" + uid);
                }
            }
        }
        private int AddProfile(int uid)
        {
            Model.UserProfile profile = new Model.UserProfile();
            profile.UID = uid;
            DAL.UserProfile dProfile = new DAL.UserProfile();
            return dProfile.Add(profile);
        }
        
    }
}