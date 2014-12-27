using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace ServiceWeb.DAL
{
    public partial class Post
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
        /// 读取最新一条数据
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DatareaderTop(int cid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select top 1  * from Post where CountyID=" + cid + " and Subject not in('服务机构','服务政策','诉求办理流程') and  Status>-1 and IsTop=1 order by id desc");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        /// <summary>
        /// 读取最新一条数据
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListTop(string num,string tablename,int cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+num+" * ");
            strSql.Append(" FROM " + tablename + " where CountyID=" + cid + "  and Subject not in('服务机构','服务政策','诉求办理流程') and Status>-1 and IsTop=1 order by id desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
