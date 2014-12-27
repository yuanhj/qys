using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;//Please add references

namespace ServiceWeb.DAL
{
    public partial class PageManager
    {
        /**/
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public static DataSet GetPage(string sql, int currentPage, int pagesize, out int recordcount)
        {
            
            return DbHelperSQL.GetPage(sql, currentPage, pagesize, out recordcount);
        }
    }
}
