using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ServiceWeb.Admin.uploadbanner
{
    public partial class BannerShow : System.Web.UI.Page
    {
        BLL.BannerImg img = new BLL.BannerImg();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binds();
            }
        }

        public void Binds()
        {
            gvList.DataSource = img.GetList("Status>-1");
            gvList.DataBind();
        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            Binds();
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "edit")
            {
                Response.Redirect("UpdateBannImg.aspx?id="+id);
            }
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                 DataRowView rowView = (DataRowView) e.Row.DataItem;
                e.Row.Cells[4].Text = ResultStatus(rowView["Status"].ToString());
                e.Row.Cells[5].Text = (new BLL.County()).CountyNameFromID(Convert.ToInt32(rowView["countyid"]));
            }
        }
        public string ResultStatus(string num)
        {
            switch (num)
            {
                case "0":
                    return "正常";
                    break;
                    ;
                default:
                    return "未启用";
                    break;
            }
        }
       

    }
}