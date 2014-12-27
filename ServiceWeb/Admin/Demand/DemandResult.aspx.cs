using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.BLL;

namespace ServiceWeb.Admin.Demand
{
    public partial class DemandResult : Web.BasePage
    {
        BLL.Demands demands = new BLL.Demands();
        Model.Demands mdemands = new Model.Demands();
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id=Request.QueryString["id"];
            PreDbind();
            if (!IsPostBack)
            {
                Dbind();
            }
        }

        private void Dbind()
        {
            if (mdemands != null)
            {
                litSubject.Text = mdemands.Subject;
                tbMessage.Text = mdemands.Result.Trim();
            }
        }

        private void PreDbind()
        {
            Demands bDemands = new Demands();
            if (bDemands.IsDenyed(Convert.ToInt32(id)))
            {
                ReWrite(Request.UrlReferrer.ToString(), "该项目已拒绝受理", 1);
            }
            mdemands = demands.GetModel(Convert.ToInt32(id));
            if (mdemands != null)
            {
                if (demands.Status(mdemands.Status.ToString()) != DemandsStatus.办结完成)
                {
                    if (demands.Status(mdemands.Status.ToString()) != DemandsStatus.办理中)
                    {
                        ReWrite(Request.UrlReferrer.ToString(), "该项目未受理或未办理", 1);
                    }
                }
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "没有找到该项目", 1);
            }

            BLL.VDemandResult vDemandResult = new VDemandResult();
            DataSet ds = vDemandResult.GetList("did=" + id + " and profilestatus > -1");
            rptProfileItem.DataSource = ds;
            rptProfileItem.DataBind();
        }

        protected void But_Result_Click(object sender, EventArgs e)
        {
            mdemands.ID = Convert.ToInt32(id);
            mdemands.Result = tbMessage.Text.Trim();
            if (!string.IsNullOrEmpty(tbMessage.Text.Trim()) && demands.UpdateResult(mdemands))
            {
                ReWrite("/admin/demand/DemandShow.aspx", "办结完成", 1);
            }
            else
            {
                ReWrite(Request.UrlReferrer.ToString(), "请填写办结总结内容", 1);
            }
        }
    }
}