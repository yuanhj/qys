using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceWeb.BLL;
using Web;
using System.Data;

namespace ServiceWeb.Handler
{
    /// <summary>
    /// Demand 的摘要说明
    /// </summary>
    public class Demand : IHttpHandler
    {
        private BLL.DemandProfile dpf = new DemandProfile();
        private BLL.Demands demands = new Demands();
        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request.Form["ac"];
            Web.User user = new User();
            if (!string.IsNullOrEmpty(ac) && ac.Equals("raty"))
            {
                if (user.IsLogin)
                {
                    string id = context.Request.Form["id"];
                    string raty = context.Request.Form["raty"];
                    DataSet ds = dpf.GetList("id=" +Convert.ToInt32(Web.Des.DecryptDes(context.Server.UrlDecode(id))));
                    DataSet ds2 = demands.GetList("ID=" + Convert.ToInt32(ds.Tables[0].Rows[0]["DID"]));
                    if (user.UserEntity.ID.ToString() == ds2.Tables[0].Rows[0]["UID"].ToString())
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Evaluate"].ToString()) || ds.Tables[0].Rows[0]["Evaluate"].ToString()=="0")
                        {
                            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(raty))
                            {
                                context.Response.Write(
                                    DemandProfileRaty(Convert.ToInt32(Web.Des.DecryptDes(context.Server.UrlDecode(id))),
                                                      Convert.ToDecimal(raty)));
                            }
                        }
                        else
                        {

                            context.Response.Write("{result:-3,messge:'不能重复评价'}");
                        }

                    }
                    else
                    {
                        context.Response.Write("{result:-2,messge:'只能评价自己发布的诉求'}");
                    }
                }
                else 
                {
                    context.Response.Write("{result:-1,messge:'请先登录'}");
                }
            }
        }

        private string DemandProfileRaty(int id, decimal raty)
        {
            BLL.DemandProfile demandProfile = new DemandProfile();
            Model.DemandProfile entity = demandProfile.GetModel(id);
            if (entity != null && (!entity.Evaluate.HasValue || entity.Evaluate == 0))
            {
                entity.Evaluate = raty;
                demandProfile.Update(entity);
                return "{result:0}";
            }
            return "{result:-1}";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}