/**  版本信息模板在安装目录下，可自行修改。
* Member.cs
*
* 功 能： N/A
* 类 名： Member
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/28 15:31:25   N/A    初版
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
	/// Member:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Member
	{
		public Member()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
		private DateTime? _regtime;
		private string _regip;
		private DateTime? _lastlogintime;
		private DateTime? _lastactivetime;
		private string _lastloginip;
		private int? _status;
		private string _salt;
		private int? _adminid;
		private int? _countyid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 注册IP
		/// </summary>
		public string RegIp
		{
			set{ _regip=value;}
			get{return _regip;}
		}
		/// <summary>
		/// 最后登录时间
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 最后访问时间
		/// </summary>
		public DateTime? LastActiveTime
		{
			set{ _lastactivetime=value;}
			get{return _lastactivetime;}
		}
		/// <summary>
		/// 最后登录IP
		/// </summary>
		public string LastLoginIp
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
		}
		/// <summary>
		/// 用户状态
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 用户密码随机数
		/// </summary>
		public string Salt
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 管理员等级 9 为管理员
		/// </summary>
		public int? AdminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		#endregion Model

	}
}

