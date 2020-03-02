/**  版本信息模板在安装目录下，可自行修改。
* websitebase.cs
*
* 功 能： N/A
* 类 名： websitebase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/3/1 20:00:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// websitebase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class websitebase
	{
		public websitebase()
		{}
		#region Model
		private string _id;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private string _websitetype;
		private string _content;
		private string _imageurl;
		private int? _modulecount;
        private int? _index;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webSiteType
		{
			set{ _websitetype=value;}
			get{return _websitetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? moduleCount
		{
			set{ _modulecount=value;}
			get{return _modulecount;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int? index
        {
            set { _index = value; }
            get { return _index; }
        }
        #endregion Model

    }
}

