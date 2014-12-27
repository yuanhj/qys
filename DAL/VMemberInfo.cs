/**  版本信息模板在安装目录下，可自行修改。
* VMemberInfo.cs
*
* 功 能： N/A
* 类 名： VMemberInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/17 17:07:30   N/A    初版
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
	/// 数据访问类:VMemberInfo
	/// </summary>
	public partial class VMemberInfo
	{
		public VMemberInfo()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ServiceWeb.Model.VMemberInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VMemberInfo(");
			strSql.Append("ID,UserName,PassWord,RegTime,RegIp,LastLoginTime,LastActiveTime,LastLoginIp,Status,Salt,AdminID,CountyID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,CLogo,Email,IsTop,Mobile)");
			strSql.Append(" values (");
			strSql.Append("@ID,@UserName,@PassWord,@RegTime,@RegIp,@LastLoginTime,@LastActiveTime,@LastLoginIp,@Status,@Salt,@AdminID,@CountyID,@CompanyName,@Summary,@LegalPerson,@Address,@Phone,@WebSite,@ContactName,@CLogo,@Email,@IsTop,@Mobile)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,60),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIp", SqlDbType.NVarChar,20),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastActiveTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIp", SqlDbType.NVarChar,20),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Salt", SqlDbType.NChar,8),
					new SqlParameter("@AdminID", SqlDbType.SmallInt,2),
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Summary", SqlDbType.VarChar,100),
					new SqlParameter("@LegalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,100),
					new SqlParameter("@ContactName", SqlDbType.VarChar,50),
					new SqlParameter("@CLogo", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,150),
					new SqlParameter("@IsTop", SqlDbType.SmallInt,2),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.PassWord;
			parameters[3].Value = model.RegTime;
			parameters[4].Value = model.RegIp;
			parameters[5].Value = model.LastLoginTime;
			parameters[6].Value = model.LastActiveTime;
			parameters[7].Value = model.LastLoginIp;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Salt;
			parameters[10].Value = model.AdminID;
			parameters[11].Value = model.CountyID;
			parameters[12].Value = model.CompanyName;
			parameters[13].Value = model.Summary;
			parameters[14].Value = model.LegalPerson;
			parameters[15].Value = model.Address;
			parameters[16].Value = model.Phone;
			parameters[17].Value = model.WebSite;
			parameters[18].Value = model.ContactName;
			parameters[19].Value = model.CLogo;
			parameters[20].Value = model.Email;
			parameters[21].Value = model.IsTop;
			parameters[22].Value = model.Mobile;

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
		public bool Update(ServiceWeb.Model.VMemberInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VMemberInfo set ");
			strSql.Append("ID=@ID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("RegTime=@RegTime,");
			strSql.Append("RegIp=@RegIp,");
			strSql.Append("LastLoginTime=@LastLoginTime,");
			strSql.Append("LastActiveTime=@LastActiveTime,");
			strSql.Append("LastLoginIp=@LastLoginIp,");
			strSql.Append("Status=@Status,");
			strSql.Append("Salt=@Salt,");
			strSql.Append("AdminID=@AdminID,");
			strSql.Append("CountyID=@CountyID,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("Summary=@Summary,");
			strSql.Append("LegalPerson=@LegalPerson,");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("WebSite=@WebSite,");
			strSql.Append("ContactName=@ContactName,");
			strSql.Append("CLogo=@CLogo,");
			strSql.Append("Email=@Email,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("Mobile=@Mobile");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,60),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIp", SqlDbType.NVarChar,20),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastActiveTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIp", SqlDbType.NVarChar,20),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Salt", SqlDbType.NChar,8),
					new SqlParameter("@AdminID", SqlDbType.SmallInt,2),
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Summary", SqlDbType.VarChar,100),
					new SqlParameter("@LegalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,100),
					new SqlParameter("@ContactName", SqlDbType.VarChar,50),
					new SqlParameter("@CLogo", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,150),
					new SqlParameter("@IsTop", SqlDbType.SmallInt,2),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.PassWord;
			parameters[3].Value = model.RegTime;
			parameters[4].Value = model.RegIp;
			parameters[5].Value = model.LastLoginTime;
			parameters[6].Value = model.LastActiveTime;
			parameters[7].Value = model.LastLoginIp;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Salt;
			parameters[10].Value = model.AdminID;
			parameters[11].Value = model.CountyID;
			parameters[12].Value = model.CompanyName;
			parameters[13].Value = model.Summary;
			parameters[14].Value = model.LegalPerson;
			parameters[15].Value = model.Address;
			parameters[16].Value = model.Phone;
			parameters[17].Value = model.WebSite;
			parameters[18].Value = model.ContactName;
			parameters[19].Value = model.CLogo;
			parameters[20].Value = model.Email;
			parameters[21].Value = model.IsTop;
			parameters[22].Value = model.Mobile;

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
			strSql.Append("delete from VMemberInfo ");
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
		public ServiceWeb.Model.VMemberInfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserName,PassWord,RegTime,RegIp,LastLoginTime,LastActiveTime,LastLoginIp,Status,Salt,AdminID,CountyID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,CLogo,Email,IsTop,Mobile from VMemberInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			ServiceWeb.Model.VMemberInfo model=new ServiceWeb.Model.VMemberInfo();
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
		public ServiceWeb.Model.VMemberInfo DataRowToModel(DataRow row)
		{
			ServiceWeb.Model.VMemberInfo model=new ServiceWeb.Model.VMemberInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["RegTime"]!=null && row["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(row["RegTime"].ToString());
				}
				if(row["RegIp"]!=null)
				{
					model.RegIp=row["RegIp"].ToString();
				}
				if(row["LastLoginTime"]!=null && row["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(row["LastLoginTime"].ToString());
				}
				if(row["LastActiveTime"]!=null && row["LastActiveTime"].ToString()!="")
				{
					model.LastActiveTime=DateTime.Parse(row["LastActiveTime"].ToString());
				}
				if(row["LastLoginIp"]!=null)
				{
					model.LastLoginIp=row["LastLoginIp"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Salt"]!=null)
				{
					model.Salt=row["Salt"].ToString();
				}
				if(row["AdminID"]!=null && row["AdminID"].ToString()!="")
				{
					model.AdminID=int.Parse(row["AdminID"].ToString());
				}
				if(row["CountyID"]!=null && row["CountyID"].ToString()!="")
				{
					model.CountyID=int.Parse(row["CountyID"].ToString());
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["Summary"]!=null)
				{
					model.Summary=row["Summary"].ToString();
				}
				if(row["LegalPerson"]!=null)
				{
					model.LegalPerson=row["LegalPerson"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["WebSite"]!=null)
				{
					model.WebSite=row["WebSite"].ToString();
				}
				if(row["ContactName"]!=null)
				{
					model.ContactName=row["ContactName"].ToString();
				}
				if(row["CLogo"]!=null)
				{
					model.CLogo=row["CLogo"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					model.IsTop=int.Parse(row["IsTop"].ToString());
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
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
			strSql.Append("select ID,UserName,PassWord,RegTime,RegIp,LastLoginTime,LastActiveTime,LastLoginIp,Status,Salt,AdminID,CountyID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,CLogo,Email,IsTop,Mobile ");
			strSql.Append(" FROM VMemberInfo ");
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
			strSql.Append(" ID,UserName,PassWord,RegTime,RegIp,LastLoginTime,LastActiveTime,LastLoginIp,Status,Salt,AdminID,CountyID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,CLogo,Email,IsTop,Mobile ");
			strSql.Append(" FROM VMemberInfo ");
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
			strSql.Append("select count(1) FROM VMemberInfo ");
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
			strSql.Append(")AS Row, T.*  from VMemberInfo T ");
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
			parameters[0].Value = "VMemberInfo";
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

