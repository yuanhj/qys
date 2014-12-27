using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ServiceWeb.Admin.Demand
{
    /// <summary>
    /// banli 的摘要说明
    /// </summary>
    public class banli : IHttpHandler
    {
        BLL.Demands demands = new BLL.Demands();
        BLL.DemandProfile dpf = new BLL.DemandProfile();
        Model.Demands mdemands = new Model.Demands();
        Model.DemandProfile mdpf = new Model.DemandProfile();
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request.QueryString["id"];
            DataSet ds = dpf.GetList("DID=" + Convert.ToInt32(id) + " and IsReply=0");
            if (ds.Tables[0].Rows.Count<0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
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