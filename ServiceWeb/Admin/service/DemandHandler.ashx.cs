using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceWeb.DAL;
using ServiceWeb.Model;
using ServiceWeb.BLL;
using Web;
using System.Data;
using System.Text;

namespace ServiceWeb.Admin.service
{
    /// <summary>
    /// DemandHandler 的摘要说明
    /// </summary>
    public class DemandHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Web.User user = new User();
            if (!user.IsAdmin)
            {
                context.Response.Write("没有登录");
                context.Response.End();
            }
            string ac = context.Request.QueryString["ac"];
            if (ac == "country")
            {
                HttpContext.Current.Response.Write(CountryJson());
                HttpContext.Current.Response.End();
            }
            else if (ac == "deperment")
            {
                HttpContext.Current.Response.Write(DepartmentJson(HttpContext.Current.Request.QueryString["cid"]));
                HttpContext.Current.Response.End();
            }
            else if (ac == "contact")
            {
                HttpContext.Current.Response.Write(ContactJson(HttpContext.Current.Request.QueryString["did"]));
                HttpContext.Current.Response.End();
            }
            else if (ac == "contactinfo")
            {
                HttpContext.Current.Response.Write(ContactInfoJson(HttpContext.Current.Request.QueryString["pid"]));
                HttpContext.Current.Response.End();
            }
        }

        private string CountryJson()
        {
            BLL.County county = new BLL.County();
            DataSet ds = county.GetList("status=0");
            StringBuilder sbcountry = new StringBuilder("[");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sbcountry.Append("{id:" + row["id"] + ",name:'" + row["name"] + "'},");
            }
            return sbcountry.ToString().TrimEnd(',') + "]";
        }

        private string DepartmentJson(string cid)
        {
            if (!string.IsNullOrEmpty(cid))
            {
                BLL.Department department = new BLL.Department();
                DataSet ds = department.GetList("status = 0 and CountyID = " + cid + " and (username is null or username = '')");
                StringBuilder sb = new StringBuilder("[");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    sb.Append("{id:" + row["id"] + ",name:'" + row["DepartmentName"] + "'},");
                }
                return (sb.ToString().TrimEnd(',') + "]");
            }
            return "{}";
        }

        private string ContactJson(string cid)
        {
            if (!string.IsNullOrEmpty(cid))
            {
                BLL.Department department = new BLL.Department();
                DataSet ds = department.GetList("status = 0 and ParentID = " + cid + " and (username <> '')");
                StringBuilder sb = new StringBuilder("[");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    sb.Append("{id:" + row["id"] + ",name:'" + row["username"] + "',mobile:'" + row["mobile"] + "'},");
                }
                return sb.ToString().TrimEnd(',') + "]";
            }
            return "{}";
        }

        private string ContactInfoJson(string pid)
        {
            if (!string.IsNullOrEmpty(pid))
            {
                BLL.Department bDepartment = new BLL.Department();
                Model.Department contact, department;
                Model.County county;
                if (bDepartment.ContactInfo(Convert.ToInt32(pid), out  contact, out department, out county))
                {
                    return "{county:" + county.ID + ",department:" + department.ID + ", mobile:'" + contact.Mobile + "',departmentdata:" + DepartmentJson(county.ID.ToString()) + ", contactdata:" + ContactJson(contact.ParentID.ToString()) + "}";
                }
            }
            return "{}";
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