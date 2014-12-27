/**  版本信息模板在安装目录下，可自行修改。
* Department.cs
*
* 功 能： N/A
* 类 名： Department
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/9 16:50:52   N/A    初版
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
	/// Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Department
	{
		public Department()
		{}
		#region Model
		private int _id;
		private int _countyid;
		private string _departmentname;
		private int? _status=0;
		private int _parentid=0;
		private string _username;
		private string _mobile;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 区县ID
		/// </summary>
		public int CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
		/// 受理单位名称
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 区县ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 联系人姓名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		#endregion Model

	}
}

