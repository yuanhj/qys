using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.DAL;

namespace ServiceWeb.Admin
{
    public partial class DeparmentShow : Web.BasePage
    {
        BLL.Department dpt = new BLL.Department();
        Model.Department mdpt = new Model.Department();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binds();
            }
        }
        private void Binds()
        {
            GridView1.DataSource = dpt.GetList("status > -1 and isnull(username,'') = ''");
            DataBind();

            SqlDataReader dr = dpt.DataReader();
            while (dr.Read())
            {
                dpBumen.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));

            }
            dpBumen.Items.Insert(0, new ListItem("请选择...", "0"));
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            if (dpt.Delete(id))
            {
                ReWrite(Request.UrlReferrer.ToString(), "删除成功", 1);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Binds();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                mdpt = dpt.GetModel(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]));
                mdpt.DepartmentName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
                if (dpt.Update(mdpt))
                {
                    Binds();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            GridView1.EditIndex = -1;
            Binds();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Binds();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    DataRowView rowv = (DataRowView)e.Row.DataItem;
                    e.Row.Cells[1].Text = CountryName(Convert.ToInt32(rowv["CountyID"]));
                    e.Row.Cells[3].Text = rowv["status"].ToString().Equals("0") ? "启用" : "禁用";
                    LinkButton btnDel = (LinkButton)e.Row.Cells[4].Controls[2];
                    btnDel.Attributes.Add("class", "btncfm");
                }
            }
        }

        private string CountryName(int id)
        {
            Model.County county = (new DAL.County()).GetModel(id);
            if (county != null)
            {
                return county.Name;
            }
            return "";
        }

        protected void ButSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpBumen.SelectedValue != "0" || dpBumen.Text != "")
                {
                    mdpt.CountyID = Convert.ToInt32(dpBumen.SelectedValue);
                    mdpt.DepartmentName = UserName.Text.Trim();
                    mdpt.ParentID = 0;
                    mdpt.Status = 0;
                    mdpt.UserName = "";
                    mdpt.Mobile = "";
                    dpt.Add(mdpt);
                    Response.Redirect("DeparmentShow.aspx");
                }
                else
                {
                    Response.Write("<script>alert('信息填写不完整！');</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binds();
        }
    }
}