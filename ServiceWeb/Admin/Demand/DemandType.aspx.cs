using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ServiceWeb.Admin.Demand
{
    public partial class DemandType : Web.BasePage
    {
        BLL.DemandType dtype = new BLL.DemandType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binds();
            }
        }

        protected void But_Add_Click(object sender, EventArgs e)
        {
            Model.DemandType mdtype = new Model.DemandType();
            mdtype.Name = typename.Text;
            mdtype.Status = "0";
            if (mdtype.Name != "")
            {
                if (dtype.GetList("Name='"+mdtype.Name+"' and status > -1").Tables[0].Rows.Count > 0)
                {
                    ReWrite(Request.UrlReferrer.ToString(), "已存在相同的类型名称", 1);
                }
                else
                {
                    dtype.Add(mdtype);
                    Binds();
                }
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "请填写类型名称", 1);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Binds();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Binds();
        }

        public void Binds()
        {
            GridView1.DataSource = dtype.GetList("status > -1");
            GridView1.DataKeyNames = new string[]{"id"};
            GridView1.DataBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.DemandType entity = dtype.GetModel(Convert.ToInt32(e.Keys["id"]));
            entity.Name = e.NewValues[0].ToString().Trim();
            dtype.Update(entity);
            GridView1.EditIndex = -1;
            Binds();   
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    LinkButton btnDel = (LinkButton) e.Row.Cells[2].Controls[2];
                    btnDel.Attributes.Add("class", "btncfm");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Keys["id"].ToString();
            if (BLL.DemandType.InUse(Convert.ToInt32(id)))
            {
                ReWrite(Request.UrlReferrer.ToString(), "不能删除正在使用的类型", 1);
            }
            Model.DemandType entity = dtype.GetModel(Convert.ToInt32(id));
            entity.Status = "-1";
            dtype.Update(entity);
            Binds();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binds();
        }
    }
}