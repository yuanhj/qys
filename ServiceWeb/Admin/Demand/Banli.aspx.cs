using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.BLL;
using Demands = ServiceWeb.BLL.Demands;

namespace ServiceWeb.Admin.Demand
{
    public partial class Banli : Web.BasePage
    {
        BLL.DemandProfile dpfile = new BLL.DemandProfile();
        BLL.Department dpt = new BLL.Department();
        BLL.County county = new BLL.County();
        string DID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DID = Request.QueryString["DID"];
            Demands bDemands = new Demands();
            if (bDemands.IsDenyed(Convert.ToInt32(DID)))
            {
                ReWrite(Request.UrlReferrer.ToString(), "该项目已拒绝受理", 1);
            }
            Model.Demands demands = bDemands.GetModel(Convert.ToInt32(DID));
            if (bDemands.Status(demands.Status.ToString()) == DemandsStatus.办结完成)
            {
                ReWrite(Request.UrlReferrer.ToString(), "该项目已办结", 1);
            }
            if (bDemands.Status(demands.Status.ToString()) != DemandsStatus.已受理 && bDemands.Status(demands.Status.ToString()) != DemandsStatus.办理中)
            {
                ReWrite(Request.UrlReferrer.ToString(), "该项目未受理或状态异常", 1);
            }
            if (!IsPostBack)
            {
                Binds();
            }
        }
        public void Binds()
        {

            Repeater1.DataSource = dpfile.GetList("status > -1 and DID="+Convert.ToInt32(DID));
            Repeater1.DataBind();
        }

        #region 查看诉求办结信息
        public string GetDepartmentName(string pid)
        {
            if (!string.IsNullOrEmpty(pid))
            {
                return dpt.GetList("id = " + dpt.GetModel(Convert.ToInt32(pid)).ParentID).Tables[0].Rows[0]["DepartmentName"].ToString();
            }
            return "";
        }

        public string GetName(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID=" + id);
                string DepartmentName = ds.Tables[0].Rows[0]["UserName"].ToString();
                return DepartmentName;
            }
            return "未知";

        }
        public string GetMobile(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID=" + id);
                string DepartmentName = ds.Tables[0].Rows[0]["Mobile"].ToString();
                return DepartmentName;
            }
            return "未知";

        }
        public string GetCounty(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID=" + id);
                DataSet ds2 = county.GetList("ID=" + Convert.ToInt32(ds.Tables[0].Rows[0]["CountyID"]));
                return ds2.Tables[0].Rows[0]["Name"].ToString();
            }
            return "未知";
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string data = hfData.Value.Trim('#');
            string[] arrdata = data.Split('#');
            bool process = false;
            foreach (string item in arrdata)
            {
                string[] arritem = item.Split('|');
                if (arritem.Length == 3)
                {
                    string id = arritem[0];
                    string replay = arritem[1];
                    string raty = arritem[2];
                    Model.DemandProfile demandProfile = dpfile.GetModel(Convert.ToInt32(Web.Des.DecryptDes(id)));
                    demandProfile.Reply = replay;
                    demandProfile.IsReply = 1;
                    demandProfile.Evaluate = Convert.ToDecimal(0);
                    demandProfile.ReplyTime = DateTime.Now;
                    dpfile.Update(demandProfile);
                    if (!process && !string.IsNullOrEmpty(replay))
                    {
                        process = true;
                        BLL.Demands bllDemands = new Demands();
                        Model.Demands entity = bllDemands.GetModel(demandProfile.DID);
                        if (entity != null)
                        {
                            entity.Status = (int)BLL.DemandsStatus.办理中;
                            bllDemands.Update(entity);
                        }
                    }
                }
            }
            Binds();
        }
    }
}