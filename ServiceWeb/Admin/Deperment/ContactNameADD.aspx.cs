using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ServiceWeb.Model;
using County = ServiceWeb.BLL.County;
using VContactInfo = ServiceWeb.BLL.VContactInfo;

namespace ServiceWeb.Admin.Deperment
{
    public partial class ContactNameADD : Web.BasePage
    {
        BLL.Department dpt = new BLL.Department();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreDbind();
                Dbind();
            }
        }

        private void Dbind()
        {
            BLL.VContactInfo bllvcontactinfo = new VContactInfo();
            DataSet ds = bllvcontactinfo.GetList("status > -1");
            gvList.DataSource = ds;
            gvList.DataKeyNames = new string[]{"cid"};
            gvList.DataBind();
        }

        private void PreDbind()
        {
            BLL.County bllcounty = new County();
            DataSet ds = bllcounty.GetList("status > -1");
            dpCounty.DataSource = ds;
            dpCounty.DataTextField = "Name";
            dpCounty.DataValueField = "id";
            dpCounty.DataBind();
            dpCounty.Items.Insert(0, new ListItem("请选择", ""));

            DepermentItemLoad();
        }

        private void DepermentItemLoad()
        {
            bumen.Items.Clear();
            string key = dpCounty.SelectedValue;
            if (!string.IsNullOrEmpty(key))
            {
                string sql = "status > -1";
                sql += " and CountyID =" + key;
                DataSet ds = dpt.GetList(sql);
                bumen.DataSource = ds;
                bumen.DataTextField = "DepartmentName";
                bumen.DataValueField = "id";
                bumen.DataBind();
            }
            bumen.Items.Insert(0, new ListItem("请选择", "0"));
        }

        protected void ButSave_Click(object sender, EventArgs e)
        {
            string conty = dpCounty.SelectedValue;
            string department = bumen.SelectedValue;
            string contact = UserName.Text.Trim();
            string mobile = Mobile.Text.Trim();
            if (!string.IsNullOrEmpty(conty) && !string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(contact) && !string.IsNullOrEmpty(mobile))
            {
                Model.Department modal = new Department();
                modal.CountyID = Convert.ToInt32(conty);
                modal.ParentID = Convert.ToInt32(department);
                modal.UserName = contact;
                modal.Mobile = mobile;
                modal.Status = 0;
                dpt.Add(modal);
            }
            Dbind();
        }

        protected void dpCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepermentItemLoad();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    LinkButton btnDel = (LinkButton)e.Row.Cells[5].Controls[2];
                    btnDel.Attributes.Add("class", "btncfm");
                }
            }
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            Dbind();
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvList.DataKeys[e.RowIndex]["cid"].ToString();
            dpt.Delete(Convert.ToInt32(id));
            ReWrite(Request.UrlReferrer.ToString(), "删除成功", 1);
        }

        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvList.EditIndex = e.NewEditIndex;
            Dbind();
        }

        protected void gvList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvList.EditIndex = -1;
            Dbind();
        }

        protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string contact = e.NewValues[0].ToString();
            string mobile = e.NewValues[1].ToString();
            if (!string.IsNullOrEmpty(contact) && !string.IsNullOrEmpty(mobile))
            {
                Model.Department modal = dpt.GetModel(Convert.ToInt32(e.Keys["cid"]));
                if (modal != null)
                {
                    modal.UserName = contact;
                    modal.Mobile = mobile;
                    dpt.Update(modal);
                }
                ReWrite(Request.UrlReferrer.ToString(), "更新成功", 1);
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "信息不完整", 1);
            }
        }
    }
}