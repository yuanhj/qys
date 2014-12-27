/**  版本信息模板在安装目录下，可自行修改。
* DemandProfile.cs
*
* 功 能： N/A
* 类 名： DemandProfile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/28 15:31:24   N/A    初版
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
	/// DemandProfile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DemandProfile
	{
		public DemandProfile()
		{}
		#region Model
		private int _id;
		private int? _pid;
		private int _did;
		private DateTime? _addtime= DateTime.Now;
		private DateTime _expiretime;
		private DateTime? _replytime;
		private string _reply;
		private int? _status=0;
		private int? _isreply;
		private string _requirement;
		private decimal? _evaluate=0M;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 处理人ID
		/// </summary>
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 诉求ID
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 转办时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 过期时间
		/// </summary>
		public DateTime ExpireTime
		{
			set{ _expiretime=value;}
			get{return _expiretime;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime? ReplyTime
		{
			set{ _replytime=value;}
			get{return _replytime;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string Reply
		{
			set{ _reply=value;}
			get{return _reply;}
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
		/// 是否回复
		/// </summary>
		public int? IsReply
		{
			set{ _isreply=value;}
			get{return _isreply;}
		}
		/// <summary>
		/// 办理事项
		/// </summary>
		public string Requirement
		{
			set{ _requirement=value;}
			get{return _requirement;}
		}
		/// <summary>
		/// 评分
		/// </summary>
		public decimal? Evaluate
		{
			set{ _evaluate=value;}
			get{return _evaluate;}
		}
		#endregion Model

	}
}

