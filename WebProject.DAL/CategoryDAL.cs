using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

using WebProject.Model;
namespace WebProject.DAL
{
	/// <summary>
	/// Category
	/// </summary>
	public partial class CategoryDAL
	{
		public CategoryDAL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(Category model)
		{
			string sql = "insert into Category (Name) values (@Name);select @IDENTITYVal = @@IDENTITY;";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@IDENTITYVal", SqlDbType = SqlDbType.Int }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = model.Name }); 
			sqlParams[0].Direction = ParameterDirection.Output;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			int identityV = Convert.ToInt32(sqlParams[0].Value);
			return identityV;
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(Category model)
		{
			string sql = "update Category set Name=@Name where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = model.Id }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = model.Name }); 
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			return result>0;
		}
		/// <summary>
		///Delete
		/// </summary>
		public bool Delete(Int32 Id)
		{
			string sql = "delete Category where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value =Id }); 
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			return result>0;
		}
		/// <summary>
		///Query
		/// </summary>
		public bool DeleteWhere(string where)
		{
			string sql = "delete  Category where "+ where;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			return result>0;
		}
		/// <summary>
		///Query
		/// </summary>
		public Category Get(Int32 Id)
		{
			string sql = "select * from  Category where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value =Id }); 
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			var list =Helper.DataSetToList<Category>(ds, 0);
			if(list == null || list.Count==0)
			{
				return null;
			}
			else
			{
				return list[0];
			}
		}
		/// <summary>
		///Query
		/// </summary>
		public Category GetWhere(string where)
		{
			string sql = "select * from  Category where "+ where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Category>(ds, 0);
			if(list == null || list.Count==0)
			{
				return null;
			}
			else
			{
				return list[0];
			}
		}
		/// <summary>
		///Query
		/// </summary>
		public int GetCount(string where)
		{
			string sql = "select count(0) from  Category where "+ where;
			var obj = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var count = (int)obj;
			return count;
		}
		/// <summary>
		///Query
		/// </summary>
		public List<Category> GetList(string where)
		{
			string sql = "select * from  Category where "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Category>(ds, 0);
			if(list == null || list.Count==0)
			{
				return null;
			}
			else
			{
				return list;
			}
		}
		/// <summary>
		///Query
		/// </summary>
		public List<Category> GetPage(string where, int pageIndex, int pageSize)
		{
			string sql = "SELECT TOP "+pageSize+" * FROM (SELECT ROW_NUMBER() OVER(ORDER BY Id desc) AS RowNumber, * FROM Category) as A WHERE RowNumber > "+(pageSize*(pageIndex-1)) +" and "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Category>(ds, 0);
			if(list == null || list.Count==0)
			{
				return null;
			}
			else
			{
				return list;
			}
		}
	}
}

