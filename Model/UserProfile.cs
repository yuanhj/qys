/**  版本信息模板在安装目录下，可自行修改。
* UserProfile.cs
*
* 功 能： N/A
* 类 名： UserProfile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/13 15:12:56   N/A    初版
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
	/// UserProfile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserProfile
	{
		public UserProfile()
		{}
		#region Model
		private int _id;
		private int _uid;
		private string _companyname;
		private string _summary;
		private string _legalperson;
		private string _address;
		private string _phone;
		private string _website;
		private string _contactname;
		private string _mobile;
		private string _clogo;
		private string _email;
		private int? _istop;
		/// <summary>
		/// 企业ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 公司名称
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 公司简述
		/// </summary>
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 法人
		/// </summary>
		public string LegalPerson
		{
			set{ _legalperson=value;}
			get{return _legalperson;}
		}
		/// <summary>
		/// 具体地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 单位电话
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 网址
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactName
		{
			set{ _contactname=value;}
			get{return _contactname;}
		}
		/// <summary>
		/// 联系人手机
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 企业图标
		/// </summary>
		public string CLogo
		{
			set{ _clogo=value;}
			get{return _clogo;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 首页是否推荐
		/// </summary>
		public int? IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		#endregion Model

	}
}

