using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    /// <summary>
    /// 数据访问类:ForgetPwdLog
    /// </summary>
    public partial class ForgetPwdLog
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Updates(ServiceWeb.Model.ForgetPwdLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ForgetPwdLog set ");
            strSql.Append("Status=@Status");
            strSql.Append(" where UID=@UID and Status=0");
            SqlParameter[] parameters = {
					new SqlParameter("@UID",SqlDbType.Int,4),
					new SqlParameter("@Status",SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Status;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
