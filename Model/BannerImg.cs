/**  版本信息模板在安装目录下，可自行修改。
* BannerImg.cs
*
* 功 能： N/A
* 类 名： BannerImg
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/12 17:01:42   N/A    初版
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
	/// BannerImg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BannerImg
	{
		public BannerImg()
		{}
		#region Model
		private int _id;
		private string _subject;
		private string _imagepath;
		private string _contents;
		private string _imagelinks;
		private int? _status;
		private int? _countyid;
		private DateTime? _addtime;
		/// <summary>
		/// 图片编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 图片标题
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string ImagePath
		{
			set{ _imagepath=value;}
			get{return _imagepath;}
		}
		/// <summary>
		/// 图片描述
		/// </summary>
		public string Contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 图片链接
		/// </summary>
		public string ImageLinks
		{
			set{ _imagelinks=value;}
			get{return _imagelinks;}
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
		/// 区县ID
		/// </summary>
		public int? CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
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

