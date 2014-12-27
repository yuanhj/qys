using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ServiceWeb.BLL;
using DemandProfile = ServiceWeb.Model.DemandProfile;

namespace ServiceWeb.Admin.Shuqiushouli
{
    public partial class Shouli : Web.BasePage
    {
        BLL.DemandProfile dpf = new BLL.DemandProfile();
        DAL.DemandProfile demandProfile = new DAL.DemandProfile();
        private string did = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            did = Request.QueryString["id"];
            if (string.IsNullOrEmpty(did))
            {
                Response.Write("err uri");
                Response.End();
            }
            Demands bDemands = new Demands();
            if(bDemands.IsDenyed(Convert.ToInt32(did)))
            {
                ReWrite(Request.UrlReferrer.ToString(), "该项目已拒绝受理", 1);
            }
            Model.Demands demands = bDemands.GetModel(Convert.ToInt32(did));
            if (bDemands.Status(demands.Status.ToString()) == DemandsStatus.办结完成)
            {
                ReWrite(Request.UrlReferrer.ToString(), "该项目已办结", 1);
            }
            if (!IsPostBack)
            {
                Dbind();
            }
        }

        private void Dbind()
        {
            if (!string.IsNullOrEmpty(did))
            {
                DataSet ds = dpf.GetList("status > -1 and did = " +did);
                rptList.DataSource = ds;
                rptList.DataBind();
            }
        }

        protected void But_Save_Click(object sender, EventArgs e)
        {
            bool allow = false;
            bool edit = false;
            if (string.IsNullOrEmpty(did))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "errparm", "<script>alert('错误的url参数');</script>");
                return;
            }
            if (string.IsNullOrEmpty(did))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "errpdid", "<script>alert('错误的url参数');</script>");
                return;
            }
            string data = hfData.Value;
            if (string.IsNullOrEmpty(data))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "errdata", "<script>alert('错误的参数');</script>");
                return;
            }
            string[] arrdata = data.Trim('#').Split('#');
            if (arrdata.Length > 0)
            {
                foreach (string item in arrdata)
                {
                    string[] arritem = item.Split('|');
                    if (arritem.Length == 4)
                    {
                        string id = arritem[0];
                        string contact = arritem[1];
                        string message = Server.HtmlDecode(arritem[2]).Trim();
                        string expire = arritem[3];
                        if (id == "0")
                        {
                            //添加
                            if (!string.IsNullOrEmpty(contact) && !string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(expire))
                            {
                                Model.DemandProfile profile = new DemandProfile();
                                profile.AddTime = DateTime.Now;
                                profile.DID = Convert.ToInt32(did);
                                profile.ExpireTime = Convert.ToDateTime(expire);
                                profile.IsReply = 0;
                                profile.PID = Convert.ToInt32(contact);
                                profile.Requirement = message;
                                demandProfile.Add(profile);
                                if (!allow)
                                {
                                    allow = true;
                                }
                            }
                        }
                        else
                        {
                            Model.DemandProfile profiletmp = dpf.GetModel(Convert.ToInt32(Web.Des.DecryptDes(id)));
                            if (!string.IsNullOrEmpty(contact) && !string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(expire))
                            {
                                //修改
                                profiletmp.ExpireTime = Convert.ToDateTime(expire);
                                profiletmp.PID = Convert.ToInt32(contact);
                                profiletmp.Requirement = message;
                                profiletmp.Status = profiletmp.Status;
                            }
                            else
                            {
                                //删除
                                profiletmp.Status = (int)BLL.DemandsStatus.删除;
                            }
                            demandProfile.Update(profiletmp);
                            if (!edit)
                            {
                                edit = true;
                            }
                        }
                    }
                }
                if (allow)
                {
                    //更新受理状态
                    BLL.Demands bllDemands = new Demands();
                    Model.Demands mDemands = bllDemands.GetModel(Convert.ToInt32(did));
                    mDemands.Status = (int) BLL.DemandsStatus.已受理;
                    bllDemands.Update(mDemands);
                }
            }
            if (!allow && !edit)
            {
                ReWrite(Request.UrlReferrer.ToString(), "请填写受理信息", 1);
            }
            ReWrite("/admin/demand/banli.aspx?did=" + did, "保存成功", 1);
        }
    }
}