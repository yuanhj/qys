/**  版本信息模板在安装目录下，可自行修改。
* DemandType.cs
*
* 功 能： N/A
* 类 名： DemandType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/9 16:50:51   N/A    初版
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
	/// DemandType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DemandType
	{
		public DemandType()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _status;
		/// <summary>
		/// 类别ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类别标题
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

