using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace ServiceWeb.Admin.Demand
{
    public partial class DemandProfile : System.Web.UI.Page
    {
        BLL.DemandProfile dpfile = new BLL.DemandProfile();
        Model.DemandProfile mdpfile = new Model.DemandProfile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binds();
            }

        }

        protected void But_Add_Click(object sender, EventArgs e)
        {
            mdpfile.DID = Convert.ToInt32(Username.SelectedValue);
            mdpfile.AddTime = System.DateTime.Now;
            mdpfile.ExpireTime = System.DateTime.Now;
            mdpfile.ReplyTime = System.DateTime.Now;
            mdpfile.Reply = this.reply.Text;
            mdpfile.Status = 0;
            mdpfile.IsReply = Convert.ToInt32(IsReply.SelectedValue);
            mdpfile.Requirement = this.xuqiu.Text;

            dpfile.Add(mdpfile);
            Binds();
            Response.Redirect("DemandProfileshow.aspx");
        }
        public void Binds()
        {
            SqlDataReader sdr = dpfile.DataDemands();
            while (sdr.Read())
            {
                Username.Items.Add(new ListItem(sdr["Subject"].ToString(), sdr["ID"].ToString()));
            }
            Username.Items.Insert(0, new ListItem("请选择...", "0"));
        }
      
    }
}