using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    /// <summary>
    /// 数据访问类:CompanyType
    /// </summary>
    public partial class CompanyType
    {
        public SqlDataReader GetCompany()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from CompanyType where status>-1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }

        //public string CountyNameCID(int id)
        //{
        //    string county = string.Empty;
        //    Model.County mCounty = dal.GetModel(id);
        //    if (mCounty != null)
        //    {
        //        county = mCounty.Name;
        //    }
        //    return county;
        //}

    }
}
