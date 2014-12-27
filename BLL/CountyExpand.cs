using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using ServiceWeb.Model;
using System.Data;
using System.Data.SqlClient;
namespace ServiceWeb.BLL
{
    /// <summary>
    /// 数据访问类:County
    /// </summary>
    public partial class County
    {
        public SqlDataReader DataRead()
        {
            return dal.Datareader();
        }

        public SqlDataReader DataRead2()
        {
            return dal.Datareader2();
        }
        public  SqlDataReader DataReader3()
        {
            return dal.Datareader3();
        }
        public SqlDataReader DataReader4()
        {
            return dal.Datareader4();
        }
        public string CountyNameFromID(int id)
        {
            string county = string.Empty;
            Model.County mCounty = dal.GetModel(id);
            if (mCounty != null)
            {
                county = mCounty.Name;
            }
            return county;
        }

        public static bool NameInUse(int id, string name)
        {
            BLL.County dal = new County();
            DataSet ds = dal.GetList("status > -1 and id <>" + id + " and name = '" + name + "'");
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool CountyInUse(int id)
        {
            BLL.Department blldepartment = new Department();
            DataSet ds = blldepartment.GetList("status > -1 and countyid =" + id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            BLL.Demands blldemands = new Demands();
            ds = blldemands.GetList("status > -1 and countyid = " + id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
