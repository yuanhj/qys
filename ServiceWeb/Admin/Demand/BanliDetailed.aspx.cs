using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ServiceWeb.Admin.Demand
{
    public partial class BanliDetailed : System.Web.UI.Page
    {
        BLL.DemandProfile dpfile = new BLL.DemandProfile();
        BLL.Department dpt = new BLL.Department();
        BLL.County county = new BLL.County();
        BLL.Demands demands = new BLL.Demands();
        Model.DemandProfile mdpf = new Model.DemandProfile();
        Model.Demands mdemands = new Model.Demands();
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                DataSet ds = dpfile.GetList("ID=" + Convert.ToInt32(id));
                this.xuqiu.Text = ds.Tables[0].Rows[0]["Requirement"].ToString();
                this.content.Text = ds.Tables[0].Rows[0]["Reply"].ToString();
            }
        }
        protected void But_Sav_Click(object sender, EventArgs e)
        {
            DataSet ds = dpfile.GetList("ID=" + Convert.ToInt32(Request.QueryString["id"]));
            mdpf.ID =Convert.ToInt32( Request.QueryString["id"]);
            mdpf.Reply = this.content.Text;
            mdpf.IsReply = 1;
            dpfile.UpdateContent(mdpf);
            Response.Redirect("Banli.aspx?DID="+Convert.ToInt32(ds.Tables[0].Rows[0]["DID"]));
        }
    }
}