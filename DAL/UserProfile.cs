/**  版本信息模板在安装目录下，可自行修改。
* UserProfile.cs
*
* 功 能： N/A
* 类 名： UserProfile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/13 15:12:56   N/A    初版
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
	/// 数据访问类:UserProfile
	/// </summary>
	public partial class UserProfile
	{
		public UserProfile()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "UserProfile"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserProfile");
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
		public int Add(ServiceWeb.Model.UserProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserProfile(");
			strSql.Append("UID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,Mobile,CLogo,Email,IsTop)");
			strSql.Append(" values (");
			strSql.Append("@UID,@CompanyName,@Summary,@LegalPerson,@Address,@Phone,@WebSite,@ContactName,@Mobile,@CLogo,@Email,@IsTop)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Summary", SqlDbType.VarChar,100),
					new SqlParameter("@LegalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,100),
					new SqlParameter("@ContactName", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@CLogo", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,150),
					new SqlParameter("@IsTop", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.UID;
			parameters[1].Value = model.CompanyName;
			parameters[2].Value = model.Summary;
			parameters[3].Value = model.LegalPerson;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.WebSite;
			parameters[7].Value = model.ContactName;
			parameters[8].Value = model.Mobile;
			parameters[9].Value = model.CLogo;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.IsTop;

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
		public bool Update(ServiceWeb.Model.UserProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserProfile set ");
			strSql.Append("UID=@UID,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("Summary=@Summary,");
			strSql.Append("LegalPerson=@LegalPerson,");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("WebSite=@WebSite,");
			strSql.Append("ContactName=@ContactName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("CLogo=@CLogo,");
			strSql.Append("Email=@Email,");
			strSql.Append("IsTop=@IsTop");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Summary", SqlDbType.VarChar,100),
					new SqlParameter("@LegalPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,100),
					new SqlParameter("@ContactName", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@CLogo", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,150),
					new SqlParameter("@IsTop", SqlDbType.SmallInt,2),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.UID;
			parameters[1].Value = model.CompanyName;
			parameters[2].Value = model.Summary;
			parameters[3].Value = model.LegalPerson;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.WebSite;
			parameters[7].Value = model.ContactName;
			parameters[8].Value = model.Mobile;
			parameters[9].Value = model.CLogo;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.IsTop;
			parameters[12].Value = model.ID;

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
			strSql.Append("delete from UserProfile ");
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
			strSql.Append("delete from UserProfile ");
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
		public ServiceWeb.Model.UserProfile GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,Mobile,CLogo,Email,IsTop from UserProfile ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			ServiceWeb.Model.UserProfile model=new ServiceWeb.Model.UserProfile();
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
		public ServiceWeb.Model.UserProfile DataRowToModel(DataRow row)
		{
			ServiceWeb.Model.UserProfile model=new ServiceWeb.Model.UserProfile();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
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
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,Mobile,CLogo,Email,IsTop ");
			strSql.Append(" FROM UserProfile ");
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
			strSql.Append(" ID,UID,CompanyName,Summary,LegalPerson,Address,Phone,WebSite,ContactName,Mobile,CLogo,Email,IsTop ");
			strSql.Append(" FROM UserProfile ");
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
			strSql.Append("select count(1) FROM UserProfile ");
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
			strSql.Append(")AS Row, T.*  from UserProfile T ");
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
			parameters[0].Value = "UserProfile";
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

