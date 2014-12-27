using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceWeb
{
    public partial class MyDemands : System.Web.UI.Page
    {
        BLL.UserProfile userpfile = new BLL.UserProfile();
        BLL.PageManager pagemanager = new BLL.PageManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string uid = Request.QueryString["uid"];
                if(!string.IsNullOrEmpty(uid))
                {
                    Binds(Convert.ToInt32(uid));
                }
            }
        }
        public string Companyname(string uid)
        {
            if (uid != "")
            {
                return userpfile.GetList("UID=" + Convert.ToInt32(uid)).Tables[0].Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "";
            }
        }
        public string SelectStatus(string status)
        {
            switch (status)
            {
                case "0": return "未受理";
                    break;
                case "1": return "已受理";
                    break;
                case "2": return "办结完成";
                    break;
                case "3": return "拒绝办理";
                    break;
                case "4": return "办理中";
                    break;
                default: return "";
                    break;
            }
        }
        public void Binds(int uid)
        {
            string Sql = "select * from Demands where uid="+uid;
            int CurrentPage = AspNetPager1.CurrentPageIndex;
            int PageSize = AspNetPager1.PageSize;
            int RecordCount;
            DataSet ds = pagemanager.GetPage(Sql, CurrentPage, PageSize, out RecordCount);
            AspNetPager1.RecordCount = RecordCount;
            rpt_list.DataSource = ds;
            rpt_list.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            string uid = Request.QueryString["uid"];
            if (!string.IsNullOrEmpty(uid))
            {
                Binds(Convert.ToInt32(uid));
            }
        }
    }
}