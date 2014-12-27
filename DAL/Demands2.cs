using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    public partial class Demands
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from County where Status >-1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DatareaderDemandType()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from DemandType where status>-1");
            return DbHelperSQL.ExecuteReader(strsql.ToString(), null);
        }
        public SqlDataReader DataUser()
        {
            StringBuilder strsqls = new StringBuilder();
            strsqls.Append("select * from Member");
            return DbHelperSQL.ExecuteReader(strsqls.ToString(), null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStauts(ServiceWeb.Model.Demands model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Demands set ");
            strSql.Append("Status=@Status");
            strSql.Append(" where ID=@ID" );
            SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Status;
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
        /// 更新总结
        /// </summary>
        public bool UpdateResult(ServiceWeb.Model.Demands model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Demands set ");
            strSql.Append("Result=@Result,Status=2,");
            strSql.Append("DoneTime=getdate()");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Result", SqlDbType.NText),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Result;
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
        /// 更新拒绝原因
        /// </summary>
        public bool UpdateReason(ServiceWeb.Model.Demands model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Demands set ");
            strSql.Append("DenyReason=@DenyReason,Status=@status");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DenyReason", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.SmallInt),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DenyReason;
            parameters[1].Value = model.Status;
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
        /// 读取最新一条数据
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListTop(string num, string tablename, int cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + num + " * ");
            strSql.Append(" FROM " + tablename + " where  Status=1 order by id desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取平均办理时间
        /// </summary>
        /// <param name="countyID"></param>
        /// <returns></returns>
        public DataSet GetAvgDay(int countyID)
        {
            return DbHelperSQL.Query("select AVG(DateDiff(DAY,AddTime,DoneTime)) from Demands where Status=2  and CountyID="+countyID);
        }
        /// <summary>
        /// 获取办理时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet ResultDate(int id)
        {
            return DbHelperSQL.Query("select AVG(DateDiff(DAY,AddTime,DoneTime)) from Demands where Status=2  and ID=" + id);
        }

        public  DataSet ReturnDemands(string strsql)
        {
            return DbHelperSQL.Query(strsql);
        }

        public DataSet GetAvgDay2(string strsql)
        {
            return DbHelperSQL.Query(strsql);
        }

    }
}
