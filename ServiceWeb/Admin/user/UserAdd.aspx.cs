using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using ServiceWeb.BLL;
using UserProfile = ServiceWeb.Model.UserProfile;
using System.Data.SqlClient;

namespace ServiceWeb.Admin
{
    public partial class UserAdd : Web.BasePage
    {
        Model.Member muser = new Model.Member();
        BLL.Member blluser = new BLL.Member();
        private BLL.County county = new County();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader dr = county.DataRead();
                while (dr.Read())
                {
                    countys.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
                }
                countys.Items.Insert(0, new ListItem("请选择...", "0"));
                Dbind();
            }
        }
        protected void But_Add_Click(object sender, EventArgs e)
        {
            string username = UserName.Text.Trim();
            string password = Password.Text.Trim();

            muser.UserName = username;
            muser.Salt = Web.User.Salt();
            muser.PassWord = Web.User.Password(password, muser.Salt);
            muser.RegTime = System.DateTime.Now;
            muser.RegIp = Request.UserHostAddress;
            muser.LastLoginIp = Request.UserHostAddress;
            muser.LastActiveTime = System.DateTime.Now;
            muser.LastLoginTime = System.DateTime.Now;
            muser.Status = 1;
            muser.CountyID = Convert.ToInt32(countys.SelectedValue); 
            muser.AdminID = 9;//9为管理员 其它为普通用户

            if (username != "" || password != "")
            {
                DataSet ds = blluser.GetList("UserName='" + this.UserName.Text + "' and status > -1");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script>alert('用户名已存在！');</script>");
                }
                else
                {
                    int uid = blluser.Add(muser);
                    AddProfile(uid);
                    Dbind();
                }
            }
            else
            {
                Response.Write("<script>alert('信息不完整！');</script>");
            }
        }

        private int AddProfile(int uid)
        {
            Model.UserProfile profile = new UserProfile();
            profile.UID = uid;
            DAL.UserProfile dProfile = new DAL.UserProfile();
           return dProfile.Add(profile);
        }

        protected void Dbind()
        {
            DataSet ds = blluser.GetList("adminid = 9 and status > -1");
            rptList.DataSource = ds;
            rptList.DataBind();
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int uid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Delete":
                    DeleteUser(uid);
                    Dbind();
                    break;
                case "Active":
                    ActiveUser(uid);
                    Dbind();
                    break;
            }
        }

        private void ActiveUser(int uid)
        {
            if (CurrentUser != null && CurrentUser.UserEntity.ID == uid)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "nodelete", "<script>alert('不能禁用当前登录的用户');</script>");
                return;
            }
            Web.User.ActiveTurn(uid);
        }

        private void DeleteUser(int uid)
        {
            if (CurrentUser != null && CurrentUser.UserEntity.ID == uid)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "nodelete", "<script>alert('不能删除当前登录的用户');</script>");
                return;
            }
            Web.User.Delete(uid);
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView row = (DataRowView)e.Item.DataItem;
                Label lbStatus = (Label)e.Item.FindControl("lbStatus");
                lbStatus.Text = row["Status"].ToString().Equals("1") ? "启用" : "禁用";

                Button btnActive = (Button) e.Item.FindControl("btnActive");
                btnActive.Text = row["Status"].ToString().Equals("1") ? "禁用" : "启用";
            }
        }

        public string GetCname(string cid)
        {
            DataSet ds = county.GetList("ID=" + Convert.ToInt32(cid));
            string str = "";
            if(ds.Tables[0].Rows.Count>0)
            {
                str = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            return str;
        }
    }
}