﻿/**  版本信息模板在安装目录下，可自行修改。
* websitebase.cs
*
* 功 能： N/A
* 类 名： websitebase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/3/1 20:00:48   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace Maticsoft.IDAL
{
	/// <summary>
	/// 接口层websitebase
	/// </summary>
	public interface Iwebsitebase
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Maticsoft.Model.websitebase model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Maticsoft.Model.websitebase model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
		bool DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Maticsoft.Model.websitebase GetModel(string id);
		Maticsoft.Model.websitebase DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		int GetRecordCount(string strWhere);
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}