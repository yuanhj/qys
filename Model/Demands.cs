/**  版本信息模板在安装目录下，可自行修改。
* Demands.cs
*
* 功 能： N/A
* 类 名： Demands
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/4 17:02:24   N/A    初版
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
	/// Demands:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Demands
	{
		public Demands()
		{}
		#region Model
		private int _id;
		private string _dtypeid;
		private int _countyid;
		private int _uid;
		private string _serial;
		private string _subject;
		private string _contents;
		private DateTime? _addtime= DateTime.Now;
		private string _ip;
		private int? _status=0;
		private string _denyreason;
		private int? _isdistribution=0;
		private string _result;
		private DateTime? _donetime;
		private string _working;
		/// <summary>
		/// 诉求ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类别ID
		/// </summary>
		public string DTypeID
		{
			set{ _dtypeid=value;}
			get{return _dtypeid;}
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
		/// 用户ID
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 生成的编号
		/// </summary>
		public string Serial
		{
			set{ _serial=value;}
			get{return _serial;}
		}
		/// <summary>
		/// 诉求标题
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 诉求内容
		/// </summary>
		public string Contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 提交IP
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
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
		/// 拒绝原因
		/// </summary>
		public string DenyReason
		{
			set{ _denyreason=value;}
			get{return _denyreason;}
		}
		/// <summary>
		/// 是否已分割
		/// </summary>
		public int? IsDistribution
		{
			set{ _isdistribution=value;}
			get{return _isdistribution;}
		}
		/// <summary>
		/// 总结
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 办结时间
		/// </summary>
		public DateTime? DoneTime
		{
			set{ _donetime=value;}
			get{return _donetime;}
		}
		/// <summary>
		/// 进展情况
		/// </summary>
		public string Working
		{
			set{ _working=value;}
			get{return _working;}
		}
		#endregion Model

	}
}

