/**  版本信息模板在安装目录下，可自行修改。
* VDemandResult.cs
*
* 功 能： N/A
* 类 名： VDemandResult
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/31 10:42:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
	/// <summary>
	/// 数据访问类:VDemandResult
	/// </summary>
	public partial class VDemandResult
	{
		public VDemandResult()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ServiceWeb.Model.VDemandResult model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VDemandResult(");
			strSql.Append("ID,Subject,Status,AddTime,ExpireTime,ReplyTime,Reply,ProfileStatus,Requirement,Evaluate,UserName,Mobile,DepartmentName,DID,IsReply,Name)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Subject,@Status,@AddTime,@ExpireTime,@ReplyTime,@Reply,@ProfileStatus,@Requirement,@Evaluate,@UserName,@Mobile,@DepartmentName,@DID,@IsReply,@Name)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Subject", SqlDbType.NVarChar,250),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ExpireTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ProfileStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@Requirement", SqlDbType.NText),
					new SqlParameter("@Evaluate", SqlDbType.Float,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@DID", SqlDbType.Int,4),
					new SqlParameter("@IsReply", SqlDbType.SmallInt,2),
					new SqlParameter("@Name", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.ExpireTime;
			parameters[5].Value = model.ReplyTime;
			parameters[6].Value = model.Reply;
			parameters[7].Value = model.ProfileStatus;
			parameters[8].Value = model.Requirement;
			parameters[9].Value = model.Evaluate;
			parameters[10].Value = model.UserName;
			parameters[11].Value = model.Mobile;
			parameters[12].Value = model.DepartmentName;
			parameters[13].Value = model.DID;
			parameters[14].Value = model.IsReply;
			parameters[15].Value = model.Name;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(ServiceWeb.Model.VDemandResult model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VDemandResult set ");
			strSql.Append("ID=@ID,");
			strSql.Append("Subject=@Subject,");
			strSql.Append("Status=@Status,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("ExpireTime=@ExpireTime,");
			strSql.Append("ReplyTime=@ReplyTime,");
			strSql.Append("Reply=@Reply,");
			strSql.Append("ProfileStatus=@ProfileStatus,");
			strSql.Append("Requirement=@Requirement,");
			strSql.Append("Evaluate=@Evaluate,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("DepartmentName=@DepartmentName,");
			strSql.Append("DID=@DID,");
			strSql.Append("IsReply=@IsReply,");
			strSql.Append("Name=@Name");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Subject", SqlDbType.NVarChar,250),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ExpireTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ProfileStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@Requirement", SqlDbType.NText),
					new SqlParameter("@Evaluate", SqlDbType.Float,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@DID", SqlDbType.Int,4),
					new SqlParameter("@IsReply", SqlDbType.SmallInt,2),
					new SqlParameter("@Name", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.ExpireTime;
			parameters[5].Value = model.ReplyTime;
			parameters[6].Value = model.Reply;
			parameters[7].Value = model.ProfileStatus;
			parameters[8].Value = model.Requirement;
			parameters[9].Value = model.Evaluate;
			parameters[10].Value = model.UserName;
			parameters[11].Value = model.Mobile;
			parameters[12].Value = model.DepartmentName;
			parameters[13].Value = model.DID;
			parameters[14].Value = model.IsReply;
			parameters[15].Value = model.Name;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VDemandResult ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 得到一个对象实体
		/// </summary>
		public ServiceWeb.Model.VDemandResult GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Subject,Status,AddTime,ExpireTime,ReplyTime,Reply,ProfileStatus,Requirement,Evaluate,UserName,Mobile,DepartmentName,DID,IsReply,Name from VDemandResult ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			ServiceWeb.Model.VDemandResult model=new ServiceWeb.Model.VDemandResult();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ServiceWeb.Model.VDemandResult DataRowToModel(DataRow row)
		{
			ServiceWeb.Model.VDemandResult model=new ServiceWeb.Model.VDemandResult();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Subject"]!=null)
				{
					model.Subject=row["Subject"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["ExpireTime"]!=null && row["ExpireTime"].ToString()!="")
				{
					model.ExpireTime=DateTime.Parse(row["ExpireTime"].ToString());
				}
				if(row["ReplyTime"]!=null && row["ReplyTime"].ToString()!="")
				{
					model.ReplyTime=DateTime.Parse(row["ReplyTime"].ToString());
				}
				if(row["Reply"]!=null)
				{
					model.Reply=row["Reply"].ToString();
				}
				if(row["ProfileStatus"]!=null && row["ProfileStatus"].ToString()!="")
				{
					model.ProfileStatus=int.Parse(row["ProfileStatus"].ToString());
				}
				if(row["Requirement"]!=null)
				{
					model.Requirement=row["Requirement"].ToString();
				}
				if(row["Evaluate"]!=null && row["Evaluate"].ToString()!="")
				{
					model.Evaluate=decimal.Parse(row["Evaluate"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["DID"]!=null && row["DID"].ToString()!="")
				{
					model.DID=int.Parse(row["DID"].ToString());
				}
				if(row["IsReply"]!=null && row["IsReply"].ToString()!="")
				{
					model.IsReply=int.Parse(row["IsReply"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Subject,Status,AddTime,ExpireTime,ReplyTime,Reply,ProfileStatus,Requirement,Evaluate,UserName,Mobile,DepartmentName,DID,IsReply,Name ");
			strSql.Append(" FROM VDemandResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Subject,Status,AddTime,ExpireTime,ReplyTime,Reply,ProfileStatus,Requirement,Evaluate,UserName,Mobile,DepartmentName,DID,IsReply,Name ");
			strSql.Append(" FROM VDemandResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM VDemandResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from VDemandResult T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "VDemandResult";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

