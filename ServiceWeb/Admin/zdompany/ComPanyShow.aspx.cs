using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using System.Data.SqlClient;

namespace ServiceWeb.Admin.zdompany
{
    public partial class ComPanyShow : System.Web.UI.Page
    {
        private BLL.EmphasisComPany company = new EmphasisComPany();
        private Model.EmphasisComPany mcompany = new Model.EmphasisComPany();
        private BLL.CompanyType ctypes=new CompanyType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlDataReader sdr = ctypes.GetCompany();
                while (sdr.Read())
                {
                    ctype.Items.Add(new ListItem(sdr["Name"].ToString(), sdr["ID"].ToString()));
                }

                Binds();
            }
        }
        public void Binds()
        {
            GridView1.DataSource = company.GetList("Status=0");
           // GridView1.DataKeyNames = new string[] { "id" };
            GridView1.DataBind();
        }

        public void tuijian__CheckedChanged(object sender,EventArgs e)
        {
            CheckBox chk = (CheckBox) sender;
            int index = ((GridViewRow) (chk.NamingContainer)).RowIndex;
            mcompany = company.GetModel(Convert.ToInt32(GridView1.DataKeys[index]["ID"]));
            mcompany.IsTop = chk.Checked ? 1 : 0;
            company.Update(mcompany);
            Binds();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex]["ID"].ToString());//GridView1.DataKeys[e.NewEditIndex]["ID"].ToString()
            if (!BLL.County.CountyInUse(id))
            {
                 mcompany = company.GetModel(id);
                 if (mcompany != null)
                {
                    mcompany.Status = -1;
                    company.Update(mcompany);
                    Binds();
                }
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "不能删除正在使用的企业", 1);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binds();
        }
        protected void But_add_Click(object sender, EventArgs e)
        {
            string cname = this.CName.Text.Trim();
            string filename = string.Empty;
            string logo = string.Empty;
            if (fuLogo.HasFile)
            {
                string dictionary = "/uploadimg/" + DateTime.Now.ToString("yyyyMM");
                if (!Directory.Exists(Server.MapPath(dictionary)))
                {
                    Directory.CreateDirectory(Server.MapPath(dictionary));
                }
                filename = dictionary + "/" + System.Guid.NewGuid().ToString("N") +
                                  System.IO.Path.GetExtension(fuLogo.FileName).ToLower();
                fuLogo.SaveAs(Server.MapPath(filename));
                logo = filename;  
            }
            if(!string.IsNullOrEmpty(cname))
            {
                mcompany.Name = cname;
                mcompany.LogoImg = !string.IsNullOrEmpty(logo) ? logo : "";
                mcompany.Status = 0;
                mcompany.IsTop = 0;
                mcompany.CID = Convert.ToInt32(ctype.SelectedValue);
                mcompany.AddTime = System.DateTime.Now;
                company.Add(mcompany);
                Binds();
            }
        }
        public void ReWrite(string url, string mesage, int time)
        {
            Response.Redirect("/admin/urlredirect.aspx?url=" + Server.UrlEncode(url) + "&m=" + Server.UrlEncode(mesage) + "&t=" + time);
            Response.End();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
               
                CheckBox chkrecommmend = (CheckBox)e.Row.Cells[3].FindControl("tuijian");
                if (rowView["IsTop"].ToString() == "1")
                {
                    chkrecommmend.Checked = true;
                }
                e.Row.Cells[2].Text = ctypes.CompanyName(Convert.ToInt32(rowView["CID"]));
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex]["ID"].ToString();
            Response.Redirect("UpdateCompany.aspx?id=" + id);
        }
    }
}