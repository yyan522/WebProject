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
	/// Admin
	/// </summary>
	public partial class AdminDAL
	{
		public AdminDAL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(Admin model)
		{
			string sql = "insert into Admin (UserName,Password) values (@UserName,@Password);select @IDENTITYVal = @@IDENTITY;";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@IDENTITYVal", SqlDbType = SqlDbType.Int }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@UserName", SqlDbType = SqlDbType.NVarChar, Value = model.UserName }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Value = model.Password }); 
			sqlParams[0].Direction = ParameterDirection.Output;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			int identityV = Convert.ToInt32(sqlParams[0].Value);
			return identityV;
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(Admin model)
		{
			string sql = "update Admin set UserName=@UserName,Password=@Password where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = model.Id }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@UserName", SqlDbType = SqlDbType.NVarChar, Value = model.UserName }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Value = model.Password }); 
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			return result>0;
		}
		/// <summary>
		///Delete
		/// </summary>
		public bool Delete(Int32 Id)
		{
			string sql = "delete Admin where Id=@Id";
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
			string sql = "delete  Admin where "+ where;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			return result>0;
		}
		/// <summary>
		///Query
		/// </summary>
		public Admin Get(Int32 Id)
		{
			string sql = "select * from  Admin where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value =Id }); 
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			var list =Helper.DataSetToList<Admin>(ds, 0);
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
		public Admin GetWhere(string where)
		{
			string sql = "select * from  Admin where "+ where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Admin>(ds, 0);
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
			string sql = "select count(0) from  Admin where "+ where;
			var obj = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var count = (int)obj;
			return count;
		}
		/// <summary>
		///Query
		/// </summary>
		public List<Admin> GetList(string where)
		{
			string sql = "select * from  Admin where "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Admin>(ds, 0);
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
		public List<Admin> GetPage(string where, int pageIndex, int pageSize)
		{
			string sql = "SELECT TOP "+pageSize+" * FROM (SELECT ROW_NUMBER() OVER(ORDER BY Id desc) AS RowNumber, * FROM Admin) as A WHERE RowNumber > "+(pageSize*(pageIndex-1)) +" and "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Admin>(ds, 0);
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

