using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace ServiceWeb.DAL
{
    public partial class Department
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County where Status>-1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DatareaderDpt()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from Department where Status=0 and DepartmentName<>''");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DatareaderUser(string id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select ID,UserName,Mobile,ParentID from Department where Status=0 and ParentID=" + Convert.ToInt32(id));
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }

        public  DataSet SelectID(int cid)
        {
            StringBuilder strsql=new StringBuilder();
            strsql.Append("select top 1 * from department where CountyID=" + cid + " and ParentID<>0");
            return DbHelperSQL.Query(strsql.ToString());
        }

    }
}
