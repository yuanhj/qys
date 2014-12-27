/**  版本信息模板在安装目录下，可自行修改。
* VDemandResult.cs
*
* 功 能： N/A
* 类 名： VDemandResult
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/31 10:42:30   N/A    初版
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
	/// VDemandResult:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VDemandResult
	{
		public VDemandResult()
		{}
		#region Model
		private int _id;
		private string _subject;
		private int? _status;
		private DateTime? _addtime;
		private DateTime _expiretime;
		private DateTime? _replytime;
		private string _reply;
		private int? _profilestatus;
		private string _requirement;
		private decimal? _evaluate;
		private string _username;
		private string _mobile;
		private string _departmentname;
		private int _did;
		private int? _isreply;
		private string _name;
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
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
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
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ExpireTime
		{
			set{ _expiretime=value;}
			get{return _expiretime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReplyTime
		{
			set{ _replytime=value;}
			get{return _replytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reply
		{
			set{ _reply=value;}
			get{return _reply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProfileStatus
		{
			set{ _profilestatus=value;}
			get{return _profilestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Requirement
		{
			set{ _requirement=value;}
			get{return _requirement;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Evaluate
		{
			set{ _evaluate=value;}
			get{return _evaluate;}
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
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
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
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsReply
		{
			set{ _isreply=value;}
			get{return _isreply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

