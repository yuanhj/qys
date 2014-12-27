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

namespace ServiceWeb.Admin.Demand
{
    public partial class DemandShow : Web.BasePage
    {
        BLL.Demands demands = new BLL.Demands();
        BLL.County county = new BLL.County();
        private string companyname = string.Empty;
        protected int CountyID = 1;
        private HttpCookie usercookie;
        private const string cookiename = "county_id";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pre_Dbind();
                Binds();
                CountyID = BaseLoad();
               

            }
        }

        private void Pre_Dbind()
        {
            BLL.County bllcounty = new County();
            DataSet ds = bllcounty.GetList("status > -1");
            dpSearchCounty.DataSource = ds;
            dpSearchCounty.DataTextField = "Name";
            dpSearchCounty.DataValueField = "id";
            dpSearchCounty.DataBind();
            dpSearchCounty.Items.Insert(0, new ListItem("不限", ""));

            companyname = Request.QueryString["cname"];
            if (!string.IsNullOrEmpty(companyname))
            {
                tbSearchKey.Text = companyname;
            }

            BLL.DemandType blldemandtype = new BLL.DemandType();
            ds = blldemandtype.GetList("status > -1");
            dpSearchDType.DataSource = ds;
            dpSearchDType.DataTextField = "Name";
            dpSearchDType.DataValueField = "id";
            dpSearchDType.DataBind();
            dpSearchDType.Items.Insert(0, new ListItem("不限", ""));

            dpSearchStatus.Items.Add(new ListItem("不限", ""));
            dpSearchStatus.Items.Add(new ListItem(DemandsStatus.未受理.ToString(), ((int)DemandsStatus.未受理).ToString()));
            dpSearchStatus.Items.Add(new ListItem(DemandsStatus.已受理.ToString(), ((int)DemandsStatus.已受理).ToString()));
            dpSearchStatus.Items.Add(new ListItem(DemandsStatus.办理中.ToString(), ((int)DemandsStatus.办理中).ToString()));
            dpSearchStatus.Items.Add(new ListItem(DemandsStatus.办结完成.ToString(), ((int)DemandsStatus.办结完成).ToString()));
        }

        /// <summary>
        /// 获取所有诉求
        /// </summary>
        public void Binds()
        {
            string county = dpSearchCounty.SelectedValue;
            string key = tbSearchKey.Text.Trim();
            string type = dpSearchDType.SelectedValue;
            string status = dpSearchStatus.SelectedValue;
            string sql = "status > -1";
            if (!string.IsNullOrEmpty(county))
            {
                sql += " and countyid = " + county;
            }
            if (!string.IsNullOrEmpty(type))
            {
                sql += " and charindex('," + type + ",', ',' + DTypeID + ',') > 0";
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " and status = '" + status + "'";
            }
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (uid in (select id from vmemberinfo where status > -1 and companyname like '%" + key + "%') or subject like '%" + key + "%' or Serial like '%" + key + "%' or cast(Contents as nvarchar(4000)) like '%" + key + "%')";
            }
            gvList.DataSource = demands.GetList(sql+" order by id desc");
            gvList.DataBind();
        }

      protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            Binds();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView) e.Row.DataItem;
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    DemandsStatus status = demands.Status(rowView["status"].ToString());
                    e.Row.Cells[6].Text = status.ToString();
                    e.Row.Cells[1].Text = county.CountyNameFromID(Convert.ToInt32(rowView["countyid"]));
                    e.Row.Cells[2].Text = string.Join(",", (new BLL.DemandType()).NameFromIDs(rowView["DTypeID"].ToString()));
                    e.Row.Cells[3].Text = Web.Helper.BuildLinkString("/Admin/user/userprofileadd.aspx?ac=edit&id=" + rowView["uid"], (new BLL.UserProfile()).GetModelFromUID(Convert.ToInt32(rowView["uid"])).CompanyName, "");
                }
            }
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "edit":
                    Response.Redirect("UpdateDemands.aspx?id=" + id);
                    break;
                case "deny":
                    Response.Redirect("../Shuqiushouli/Refuse.aspx?id=" + id);
                    break;
                case "allow":
                    Response.Redirect("../Shuqiushouli/Shouli.aspx?id=" + id);
                    break;
                case "done":
                    Response.Redirect("DemandResult.aspx?id=" + id);
                    break;
                case "Process":
                    Response.Redirect("Banli.aspx?did=" + id);
                    break;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binds();
        }

        private int BaseLoad()
        {
            usercookie = new HttpCookie(cookiename);
            string cid = HttpContext.Current.Request.QueryString["cid"];
            if (!string.IsNullOrEmpty(cid))
            {
                CountyID = Convert.ToInt32(cid);
                usercookie.Values.Add("countyid", cid.ToString());
                usercookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(usercookie);
            }
            else
            {
                usercookie = HttpContext.Current.Request.Cookies[cookiename];
                if (usercookie != null)
                {
                    return CountyID = Convert.ToInt32(usercookie["countyid"].ToString());
                }
            }
            return CountyID;
        }
    }
}