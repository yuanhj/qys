﻿/**  版本信息模板在安装目录下，可自行修改。
* CompanyType.cs
*
* 功 能： N/A
* 类 名： CompanyType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/9 12:56:51   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ServiceWeb.Model
{
	/// <summary>
	/// CompanyType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CompanyType
	{
		public CompanyType()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _status=0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

