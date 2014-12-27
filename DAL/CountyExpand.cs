using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    /// <summary>
    /// 数据访问类:County
    /// </summary>
    public partial class County
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County where status>-1 or id=1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }

        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader2()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County where status>-1 and Parent=1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }

        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader3()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County where status>-1 and Parent=0 and id<>1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader4()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County where status>-1 and Parent=1 and id=1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
    }
}
