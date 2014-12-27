using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServiceWeb.BLL;
using Web;


namespace ServiceWeb
{
    public partial class AddDemands : System.Web.UI.Page
    {
        BLL.County conuty = new BLL.County();
        BLL.Demands demands = new BLL.Demands();
        BLL.DemandType dtype = new BLL.DemandType();
        Model.Demands mdemands = new Model.Demands();
        BLL.Member member = new BLL.Member();
        Web.User user = new User();
        Model.Member usertity = new Model.Member();
        Model.UserProfile userprofile = new Model.UserProfile();
        private BLL.UserProfile blluser = new UserProfile();
        private int rad;
        private string ac = string.Empty;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ac = Request.QueryString["ac"];
            id = Convert.ToInt32(Request.QueryString["id"]);
            Pre_loads();
            if (!IsPostBack)
            {
               Binds();
            }
        }

        public void Binds()
        {
             if (!string.IsNullOrEmpty(ac) && ac.Equals("editor"))
             {
                 if (!string.IsNullOrEmpty(id.ToString()))
                 {
                     mdemands = demands.GetModel(id);
                     
                     if(mdemands!=null)
                     {
                         string str = mdemands.DTypeID;
                         string[] strs = str.Split(',');

                         if (!string.IsNullOrEmpty(strs[1]))
                         {
                             for (int i = 0; i < strs.Length; i++)
                             {
                                 chk.Items.FindByValue(strs[i]).Selected = true;
                             }
                         }
                         else
                         {
                             chk.Items.FindByValue(strs[0]).Selected = true;
                         }
                         countyID.Items.FindByValue(mdemands.CountyID.ToString()).Selected = true;
                         title.Text = mdemands.Subject;
                         txteditor.InnerText = mdemands.Contents;

                     }

                 }
             }
        }

        public void Pre_loads()
        {
            if (user.IsLogin)
            {
                DataSet ds = blluser.GetList("UID=" + user.UserEntity.ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string cnames = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    string farens = ds.Tables[0].Rows[0]["LegalPerson"].ToString();
                    string addr = ds.Tables[0].Rows[0]["Address"].ToString();
                    string phones = ds.Tables[0].Rows[0]["Phone"].ToString();
                    string emails = ds.Tables[0].Rows[0]["Email"].ToString();
                    if (!string.IsNullOrEmpty(cnames) && !string.IsNullOrEmpty(farens) && !string.IsNullOrEmpty(addr) && !string.IsNullOrEmpty(phones) && !string.IsNullOrEmpty(emails))
                    {
                        Cname.Text = cnames;
                        faren.Text = farens;
                        address.Text = addr;
                        phone.Text = phones;
                        email.Text = emails;
                    }
                    else
                    {
                        jsb.JsHelper.AlertAndRedirect("信息不完整不能发布诉求！", "UpdateUserpfile.aspx");
                    }
                }


                SqlDataReader drs = conuty.DataRead2();
                while (drs.Read())
                {
                    countyID.Items.Add(new ListItem(drs["Name"].ToString(), drs["ID"].ToString()));
                }
                countyID.Items.Insert(0, new ListItem("请选择...", "0"));
                SqlDataReader sdr = dtype.DataDType();
                while (sdr.Read())
                {
                    chk.Items.Add(new ListItem(sdr["Name"].ToString(), sdr["ID"].ToString()));
                }
            }
            else
            {
                jsb.JsHelper.AlertAndRedirect("请先登录！", "Login.aspx");
            }
        }

        /// <summary>
        /// 生成诉求编号
        /// </summary>
        /// <param name="countyname"></param>
        /// <returns></returns>
        public string ShengchengBianhao(string countyname)
        {
            switch (countyname)
            {
                case "1": countyname = "AY";
                    break;
                case "8": countyname = "TY";
                    break;
                case "9": countyname = "HX";
                    break;
                case "10": countyname = "LZ";
                    break;
                case "11": countyname = "NH";
                    break;
                default: countyname = "AY";
                    break;
            }
            DateTime now = DateTime.Now;
            string year =DateTime.Now.Year.ToString("0000");
            string Month = DateTime.Now.Month.ToString("00");
            string day =DateTime.Now.Day.ToString("00");
            string ymd=year.ToString()+Month+day;
            DataSet ds = demands.GetList(1,"","ID desc");
            if(ds.Tables[0].Rows.Count>0)
            {
                rad = Convert.ToInt32(ds.Tables[0].Rows[0]["Serial"].ToString().Substring(10,5));
            }
            return countyname + ymd+(rad+1).ToString("00000");
           
        }

        protected void But_Add_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ac) && ac.Equals("editor"))
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return;
                }
                userprofile.UID = user.UserEntity.ID;
                userprofile.CompanyName = this.Cname.Text;
                userprofile.LegalPerson = faren.Text;
                userprofile.Address = address.Text;
                userprofile.Email = email.Text;
                userprofile.Phone = this.phone.Text;
                if (email.Text != "" && IsValidEmail(email.Text) == true)
                {
                    blluser.UpdateExpand(userprofile);
                }
                else
                {
                    jsb.JsHelper.Alert(Page,"邮箱格式不正确！");
                }
                string ck = "";
                for (int i = 0; i < chk.Items.Count; i++)
                {
                    if (chk.Items[i].Selected == true)
                    {
                        ck = ck + chk.Items[i].Value + ",";
                    }
                }

                if (countyID.SelectedValue != "0" && ck != "" && this.title.Text != "" && this.txteditor.Value != "")
                {
                    mdemands = demands.GetModel(id);
                    mdemands.ID = id;
                    mdemands.CountyID = Convert.ToInt32(countyID.SelectedValue);
                    mdemands.DTypeID = ck;
                    mdemands.UID = user.UserEntity.ID;
                    mdemands.Serial = mdemands.Serial;
                    mdemands.Subject = this.title.Text;
                    mdemands.Contents = txteditor.InnerText;
                    mdemands.AddTime = System.DateTime.Now;
                    mdemands.IP = Request.UserHostName;
                    ;
                    mdemands.Status = 0;
                    mdemands.DenyReason = "";
                    mdemands.IsDistribution = 0;
                    mdemands.Result = "";
                    demands.Update(mdemands);
                    Response.Write("<script>alert('修改成功！')</script>");
                    Response.Redirect("MyDemands.aspx?uid=" + user.UserEntity.ID + "");
                }
            }
            else
            {
                userprofile.UID = user.UserEntity.ID;
                userprofile.CompanyName = this.Cname.Text;
                userprofile.LegalPerson = faren.Text;
                userprofile.Address = address.Text;
                userprofile.Email = email.Text;
                userprofile.Phone = this.phone.Text;
                if (email.Text != "" && IsValidEmail(email.Text) == true)
                {
                    blluser.UpdateExpand(userprofile);
                }
                else
                {
                    //jsb.JsHelper.Alert("邮箱不能为空或格式不正确！");
                }


                string ck = "";
                for (int i = 0; i < chk.Items.Count; i++)
                {
                    if (chk.Items[i].Selected == true)
                    {
                        ck = ck + chk.Items[i].Value + ",";
                    }
                }
                if (countyID.SelectedValue != "0" && ck != "" && this.title.Text != "" && this.txteditor.Value != "")
                {
                    mdemands.CountyID = Convert.ToInt32(countyID.SelectedValue);
                    mdemands.DTypeID = ck;
                    mdemands.UID = user.UserEntity.ID;
                    mdemands.Serial = ShengchengBianhao(this.countyID.SelectedValue);
                    mdemands.Subject = this.title.Text;
                    mdemands.Contents = txteditor.InnerText;
                    mdemands.AddTime = System.DateTime.Now;
                    mdemands.IP = Request.UserHostName; ;
                    mdemands.Status = 0;
                    mdemands.DenyReason = "";
                    mdemands.IsDistribution = 0;
                    mdemands.Result = "";
                    demands.Add(mdemands);
                    Response.Write("<script>alert('发布成功！')</script>");
                    Response.Redirect("DemandList.aspx?uid=" + user.UserEntity.ID + "");
                }
                else
                {
                    // Response.Write("<script>alert('信息填写不完整！')</script>");
                }
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