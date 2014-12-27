using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    public partial class DemandProfile
    {
        public SqlDataReader DataDemands()
        {
            StringBuilder strsqls = new StringBuilder();
            strsqls.Append("select * from Demands");
            return DbHelperSQL.ExecuteReader(strsqls.ToString(), null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePid(ServiceWeb.Model.DemandProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DemandProfile set ");
            strSql.Append("PID=@PID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PID;
            parameters[1].Value = model.ID;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateContent(ServiceWeb.Model.DemandProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DemandProfile set ");
            strSql.Append("Reply=@Reply,");
            strSql.Append("IsReply=@IsReply");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Reply", SqlDbType.NText),
                    new SqlParameter("@IsReply", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Reply;
            parameters[1].Value = model.IsReply;
            parameters[2].Value = model.ID;

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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList2(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Demands,DemandProfile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet AvgEvaluate(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AVG(Evaluate) ");
            strSql.Append(" from dbo.DemandProfile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取平均满意度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet AvgEvaluate(int id)
        {
            return DbHelperSQL.Query("select AVG(Evaluate) from DemandProfile where DID=" + id);
        }
        /// <summary>
        /// 获取县区平均满意度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet AvgCountyEvaluate(int countyID)
        {
            return DbHelperSQL.Query("select AVG(Evaluate) from Demands as  a inner join DemandProfile as b on a.ID=b.DID where CountyID="+countyID);
        }
    }
}
