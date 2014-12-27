/**  版本信息模板在安装目录下，可自行修改。
* EmphasisComPany.cs
*
* 功 能： N/A
* 类 名： EmphasisComPany
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/9 12:56:51   N/A    初版
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
	/// EmphasisComPany:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EmphasisComPany
	{
		public EmphasisComPany()
		{}
		#region Model
		private int _id;
		private int? _cid;
		private string _name;
		private string _logoimg;
		private int? _status=0;
		private int? _istop=0;
		private DateTime? _addtime;
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
		public int? CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 企业名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string LogoImg
		{
			set{ _logoimg=value;}
			get{return _logoimg;}
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
		/// 首页是否显示
		/// </summary>
		public int? IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

