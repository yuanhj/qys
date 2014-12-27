using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace ServiceWeb.DAL
{
    public partial class UserProfile
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County ");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        public SqlDataReader DataUser()
        {
            StringBuilder strsqls = new StringBuilder();
            strsqls.Append("select * from [member]");
            return DbHelperSQL.ExecuteReader(strsqls.ToString(), null);
        }
        public DataSet SelectTop()
        {
            StringBuilder strsqls = new StringBuilder();
            strsqls.Append("select top 15 * from [UserProfile] where IsTop=1 order by id desc");
            return DbHelperSQL.Query(strsqls.ToString(), null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateExpend(ServiceWeb.Model.UserProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserProfile set ");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("LegalPerson=@LegalPerson,");
            strSql.Append("Address=@Address,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@LegalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,150)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.CompanyName;
            parameters[2].Value = model.LegalPerson;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
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
