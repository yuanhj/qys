/**  版本信息模板在安装目录下，可自行修改。
* Post.cs
*
* 功 能： N/A
* 类 名： Post
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/25 17:00:40   N/A    初版
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
	/// Post:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Post
	{
		public Post()
		{}
		#region Model
		private int _id;
		private int _countyid;
		private string _subject;
		private int? _typeid;
		private string _message;
		private DateTime? _addtime;
		private DateTime? _updatetime;
		private int? _status;
		private int? _istop;
		private int _dispalyorder=0;
		private int? _issystem=0;
		/// <summary>
		/// 新闻ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 新闻标题
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 新闻类型
		/// </summary>
		public int? TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 新闻内容
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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
		/// 是否置顶 1:是 0:否
		/// </summary>
		public int? IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int DispalyOrder
		{
			set{ _dispalyorder=value;}
			get{return _dispalyorder;}
		}
		/// <summary>
		/// 是否系统文章
		/// </summary>
		public int? IsSystem
		{
			set{ _issystem=value;}
			get{return _issystem;}
		}
		#endregion Model

	}
}

