using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.BLL;

namespace ServiceWeb.Admin
{
    public partial class PostShow : Web.BasePage
    {
        BLL.Post post = new BLL.Post();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pre_Load();
                Binds();
            }
        }
        private void Binds()
        {
            string county = dpSearchCounty.SelectedValue;
            string keywork = tbSearchKey.Text.Trim();
            string type = dpSearchType.SelectedValue;
            string sql = "status > -1";
            if (!string.IsNullOrEmpty(county))
            {
                sql += " and countyid = " + county;
            }
            if (!string.IsNullOrEmpty(type))
            {
                sql += " and typeid =" + type;
            }
            if (!string.IsNullOrEmpty(keywork))
            {
                sql += " and (subject like '%" + keywork + "%' or message like '%" + keywork + "%')";
            }
            GridView1.DataSource = post.GetList(1000, sql, "id desc");
            GridView1.DataKeyNames = new string[]{"id"};
            GridView1.DataBind();
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
            BLL.PostType bllposttype = new PostType();
            ds = bllposttype.GetList("status > -1");
            dpSearchType.DataSource = ds;
            dpSearchType.DataTextField = "name";
            dpSearchType.DataValueField = "id";
            dpSearchType.DataBind();
            dpSearchType.Items.Insert(0, new ListItem("不限", ""));
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            Model.Post mpost = post.GetModel(ID);
            if (mpost.IsSystem.HasValue && mpost.IsSystem.Value == 1)
            {
                ReWrite(Request.UrlReferrer.ToString(), "不能删除系统文章", 1);
            }
            if (post.Delete(mpost))
            {
                 Binds();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex]["id"].ToString();
            Response.Redirect("post.aspx?ac=edit&id="+id);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binds();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    LinkButton btnDel = (LinkButton)e.Row.Cells[7].Controls[2];
                    btnDel.Attributes.Add("class", "btncfm");
                }
                DataRowView rowView = (DataRowView) e.Row.DataItem;
                CheckBox chkTop = (CheckBox)e.Row.Cells[5].FindControl("chkIsTop");
                chkTop.Checked = rowView["istop"].ToString() == "1";
                e.Row.Cells[1].Text = (new BLL.County()).CountyNameFromID(Convert.ToInt32(rowView["countyid"]));
                e.Row.Cells[2].Text = BLL.PostType.NameFromID(Convert.ToInt32(rowView["typeid"]));
            }
        }

        protected void chkTop_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox) sender;
            int index = ((GridViewRow)(chk.NamingContainer)).RowIndex;
            BLL.Post bllPost = new BLL.Post();
            Model.Post post = bllPost.GetModel(Convert.ToInt32(GridView1.DataKeys[index]["id"]));
            post.IsTop = chk.Checked ? 1 : 0;
            bllPost.Update(post);
            Binds();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binds();
        }
    }
}