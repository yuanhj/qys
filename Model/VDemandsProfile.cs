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
namespace ServiceWeb.Model
{
	/// <summary>
	/// VDemandsProfile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VDemandsProfile
	{
		public VDemandsProfile()
		{}
		#region Model
		private int? _pid;
		private int _id;
		private string _dtypeid;
		private int _countyid;
		private int _uid;
		private string _serial;
		private string _subject;
		private string _contents;
		private DateTime? _addtime;
		private string _ip;
		private int? _status;
		private string _denyreason;
		private int? _isdistribution;
		private string _result;
		private DateTime? _donetime;
		private int _profileid;
		private DateTime? _profileaddtime;
		private DateTime _expiretime;
		private DateTime? _replytime;
		private string _reply;
		private int? _profilestatus;
		private int? _isreply;
		private string _requirement;
		private decimal? _evaluate;
		private string _username;
		private string _mobile;
		private int _parentid;
		private string _departmentname;
		private int _departmentcid;
		/// <summary>
		/// 
		/// </summary>
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
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
		public string DTypeID
		{
			set{ _dtypeid=value;}
			get{return _dtypeid;}
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
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Serial
		{
			set{ _serial=value;}
			get{return _serial;}
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
		public string Contents
		{
			set{ _contents=value;}
			get{return _contents;}
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
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
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
		public string DenyReason
		{
			set{ _denyreason=value;}
			get{return _denyreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDistribution
		{
			set{ _isdistribution=value;}
			get{return _isdistribution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DoneTime
		{
			set{ _donetime=value;}
			get{return _donetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProfileID
		{
			set{ _profileid=value;}
			get{return _profileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProfileAddtime
		{
			set{ _profileaddtime=value;}
			get{return _profileaddtime;}
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
		public int? IsReply
		{
			set{ _isreply=value;}
			get{return _isreply;}
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
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public int DepartmentCID
		{
			set{ _departmentcid=value;}
			get{return _departmentcid;}
		}
		#endregion Model

	}
}

