using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.BLL;
using Member = ServiceWeb.BLL.Member;
using UserProfile = ServiceWeb.DAL.UserProfile;

namespace ServiceWeb.Admin.user
{
    public partial class UserProfileShow : Web.BasePage
    {
        BLL.VMemberInfo bllvMemberInfo = new VMemberInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pre_Load();
                Binds();
            }
        }

        private void Pre_Load()
        {
            BLL.County bllcounty = new County();
            DataSet ds = bllcounty.GetList("status > -1");
            dpSearchCounty.DataSource = ds;
            dpSearchCounty.DataTextField = "Name";
            dpSearchCounty.DataValueField = "id";
            dpSearchCounty.DataBind();
            dpSearchCounty.Items.Insert(0, new ListItem("不限", ""));
        }

        private void Binds()
        {
            string county = dpSearchCounty.SelectedValue;
            string keyword = tbSearchKey.Text.Trim();
            string sql = "status > -1 and adminid = 0";
            if (!string.IsNullOrEmpty(county))
            {
                sql += " and CountyID = " + county;
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " and (username like '%" + keyword + "%' or companyname like '%" + keyword + "%' or LegalPerson like '%" + keyword + "%' or mobile like '%" + keyword + "%')";
            }
            GridView1.DataSource = bllvMemberInfo.GetList(sql);
            GridView1.DataKeyNames = new string[]{"id"};
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            Binds();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex]["id"].ToString();
            Response.Redirect("userprofileadd.aspx?ac=edit&id=" + id);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Keys["id"].ToString();
            if (id == CurrentUser.UserEntity.ID.ToString())
            {
                ReWrite(Request.UrlReferrer.ToString(), "不能删除当前用户", 1);
            }
            BLL.Member bllmember = new BLL.Member();
            Model.Member member = bllmember.GetModel(Convert.ToInt32(id));
            member.Status = -1;
            bllmember.Update(member);
            Binds();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState | DataControlRowState.Edit) > 0)
                {
                    LinkButton btnDel = (LinkButton) e.Row.Cells[9].Controls[2];
                    btnDel.Attributes.Add("class", "btncfm");
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binds();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binds();
        }
    }
}