/**  版本信息模板在安装目录下，可自行修改。
* County.cs
*
* 功 能： N/A
* 类 名： County
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/25 17:39:28   N/A    初版
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
	/// County:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class County
	{
		public County()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _status;
		private int _parent;
		private int? _paixu=0;
		private int? _recommend=0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 显示名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 父ID，0为一级区域
		/// </summary>
		public int Parent
		{
			set{ _parent=value;}
			get{return _parent;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? Paixu
		{
			set{ _paixu=value;}
			get{return _paixu;}
		}
		/// <summary>
		/// 推荐 1：是 0：否
		/// </summary>
		public int? Recommend
		{
			set{ _recommend=value;}
			get{return _recommend;}
		}
		#endregion Model

	}
}

