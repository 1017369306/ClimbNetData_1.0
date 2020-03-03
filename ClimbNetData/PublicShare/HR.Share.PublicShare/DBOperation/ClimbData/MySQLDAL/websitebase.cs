/**  版本信息模板在安装目录下，可自行修改。
* websitebase.cs
*
* 功 能： N/A
* 类 名： websitebase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/3/1 20:00:47   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.MySQLDAL
{
	/// <summary>
	/// 数据访问类:websitebase
	/// </summary>
	public partial class websitebase:Iwebsitebase
	{
		public websitebase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from websitebase");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,32)			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.websitebase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into websitebase(");
			strSql.Append("id,createTime,updateTime,webSiteType,content,imageUrl,moduleCount)");
			strSql.Append(" values (");
			strSql.Append("@id,@createTime,@updateTime,@webSiteType,@content,@imageUrl,@moduleCount)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,32),
					new MySqlParameter("@createTime", MySqlDbType.DateTime),
					new MySqlParameter("@updateTime", MySqlDbType.DateTime),
					new MySqlParameter("@webSiteType", MySqlDbType.VarChar,255),
					new MySqlParameter("@content", MySqlDbType.VarChar,255),
					new MySqlParameter("@imageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("@moduleCount", MySqlDbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.createTime;
			parameters[2].Value = model.updateTime;
			parameters[3].Value = model.webSiteType;
			parameters[4].Value = model.content;
			parameters[5].Value = model.imageUrl;
			parameters[6].Value = model.moduleCount;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.websitebase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update websitebase set ");
			strSql.Append("createTime=@createTime,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("webSiteType=@webSiteType,");
			strSql.Append("content=@content,");
			strSql.Append("imageUrl=@imageUrl,");
			strSql.Append("moduleCount=@moduleCount");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@createTime", MySqlDbType.DateTime),
					new MySqlParameter("@updateTime", MySqlDbType.DateTime),
					new MySqlParameter("@webSiteType", MySqlDbType.VarChar,255),
					new MySqlParameter("@content", MySqlDbType.VarChar,255),
					new MySqlParameter("@imageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("@moduleCount", MySqlDbType.Int32,4),
					new MySqlParameter("@id", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.createTime;
			parameters[1].Value = model.updateTime;
			parameters[2].Value = model.webSiteType;
			parameters[3].Value = model.content;
			parameters[4].Value = model.imageUrl;
			parameters[5].Value = model.moduleCount;
			parameters[6].Value = model.id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from websitebase ");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,32)			};
			parameters[0].Value = id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from websitebase ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.websitebase GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,createTime,updateTime,webSiteType,content,imageUrl,moduleCount from websitebase ");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,32)			};
			parameters[0].Value = id;

			Maticsoft.Model.websitebase model=new Maticsoft.Model.websitebase();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.websitebase DataRowToModel(DataRow row)
		{
			Maticsoft.Model.websitebase model=new Maticsoft.Model.websitebase();
			if (row != null)
			{
				if(row["id"]!=null)
				{
					model.id=row["id"].ToString();
				}
				if(row["createTime"]!=null && row["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(row["createTime"].ToString());
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
				}
				if(row["webSiteType"]!=null)
				{
					model.webSiteType=row["webSiteType"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["imageUrl"]!=null)
				{
					model.imageUrl = new Uri(row["imageUrl"].ToString());
				}
				if(row["moduleCount"]!=null && row["moduleCount"].ToString()!="")
				{
					model.moduleCount=int.Parse(row["moduleCount"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,createTime,updateTime,webSiteType,content,imageUrl,moduleCount ");
			strSql.Append(" FROM websitebase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM websitebase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from websitebase T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "websitebase";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

