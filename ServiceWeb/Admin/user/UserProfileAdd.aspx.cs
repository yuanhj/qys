using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ServiceWeb.Model;
using Web;
using System.IO;
namespace ServiceWeb.Admin.user
{
    public partial class UserProfileAdd : Web.BasePage
    {
        private string ac = string.Empty;
        BLL.UserProfile upfile = new BLL.UserProfile();
        BLL.Member bllMember =new BLL.Member();
        Model.UserProfile mupfile = new Model.UserProfile();
        Model.Member mMember = new Member();
        private string uid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ac = Request.QueryString["ac"];
            Pre_Load();
            if (!IsPostBack)
            {
                Dbind();
            }
        }

        private void Dbind()
        {
            if (!string.IsNullOrEmpty(ac) && ac.Equals("edit"))
            {
                if (!string.IsNullOrEmpty(uid))
                {
                    mMember = bllMember.GetModel(Convert.ToInt32(uid));
                    mupfile = upfile.GetModelFromUID(Convert.ToInt32(uid));
                    if (mupfile != null)
                    {
                        CompanyName.Text = mupfile.CompanyName;
                        LegalPerson.Text = mupfile.LegalPerson;
                        Address.Text = mupfile.Address;
                        phone.Text = mupfile.Phone;
                        website.Text = mupfile.WebSite;
                        ContactName.Text = mupfile.ContactName;
                        mobile.Text = mupfile.Mobile;
                        Email.Text = mupfile.Email;
                        summary.Text = mupfile.Summary;
                        county.SelectedValue = mMember.CountyID.ToString();
                        county.Enabled = false;
                        tbUserName.Text = mMember.UserName;
                        tbUserName.Enabled = false;
                        if (!string.IsNullOrEmpty(mupfile.CLogo))
                        {
                            litIogo.Text = "<a href='" + mupfile.CLogo + "' target='_blank'><img src='" + mupfile.CLogo + "' class='clogo' alt='' border='0' /></a>";
                        }
                    }
                }
                else
                {
                    ReWrite("/admin/user/UserProfileShow.aspx", "未找到该用户", 1);
                }
            }
        }

        private void Pre_Load()
        {
            uid = Request.QueryString["id"];
            SqlDataReader dr = upfile.Datareader();
            while (dr.Read())
            {
                county.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }
            county.Items.Insert(0, new ListItem("请选择...", "0"));
            county.SelectedValue = "1"; ///todo: delete this line.
            county.Enabled = false; ///todo: delete this line.
        }

        protected void But_add_Click(object sender, EventArgs e)
        {
            Model.Member member = null;
            Model.UserProfile userProfile = null;
            string companyname = CompanyName.Text.Trim();
            string summ = summary.Text.Trim();
            string legalperson = LegalPerson.Text.Trim();
            string address = Address.Text.Trim();
            string sphone = phone.Text.Trim();
            string swebsite = website.Text.Trim();
            string contacname = ContactName.Text.Trim();
            string smobile = mobile.Text.Trim();
            string email = Email.Text.Trim();
            string logo = string.Empty;
            string password = tbPassWord.Text.Trim();
            string username = tbUserName.Text.Trim();
            //file
            string filename = string.Empty;
            if (fuLogo.HasFile)
            {
                string dictionary = "/uploadimg/" + DateTime.Now.ToString("yyyyMM");
                if (!Directory.Exists(Server.MapPath(dictionary)))
                {
                    Directory.CreateDirectory(Server.MapPath(dictionary));
                }
                filename = dictionary + "/" + System.Guid.NewGuid().ToString("N") +
                                  System.IO.Path.GetExtension(fuLogo.FileName).ToLower();
                fuLogo.SaveAs(Server.MapPath(filename));
                logo = filename;
            }

            if (!string.IsNullOrEmpty(ac) && ac.Equals("edit"))
            {
                if (string.IsNullOrEmpty(uid))
                {
                    return;
                }
                member = bllMember.GetModel(Convert.ToInt32(uid));
                userProfile = upfile.GetModelFromUID(Convert.ToInt32(uid));
                if (upfile.HadCompanyName(userProfile.ID, companyname))
                {
                    ReWrite(Request.UrlReferrer.ToString(), "已存在相同的企业名", 1);
                }
                //更新用户信息
                if (!string.IsNullOrEmpty(password))
                {
                    member.PassWord = Web.User.Password(password, member.Salt);
                    bllMember.Update(member);
                }
                //更新详细信息
                userProfile.CompanyName = companyname;
                userProfile.Summary = summ;
                userProfile.Address = address;
                userProfile.Phone = sphone;
                userProfile.WebSite = swebsite;
                userProfile.ContactName = contacname;
                userProfile.Mobile = smobile;
                userProfile.Email = email;
                userProfile.LegalPerson = legalperson;
                userProfile.CLogo = !string.IsNullOrEmpty(logo) ? logo : userProfile.CLogo;
                userProfile.ID = userProfile.ID;
                userProfile.IsTop = Convert.ToInt32(this.IsTop.SelectedValue);
                upfile.Update(userProfile);
                Dbind();
            }
            else
            {
                if (upfile.HaveCompanyName(companyname) || bllMember.HaveUserName(username))
                {
                    ReWrite("/admin/user/userprofileadd.aspx", "已存在相同的用户名或企业名", 1);
                }
                //添加用户信息
                int uid = 0;
                member = new Member();
                member.UserName = username;
                member.Salt = Web.User.Salt();
                member.PassWord = Web.User.Password(password, member.Salt);
                member.RegIp = Web.Helper.UserHostAddress();
                member.RegTime = DateTime.Now;
                member.CountyID = Convert.ToInt32(county.SelectedValue);
                member.LastActiveTime = DateTime.Now;
                member.LastLoginTime = DateTime.Now;
                member.Status = 0;
                member.AdminID = 0;
                try
                {
                    uid = bllMember.Add(member);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                //添加详细信息
                userProfile = new UserProfile();
                userProfile.UID = uid;
                userProfile.IsTop = 0;
                userProfile.Summary = summ;
                userProfile.Address = address;
                userProfile.Phone = sphone;
                userProfile.WebSite = swebsite;
                userProfile.ContactName = contacname;
                userProfile.Mobile = smobile;
                userProfile.Email = email;
                userProfile.CLogo = !string.IsNullOrEmpty(logo) ? logo : "";
                userProfile.CompanyName = companyname;
                try
                {
                    upfile.Add(userProfile);
                }
                catch (Exception ex)
                {
                    //删除出错数据
                    bllMember.Delete(uid);
                    throw new Exception(ex.Message);
                }
                Dbind();
            }
        }
    }
}