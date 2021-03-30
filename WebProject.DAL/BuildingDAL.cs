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
	/// Building
	/// </summary>
	public partial class BuildingDAL
	{
		public BuildingDAL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(Building model)
		{
			string sql = "insert into Building (BuildName,Address,lng,lat,AddDate) values (@BuildName,@Address,@lng,@lat,@AddDate);select @IDENTITYVal = @@IDENTITY;";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@IDENTITYVal", SqlDbType = SqlDbType.Int }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@BuildName", SqlDbType = SqlDbType.NVarChar, Value = model.BuildName }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Value = model.Address }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@lng", SqlDbType = SqlDbType.NVarChar, Value = model.lng }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@lat", SqlDbType = SqlDbType.NVarChar, Value = model.lat }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@AddDate", SqlDbType = SqlDbType.DateTime, Value = model.AddDate }); 
			sqlParams[0].Direction = ParameterDirection.Output;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			int identityV = Convert.ToInt32(sqlParams[0].Value);
			return identityV;
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(Building model)
		{
			string sql = "update Building set BuildName=@BuildName,Address=@Address,lng=@lng,lat=@lat,AddDate=@AddDate where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = model.Id }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@BuildName", SqlDbType = SqlDbType.NVarChar, Value = model.BuildName }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Value = model.Address }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@lng", SqlDbType = SqlDbType.NVarChar, Value = model.lng }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@lat", SqlDbType = SqlDbType.NVarChar, Value = model.lat }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@AddDate", SqlDbType = SqlDbType.DateTime, Value = model.AddDate }); 
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			return result>0;
		}
		/// <summary>
		///Delete
		/// </summary>
		public bool Delete(Int32 Id)
		{
			string sql = "delete Building where Id=@Id";
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
			string sql = "delete  Building where "+ where;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			return result>0;
		}
		/// <summary>
		///Query
		/// </summary>
		public Building Get(Int32 Id)
		{
			string sql = "select * from  Building where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value =Id }); 
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			var list =Helper.DataSetToList<Building>(ds, 0);
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
		public Building GetWhere(string where)
		{
			string sql = "select * from  Building where "+ where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Building>(ds, 0);
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
			string sql = "select count(0) from  Building where "+ where;
			var obj = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var count = (int)obj;
			return count;
		}
		/// <summary>
		///Query
		/// </summary>
		public List<Building> GetList(string where)
		{
			string sql = "select * from  Building where "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Building>(ds, 0);
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
		public List<Building> GetPage(string where, int pageIndex, int pageSize)
		{
			string sql = "SELECT TOP "+pageSize+" * FROM (SELECT ROW_NUMBER() OVER(ORDER BY Id desc) AS RowNumber, * FROM Building) as A WHERE RowNumber > "+(pageSize*(pageIndex-1)) +" and "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<Building>(ds, 0);
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

