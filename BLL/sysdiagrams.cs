﻿/**  版本信息模板在安装目录下，可自行修改。
* sysdiagrams.cs
*
* 功 能： N/A
* 类 名： sysdiagrams
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/9 16:50:53   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ServiceWeb.Model;
namespace ServiceWeb.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class sysdiagrams
	{
		private readonly ServiceWeb.DAL.sysdiagrams dal=new ServiceWeb.DAL.sysdiagrams();
		public sysdiagrams()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string name,int principal_id,int diagram_id)
		{
			return dal.Exists(name,principal_id,diagram_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ServiceWeb.Model.sysdiagrams model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ServiceWeb.Model.sysdiagrams model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int diagram_id)
		{
			
			return dal.Delete(diagram_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string name,int principal_id,int diagram_id)
		{
			
			return dal.Delete(name,principal_id,diagram_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string diagram_idlist )
		{
			return dal.DeleteList(diagram_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ServiceWeb.Model.sysdiagrams GetModel(int diagram_id)
		{
			
			return dal.GetModel(diagram_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ServiceWeb.Model.sysdiagrams GetModelByCache(int diagram_id)
		{
			
			string CacheKey = "sysdiagramsModel-" + diagram_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(diagram_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ServiceWeb.Model.sysdiagrams)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ServiceWeb.Model.sysdiagrams> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ServiceWeb.Model.sysdiagrams> DataTableToList(DataTable dt)
		{
			List<ServiceWeb.Model.sysdiagrams> modelList = new List<ServiceWeb.Model.sysdiagrams>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ServiceWeb.Model.sysdiagrams model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

