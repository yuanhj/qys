using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    public partial class DemandType
    {
        /// <summary>
        /// 逐行读取诉求类型
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DatareaderDType()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from DemandType where Status=0");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
    }
}
