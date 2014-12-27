/**  版本信息模板在安装目录下，可自行修改。
* VMemberInfo.cs
*
* 功 能： N/A
* 类 名： VMemberInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/17 17:07:30   N/A    初版
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
	/// VMemberInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VMemberInfo
	{
		public VMemberInfo()
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
		private string _companyname;
		private string _summary;
		private string _legalperson;
		private string _address;
		private string _phone;
		private string _website;
		private string _contactname;
		private string _clogo;
		private string _email;
		private int? _istop;
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
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegIp
		{
			set{ _regip=value;}
			get{return _regip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastActiveTime
		{
			set{ _lastactivetime=value;}
			get{return _lastactivetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastLoginIp
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
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
		public string Salt
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 
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
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LegalPerson
		{
			set{ _legalperson=value;}
			get{return _legalperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactName
		{
			set{ _contactname=value;}
			get{return _contactname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CLogo
		{
			set{ _clogo=value;}
			get{return _clogo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		#endregion Model

	}
}

