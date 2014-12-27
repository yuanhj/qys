using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using System.Data;

namespace ServiceWeb.Admin
{

    public partial class Country : Web.BasePage
    {
        ServiceWeb.BLL.County county = new BLL.County();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreDbind();
                Binds();
            }
        }

        protected void But_Add_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string parentid = dpCounty.SelectedValue;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(parentid))
            {
                Model.County entity = new Model.County();
                entity.Parent = Convert.ToInt32(parentid);
                entity.Name = name;
                entity.Status = 0;
                entity.Paixu = Convert.ToInt32(this.paixu.Text);
                county.Add(entity);
                Binds();
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "请填写单位名称", 1);
            }
        }

        private void PreDbind()
        {
            BLL.County bllcounty = new County();
            DataSet ds = bllcounty.GetList("status > -1");
            dpCounty.DataSource = ds;
            dpCounty.DataValueField = "id";
            dpCounty.DataTextField = "name";
            dpCounty.DataBind();
            dpCounty.Items.Insert(0, new ListItem("一级单位", "0"));
        }

        /// <summary>
        /// 绑定显示
        /// </summary>
        private void Binds()
        {
            GridView1.DataSource = county.GetList("status > -1");
            GridView1.DataKeyNames = new string[]{"id"};
            GridView1.DataBind();
        }

        /// <summary>
        ///根据ID 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys["id"]);
            if (!BLL.County.CountyInUse(id))
            {
                Model.County entity = county.GetModel(id);
                if (entity != null)
                {
                    entity.Status = -1;
                    county.Update(entity);
                    Binds();
                }
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "不能删除正在使用的单位", 1);
            }
        }
        /// <summary>
        /// 根据ID修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            string name = e.NewValues[0].ToString().Trim();
            string paixu = ((TextBox) (GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                int id = Convert.ToInt32(e.Keys["id"]);
                if (BLL.County.NameInUse(id, name))
                {
                    ReWrite(Request.UrlReferrer.ToString(), "已存在该单位", 1);
                }
                Model.County entity = county.GetModel(id);
                entity.Name = name;
                entity.Paixu = Convert.ToInt32(paixu);
                county.Update(entity);
                GridView1.EditIndex = -1;
                Binds();
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "请填写单位名称", 1);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Binds();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Binds();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex=e.NewPageIndex;
            Binds();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                string pid = rowView["parent"].ToString();
                if (pid != "0")
                {
                    e.Row.Cells[2].Text = (new BLL.County()).CountyNameFromID(Convert.ToInt32(rowView["parent"]));
                }
                else
                {
                    e.Row.Cells[2].Text = "一级单位";
                }
                CheckBox chkrecommmend = (CheckBox)e.Row.Cells[3].FindControl("chkRecommmend");
                if ( rowView["recommend"].ToString() == "1")
                {
                    chkrecommmend.Checked = true;
                }
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    LinkButton btndel = (LinkButton) e.Row.Cells[5].Controls[2];
                    btndel.Attributes.Add("class", "btncfm");
                }

            }
        }

        protected void chkRecommmend_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            int index = ((GridViewRow)(chk.NamingContainer)).RowIndex;
            BLL.County bllcounty = new County();
            Model.County entity = bllcounty.GetModel(Convert.ToInt32(GridView1.DataKeys[index]["id"]));
            entity.Recommend = chk.Checked ? 1 : 0;
            bllcounty.Update(entity);
            Binds();
        }
    }
}