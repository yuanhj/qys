/**  版本信息模板在安装目录下，可自行修改。
* VContactInfo.cs
*
* 功 能： N/A
* 类 名： VContactInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/18 10:21:11   N/A    初版
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
	/// VContactInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VContactInfo
	{
		public VContactInfo()
		{}
		#region Model
		private int _did;
		private string _contyname;
		private int _countyid;
		private string _departmentname;
		private string _mobile;
		private string _username;
		private int? _status;
		private int _cid;
		/// <summary>
		/// 
		/// </summary>
		public int did
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contyname
		{
			set{ _contyname=value;}
			get{return _contyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		#endregion Model

	}
}

