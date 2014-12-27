/**  版本信息模板在安装目录下，可自行修改。
* VDemandsProfile.cs
*
* 功 能： N/A
* 类 名： VDemandsProfile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/31 10:15:54   N/A    初版
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
	/// 数据访问类:VDemandsProfile
	/// </summary>
	public partial class VDemandsProfile
	{
		public VDemandsProfile()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ServiceWeb.Model.VDemandsProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VDemandsProfile(");
			strSql.Append("PID,ID,DTypeID,CountyID,UID,Serial,Subject,Contents,AddTime,IP,Status,DenyReason,IsDistribution,Result,DoneTime,ProfileID,ProfileAddtime,ExpireTime,ReplyTime,Reply,ProfileStatus,IsReply,Requirement,Evaluate,UserName,Mobile,ParentID,DepartmentName,DepartmentCID)");
			strSql.Append(" values (");
			strSql.Append("@PID,@ID,@DTypeID,@CountyID,@UID,@Serial,@Subject,@Contents,@AddTime,@IP,@Status,@DenyReason,@IsDistribution,@Result,@DoneTime,@ProfileID,@ProfileAddtime,@ExpireTime,@ReplyTime,@Reply,@ProfileStatus,@IsReply,@Requirement,@Evaluate,@UserName,@Mobile,@ParentID,@DepartmentName,@DepartmentCID)");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DTypeID", SqlDbType.VarChar,100),
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Serial", SqlDbType.VarChar,50),
					new SqlParameter("@Subject", SqlDbType.NVarChar,250),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.VarChar,20),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@DenyReason", SqlDbType.VarChar,250),
					new SqlParameter("@IsDistribution", SqlDbType.SmallInt,2),
					new SqlParameter("@Result", SqlDbType.NChar,500),
					new SqlParameter("@DoneTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ProfileID", SqlDbType.Int,4),
					new SqlParameter("@ProfileAddtime", SqlDbType.DateTime),
					new SqlParameter("@ExpireTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ProfileStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@IsReply", SqlDbType.SmallInt,2),
					new SqlParameter("@Requirement", SqlDbType.NText),
					new SqlParameter("@Evaluate", SqlDbType.Float,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartmentCID", SqlDbType.Int,4)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.ID;
			parameters[2].Value = model.DTypeID;
			parameters[3].Value = model.CountyID;
			parameters[4].Value = model.UID;
			parameters[5].Value = model.Serial;
			parameters[6].Value = model.Subject;
			parameters[7].Value = model.Contents;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.IP;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.DenyReason;
			parameters[12].Value = model.IsDistribution;
			parameters[13].Value = model.Result;
			parameters[14].Value = model.DoneTime;
			parameters[15].Value = model.ProfileID;
			parameters[16].Value = model.ProfileAddtime;
			parameters[17].Value = model.ExpireTime;
			parameters[18].Value = model.ReplyTime;
			parameters[19].Value = model.Reply;
			parameters[20].Value = model.ProfileStatus;
			parameters[21].Value = model.IsReply;
			parameters[22].Value = model.Requirement;
			parameters[23].Value = model.Evaluate;
			parameters[24].Value = model.UserName;
			parameters[25].Value = model.Mobile;
			parameters[26].Value = model.ParentID;
			parameters[27].Value = model.DepartmentName;
			parameters[28].Value = model.DepartmentCID;

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
		public bool Update(ServiceWeb.Model.VDemandsProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VDemandsProfile set ");
			strSql.Append("PID=@PID,");
			strSql.Append("ID=@ID,");
			strSql.Append("DTypeID=@DTypeID,");
			strSql.Append("CountyID=@CountyID,");
			strSql.Append("UID=@UID,");
			strSql.Append("Serial=@Serial,");
			strSql.Append("Subject=@Subject,");
			strSql.Append("Contents=@Contents,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("IP=@IP,");
			strSql.Append("Status=@Status,");
			strSql.Append("DenyReason=@DenyReason,");
			strSql.Append("IsDistribution=@IsDistribution,");
			strSql.Append("Result=@Result,");
			strSql.Append("DoneTime=@DoneTime,");
			strSql.Append("ProfileID=@ProfileID,");
			strSql.Append("ProfileAddtime=@ProfileAddtime,");
			strSql.Append("ExpireTime=@ExpireTime,");
			strSql.Append("ReplyTime=@ReplyTime,");
			strSql.Append("Reply=@Reply,");
			strSql.Append("ProfileStatus=@ProfileStatus,");
			strSql.Append("IsReply=@IsReply,");
			strSql.Append("Requirement=@Requirement,");
			strSql.Append("Evaluate=@Evaluate,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("DepartmentName=@DepartmentName,");
			strSql.Append("DepartmentCID=@DepartmentCID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DTypeID", SqlDbType.VarChar,100),
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Serial", SqlDbType.VarChar,50),
					new SqlParameter("@Subject", SqlDbType.NVarChar,250),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.VarChar,20),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@DenyReason", SqlDbType.VarChar,250),
					new SqlParameter("@IsDistribution", SqlDbType.SmallInt,2),
					new SqlParameter("@Result", SqlDbType.NChar,500),
					new SqlParameter("@DoneTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ProfileID", SqlDbType.Int,4),
					new SqlParameter("@ProfileAddtime", SqlDbType.DateTime),
					new SqlParameter("@ExpireTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ProfileStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@IsReply", SqlDbType.SmallInt,2),
					new SqlParameter("@Requirement", SqlDbType.NText),
					new SqlParameter("@Evaluate", SqlDbType.Float,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartmentCID", SqlDbType.Int,4)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.ID;
			parameters[2].Value = model.DTypeID;
			parameters[3].Value = model.CountyID;
			parameters[4].Value = model.UID;
			parameters[5].Value = model.Serial;
			parameters[6].Value = model.Subject;
			parameters[7].Value = model.Contents;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.IP;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.DenyReason;
			parameters[12].Value = model.IsDistribution;
			parameters[13].Value = model.Result;
			parameters[14].Value = model.DoneTime;
			parameters[15].Value = model.ProfileID;
			parameters[16].Value = model.ProfileAddtime;
			parameters[17].Value = model.ExpireTime;
			parameters[18].Value = model.ReplyTime;
			parameters[19].Value = model.Reply;
			parameters[20].Value = model.ProfileStatus;
			parameters[21].Value = model.IsReply;
			parameters[22].Value = model.Requirement;
			parameters[23].Value = model.Evaluate;
			parameters[24].Value = model.UserName;
			parameters[25].Value = model.Mobile;
			parameters[26].Value = model.ParentID;
			parameters[27].Value = model.DepartmentName;
			parameters[28].Value = model.DepartmentCID;

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
			strSql.Append("delete from VDemandsProfile ");
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
		public ServiceWeb.Model.VDemandsProfile GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PID,ID,DTypeID,CountyID,UID,Serial,Subject,Contents,AddTime,IP,Status,DenyReason,IsDistribution,Result,DoneTime,ProfileID,ProfileAddtime,ExpireTime,ReplyTime,Reply,ProfileStatus,IsReply,Requirement,Evaluate,UserName,Mobile,ParentID,DepartmentName,DepartmentCID from VDemandsProfile ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			ServiceWeb.Model.VDemandsProfile model=new ServiceWeb.Model.VDemandsProfile();
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
		public ServiceWeb.Model.VDemandsProfile DataRowToModel(DataRow row)
		{
			ServiceWeb.Model.VDemandsProfile model=new ServiceWeb.Model.VDemandsProfile();
			if (row != null)
			{
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["DTypeID"]!=null)
				{
					model.DTypeID=row["DTypeID"].ToString();
				}
				if(row["CountyID"]!=null && row["CountyID"].ToString()!="")
				{
					model.CountyID=int.Parse(row["CountyID"].ToString());
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["Serial"]!=null)
				{
					model.Serial=row["Serial"].ToString();
				}
				if(row["Subject"]!=null)
				{
					model.Subject=row["Subject"].ToString();
				}
				if(row["Contents"]!=null)
				{
					model.Contents=row["Contents"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["DenyReason"]!=null)
				{
					model.DenyReason=row["DenyReason"].ToString();
				}
				if(row["IsDistribution"]!=null && row["IsDistribution"].ToString()!="")
				{
					model.IsDistribution=int.Parse(row["IsDistribution"].ToString());
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["DoneTime"]!=null && row["DoneTime"].ToString()!="")
				{
					model.DoneTime=DateTime.Parse(row["DoneTime"].ToString());
				}
				if(row["ProfileID"]!=null && row["ProfileID"].ToString()!="")
				{
					model.ProfileID=int.Parse(row["ProfileID"].ToString());
				}
				if(row["ProfileAddtime"]!=null && row["ProfileAddtime"].ToString()!="")
				{
					model.ProfileAddtime=DateTime.Parse(row["ProfileAddtime"].ToString());
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
				if(row["IsReply"]!=null && row["IsReply"].ToString()!="")
				{
					model.IsReply=int.Parse(row["IsReply"].ToString());
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
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["DepartmentCID"]!=null && row["DepartmentCID"].ToString()!="")
				{
					model.DepartmentCID=int.Parse(row["DepartmentCID"].ToString());
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
			strSql.Append("select PID,ID,DTypeID,CountyID,UID,Serial,Subject,Contents,AddTime,IP,Status,DenyReason,IsDistribution,Result,DoneTime,ProfileID,ProfileAddtime,ExpireTime,ReplyTime,Reply,ProfileStatus,IsReply,Requirement,Evaluate,UserName,Mobile,ParentID,DepartmentName,DepartmentCID ");
			strSql.Append(" FROM VDemandsProfile ");
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
			strSql.Append(" PID,ID,DTypeID,CountyID,UID,Serial,Subject,Contents,AddTime,IP,Status,DenyReason,IsDistribution,Result,DoneTime,ProfileID,ProfileAddtime,ExpireTime,ReplyTime,Reply,ProfileStatus,IsReply,Requirement,Evaluate,UserName,Mobile,ParentID,DepartmentName,DepartmentCID ");
			strSql.Append(" FROM VDemandsProfile ");
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
			strSql.Append("select count(1) FROM VDemandsProfile ");
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
			strSql.Append(")AS Row, T.*  from VDemandsProfile T ");
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
			parameters[0].Value = "VDemandsProfile";
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

