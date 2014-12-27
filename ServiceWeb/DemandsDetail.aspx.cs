using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.BLL;

namespace ServiceWeb
{
    public partial class DemandsDetail : System.Web.UI.Page
    {
        BLL.Demands demands = new BLL.Demands();
        BLL.DemandProfile dpf = new BLL.DemandProfile();
        BLL.Member user = new BLL.Member();
        private BLL.DemandType dtype = new DemandType();
        BLL.Department dpt = new BLL.Department();
        BLL.UserProfile userpfile = new BLL.UserProfile();
        BLL.County county = new BLL.County();
        public int Nums = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            if (id.ToString() != "")
            {
                Binds(id);
            }
        }
        public void Binds(int id)
        {
            DataSet ds = demands.GetList(" status > -1 and ID=" + id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.Bind_Demands.DataSource = ds;
                Bind_Demands.DataBind();

                Rpt_DemandProfile.DataSource = dpf.GetList("status > -1 and DID=" + Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]));
                Rpt_DemandProfile.DataBind();

                DemandsOver.DataSource = demands.GetList("ID=" + id);
                DemandsOver.DataBind();
            }
        }
        public string Companyname(string uid)
        {
            if (uid != "")
            {
                return userpfile.GetList("UID=" + Convert.ToInt32(uid)).Tables[0].Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "";
            }
        }
        public string SelectNumaber(string id)
        {
            if (id != "")
            {
                return demands.GetList("ID=" + Convert.ToInt32(id)).Tables[0].Rows[0]["Serial"].ToString();
            }
            else
            {
                return "";
            }
        }
        public  string SelectType(string str)
        {
            string strs = "";
            if(!string.IsNullOrEmpty(str))
            {
                string[] strarry = str.Split(',');
                
                for (int i = 0; i < strarry.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strarry[i]))
                    {
                        DataSet ds = dtype.GetList("ID=" + Convert.ToInt32(strarry[i]));
                        strs += ds.Tables[0].Rows[0]["Name"] + ",";
                    }
                }
                return strs;
            }
            else
            {

                return "";
            }
        }

        public string SelectStatus(string status)
        {
            switch (status)
            {
                case "0": return "未受理";
                    break;
                case "1": return "已受理";
                    break;
                case "2": return "办结完成";
                    break;
                case "3": return "拒绝办理";
                    break;
                case "4": return "办理中";
                    break;
                default: return "";
                    break;
            }
        }
        public string RequeirDay(string a,string b)
        {
            DateTime DateTime1,
            DateTime2 = Convert.ToDateTime(b);
            DateTime1 = Convert.ToDateTime(a);
            //设置要求的减的时间 
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            //显示时间             
            dateDiff = ts.Days.ToString() + "天";
            return dateDiff;
                            
        }
       /// <summary>
       /// 办理总结满意度
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public string Manyi(string id)
        {
            DataSet ds = dpf.AvgEvaluate("DID=" + Convert.ToInt32(id));
            return ds.Tables[0].Rows[0][0].ToString();
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
        

    }
}