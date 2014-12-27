/**  版本信息模板在安装目录下，可自行修改。
* ForgetPwdLog.cs
*
* 功 能： N/A
* 类 名： ForgetPwdLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/28 10:14:31   N/A    初版
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
	/// ForgetPwdLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ForgetPwdLog
	{
		public ForgetPwdLog()
		{}
		#region Model
		private int _id;
		private DateTime? _addtime= DateTime.Now;
		private int? _uid;
		private string _salt;
		private int? _status;
		private string _ip;
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
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 随机字符串
		/// </summary>
		public string Salt
		{
			set{ _salt=value;}
			get{return _salt;}
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
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		#endregion Model

	}
}

