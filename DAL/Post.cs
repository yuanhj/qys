﻿/**  版本信息模板在安装目录下，可自行修改。
* Post.cs
*
* 功 能： N/A
* 类 名： Post
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/25 17:00:40   N/A    初版
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
	/// 数据访问类:Post
	/// </summary>
	public partial class Post
	{
		public Post()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Post"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Post");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ServiceWeb.Model.Post model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Post(");
			strSql.Append("CountyID,Subject,TypeID,Message,AddTime,UpdateTime,Status,IsTop,DispalyOrder,IsSystem)");
			strSql.Append(" values (");
			strSql.Append("@CountyID,@Subject,@TypeID,@Message,@AddTime,@UpdateTime,@Status,@IsTop,@DispalyOrder,@IsSystem)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@Subject", SqlDbType.VarChar,150),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@Message", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@IsTop", SqlDbType.SmallInt,2),
					new SqlParameter("@DispalyOrder", SqlDbType.SmallInt,2),
					new SqlParameter("@IsSystem", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.CountyID;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.TypeID;
			parameters[3].Value = model.Message;
			parameters[4].Value = model.AddTime;
			parameters[5].Value = model.UpdateTime;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.IsTop;
			parameters[8].Value = model.DispalyOrder;
			parameters[9].Value = model.IsSystem;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(ServiceWeb.Model.Post model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Post set ");
			strSql.Append("CountyID=@CountyID,");
			strSql.Append("Subject=@Subject,");
			strSql.Append("TypeID=@TypeID,");
			strSql.Append("Message=@Message,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("Status=@Status,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("DispalyOrder=@DispalyOrder,");
			strSql.Append("IsSystem=@IsSystem");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@Subject", SqlDbType.VarChar,150),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@Message", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@IsTop", SqlDbType.SmallInt,2),
					new SqlParameter("@DispalyOrder", SqlDbType.SmallInt,2),
					new SqlParameter("@IsSystem", SqlDbType.SmallInt,2),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CountyID;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.TypeID;
			parameters[3].Value = model.Message;
			parameters[4].Value = model.AddTime;
			parameters[5].Value = model.UpdateTime;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.IsTop;
			parameters[8].Value = model.DispalyOrder;
			parameters[9].Value = model.IsSystem;
			parameters[10].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Post ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Post ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ServiceWeb.Model.Post GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CountyID,Subject,TypeID,Message,AddTime,UpdateTime,Status,IsTop,DispalyOrder,IsSystem from Post ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			ServiceWeb.Model.Post model=new ServiceWeb.Model.Post();
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
		public ServiceWeb.Model.Post DataRowToModel(DataRow row)
		{
			ServiceWeb.Model.Post model=new ServiceWeb.Model.Post();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["CountyID"]!=null && row["CountyID"].ToString()!="")
				{
					model.CountyID=int.Parse(row["CountyID"].ToString());
				}
				if(row["Subject"]!=null)
				{
					model.Subject=row["Subject"].ToString();
				}
				if(row["TypeID"]!=null && row["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(row["TypeID"].ToString());
				}
				if(row["Message"]!=null)
				{
					model.Message=row["Message"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					model.IsTop=int.Parse(row["IsTop"].ToString());
				}
				if(row["DispalyOrder"]!=null && row["DispalyOrder"].ToString()!="")
				{
					model.DispalyOrder=int.Parse(row["DispalyOrder"].ToString());
				}
				if(row["IsSystem"]!=null && row["IsSystem"].ToString()!="")
				{
					model.IsSystem=int.Parse(row["IsSystem"].ToString());
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
			strSql.Append("select ID,CountyID,Subject,TypeID,Message,AddTime,UpdateTime,Status,IsTop,DispalyOrder,IsSystem ");
			strSql.Append(" FROM Post ");
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
			strSql.Append(" ID,CountyID,Subject,TypeID,Message,AddTime,UpdateTime,Status,IsTop,DispalyOrder,IsSystem ");
			strSql.Append(" FROM Post ");
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
			strSql.Append("select count(1) FROM Post ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Post T ");
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
			parameters[0].Value = "Post";
			parameters[1].Value = "ID";
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

