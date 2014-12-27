using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using System.Data;

namespace ServiceWeb
{
    public partial class CompanyLogo : System.Web.UI.Page
    {
        private BLL.UserProfile userprofile = new UserProfile();
        BLL.PageManager pagemanager = new BLL.PageManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Binds("select * from dbo.EmphasisComPany	where Status>-1 and cid=1");
                Binds2("select * from dbo.EmphasisComPany	where Status>-1 and cid=2");
            }
        }

        public void Binds(string str)
        {
            int CurrentPage = AspNetPager1.CurrentPageIndex;
            int PageSize = AspNetPager1.PageSize;
            int RecordCount;
            DataSet ds = pagemanager.GetPage(str, CurrentPage, PageSize, out RecordCount);
            Rpt_logo.DataSource = ds;
            Rpt_logo.DataBind();
        }

        public void Binds2(string str)
        {
            int CurrentPage = AspNetPager2.CurrentPageIndex;
            int PageSize = AspNetPager2.PageSize;
            int RecordCount;
            DataSet ds = pagemanager.GetPage(str, CurrentPage, PageSize, out RecordCount);
            rpt_gao.DataSource = ds;
            rpt_gao.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Binds("select * from dbo.EmphasisComPany	where Status>-1 and cid=1");
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            Binds2("select * from dbo.EmphasisComPany	where Status>-1 and cid=2");
        }
    }
}