using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServiceWeb.BLL;
using ServiceWeb.Model;

namespace ServiceWeb.Admin.Demand
{
    public partial class UpdateDemands : Web.BasePage
    {
        private string id = string.Empty;
        Model.Demands entity = null;
        BLL.Demands bllDemands = new BLL.Demands();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                PreDbind();
                Dbind();
            }
        }
        protected void But_Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string typeid = chlType.Items.Cast<ListItem>().Where(item => item.Selected).Aggregate(string.Empty, (current, item) => current + (item.Value + ","));
                entity = bllDemands.GetModel(Convert.ToInt32(id));
                entity.DTypeID = typeid.Trim(',');
                entity.Subject = tbSubject.Text.Trim();
                entity.Contents = tbMessage.Text.Trim();
                entity.Working = this.qingkuang.Text.Trim();
                bllDemands.Update(entity);
            }
            ReWrite(Request.Url.ToString(), "保存成功", 1);
        }

        private void Dbind()
        {
            if (!string.IsNullOrEmpty(id))
            {
                entity = bllDemands.GetModel(Convert.ToInt32(id));
                if (entity.Status.HasValue && entity.Status.Value == (int)BLL.DemandsStatus.办结完成)
                {
                    ReWrite(Request.UrlReferrer.ToString(), "该诉求已办理完结", 1);
                }
                litCounty.Text = (new BLL.County()).CountyNameFromID(entity.CountyID);
                litSerial.Text = entity.Serial;
                tbSubject.Text = entity.Subject;
                tbMessage.Text = entity.Contents;
                qingkuang.Text = entity.Working;
                litCompanyName.Text = (new BLL.UserProfile()).GetModelFromUID(entity.UID).CompanyName;
                litPostIp.Text = entity.IP;
                string[] arrtype = entity.DTypeID.Split(',');
                foreach (string type in arrtype)
                {
                    if (!string.IsNullOrEmpty(type))
                    {
                        try
                        {
                            chlType.Items.FindByValue(type).Selected = true;
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private void PreDbind()
        {
            BLL.DemandType bllDemandtype = new BLL.DemandType();
            DataSet ds = bllDemandtype.GetList("status > -1");
            chlType.DataSource = ds;
            chlType.DataTextField = "Name";
            chlType.DataValueField = "id";
            chlType.DataBind();
        }
    }
}