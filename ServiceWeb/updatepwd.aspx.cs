using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using System.Data;
using Web;
namespace ServiceWeb
{
    public partial class updatepwd : System.Web.UI.Page
    {
        private BLL.Member member = new Member();
        private BLL.ForgetPwdLog fpl = new ForgetPwdLog();
        private Model.Member muser = new Model.Member();
        private Model.ForgetPwdLog mfpl = new Model.ForgetPwdLog();
        private string strid;
        private string strdate;
        private string strcc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    strid = Request.QueryString["id"];
                    strdate = Request.QueryString["ca"];
                    strcc = Request.QueryString["cc"];
                    if (!string.IsNullOrEmpty(strid))
                    {
                        DataSet ds = fpl.GetList("UID=" + Convert.ToInt32(Web.Des.DecryptDes(strid))+" and Status=0");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(strid) && !string.IsNullOrEmpty(strdate) &&
                                !string.IsNullOrEmpty(strcc))
                            {
                                string struid = Web.Des.EncryptDes(ds.Tables[0].Rows[0]["UID"].ToString());
                                string strccs = ds.Tables[0].Rows[0]["Salt"].ToString();
                                DateTime dates = GetTime(strdate);
                                DateTime today = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"]);
                                string nums = RequeirDay(DateTime.Now.ToString(), dates.ToString());

                                if (Convert.ToInt32(nums) < 3 &&strid ==struid  && strcc == strccs.Trim())
                                {
                                    DataSet ds2 = member.GetList("ID=" + Convert.ToInt32(Web.Des.DecryptDes(strid)));
                                    this.uname.Value = ds2.Tables[0].Rows[0]["UserName"].ToString();
                                }
                                else
                                {
                                    jsb.JsHelper.AlertAndRedirect("链接已失效！", "index.aspx");
                                }

                            }
                            else
                            {
                                Response.Redirect("index.aspx");
                            }
                        }
                        else
                        {

                            jsb.JsHelper.AlertAndRedirect("链接已失效！", "index.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("index.aspx");

                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
               
            }

        }
        public string RequeirDay(string a, string b)
        {
            DateTime DateTime1,
            DateTime2 = Convert.ToDateTime(b);
            DateTime1 = Convert.ToDateTime(a);
            //设置要求的减的时间 
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            //显示时间             
            dateDiff = ts.Days.ToString();
            return dateDiff;

        }
        protected void But_OK_Click(object sender, EventArgs e)
        {
            string pwd = newpwd.Text.Trim();
            string pwdtwo = newpwdtwo.Text.Trim();

            //更新用户信息
            if(!string.IsNullOrEmpty(pwd))
            {
               
                if(pwdtwo==pwd)
                {
                    string strids = Web.Des.DecryptDes(Request.QueryString["id"]);
                    muser = member.GetModel(Convert.ToInt32(strids));
                    muser.PassWord = Web.User.Password(pwd, muser.Salt);
                    if (member.Update(muser) == true)
                    {
                        DataSet ds = fpl.GetList("UID=" + Convert.ToInt32(Web.Des.DecryptDes(Request.QueryString["id"])) + " and Status=0");
                        mfpl.UID = Convert.ToInt32(strids);
                        mfpl.Status = 1;
                        fpl.Updates(mfpl);
                        jsb.JsHelper.AlertAndRedirect("修改成功！", "Login.aspx");

                    }
                    else
                    {
                        jsb.JsHelper.Alert("修改失败！");
                    }
                }
                else
                {
                    jsb.JsHelper.Alert("两次密码输入不一致！");
                }
            }
            else
            {
                jsb.JsHelper.Alert("密码不能为空！");
            }

        }
        /// <summary>
        /// 时间戳转为C#格式时间搜索
        /// </summary>
        /// <param name=”timeStamp”></param>
        /// <returns></returns>
        private DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
    }
}