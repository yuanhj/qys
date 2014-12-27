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
    public partial class Demand : Web.BasePage
    {
        BLL.Demands demands = new BLL.Demands();
        Model.Demands mdemands = new Model.Demands();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader sdr = demands.DataUser();
            while (sdr.Read())
            {
                Username.Items.Add(new ListItem(sdr["UserName"].ToString(), sdr["ID"].ToString()));
            }
            Username.Items.Insert(0, new ListItem("请选择...", "0"));

            SqlDataReader dr = demands.DataReaderDemands();
            while (dr.Read())
            {
                DropType.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }
            DropType.Items.Insert(0, new ListItem("请选择...", "0"));

            SqlDataReader drs = demands.DataReader();
            while (drs.Read())
            {
                country.Items.Add(new ListItem(drs["Name"].ToString(), drs["ID"].ToString()));
            }
            country.Items.Insert(0, new ListItem("请选择...", "0"));

        }

        protected void But_Add_Click(object sender, EventArgs e)
        {
            mdemands.DTypeID =DropType.SelectedValue;
            mdemands.CountyID = Convert.ToInt32(country.SelectedValue);
            mdemands.UID = Convert.ToInt32(Username.SelectedValue);
            mdemands.Serial = "";
            mdemands.Subject = title.Text;
            mdemands.Contents = txteditor.InnerHtml;
            mdemands.AddTime = System.DateTime.Now;
            mdemands.IP = Request.UserHostName;
            mdemands.Status = 0;
            mdemands.DenyReason = "";
            mdemands.IsDistribution = 0;
            if (DropType.SelectedValue != "0" && country.SelectedValue != "0" && Username.SelectedValue != "0")
            {
                demands.Add(mdemands);
                Response.Redirect("DemandShow.aspx");
            }
            else
            {
                Response.Write("<script>alert('信息填写不完整!');</script>");
            }
        }
    }
}