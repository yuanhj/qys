using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ServiceWeb.Admin.Shuqiushouli
{
    public partial class Refuse : Web.BasePage
    {
        BLL.Demands demands = new BLL.Demands();
        Model.Demands mdemands = new Model.Demands();
        BLL.DemandProfile dpf = new BLL.DemandProfile();
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                Dbind();
            }
        }

        private void Dbind()
        {
            if (id != "")
            {
                Model.Demands demandsentity = demands.GetModel(Convert.ToInt32(id));
                litSubject.Text = demandsentity.Subject;
                Reason.InnerText = demandsentity.DenyReason;
                if (demandsentity.Status.HasValue)
                {
                    if (demandsentity.Status.Value == (int)BLL.DemandsStatus.办结完成)
                    {
                        ReWrite(Request.UrlReferrer.ToString(), "该项目已办结完成", 1);
                    }
                    if (demandsentity.Status.Value == (int)BLL.DemandsStatus.办理中)
                    {
                        ReWrite(Request.UrlReferrer.ToString(), "该项目正在办理中", 1);
                    }
                }
                if (string.IsNullOrEmpty(demandsentity.DenyReason) && demandsentity.Status != (int)BLL.DemandsStatus.拒绝)
                {
                    chkDeney.Checked = true;
                }
                else
                {
                    chkDeney.Checked = demandsentity.Status == (int) BLL.DemandsStatus.拒绝;
                }
            }
        }

        protected void But_Reason_Click(object sender, EventArgs e)
        {
            mdemands.ID = Convert.ToInt32(id);
            mdemands.DenyReason = Reason.InnerText;
            if (!string.IsNullOrEmpty(mdemands.DenyReason))
            {
                mdemands.Status = chkDeney.Checked ? (int) BLL.DemandsStatus.拒绝 : (int) BLL.DemandsStatus.未受理;
                if (demands.UpdateReason(mdemands))
                {
                    Response.Redirect("../Demand/DemandShow.aspx");
                }
                Dbind();
            }
            else
            {
                jsb.JsHelper.Alert("请填写原因！");
            }
        }
    }
}