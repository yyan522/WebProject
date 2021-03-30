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
	/// PopularSport
	/// </summary>
	public partial class PopularSportDAL
	{
		public PopularSportDAL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(PopularSport model)
		{
			string sql = "insert into PopularSport (CategoryId,Name,Remark,Client,AddDate,ImgPath1,ImgPath2,ImgPath3) values (@CategoryId,@Name,@Remark,@Client,@AddDate,@ImgPath1,@ImgPath2,@ImgPath3);select @IDENTITYVal = @@IDENTITY;";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@IDENTITYVal", SqlDbType = SqlDbType.Int }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = model.CategoryId }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = model.Name }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Remark", SqlDbType = SqlDbType.NVarChar, Value = model.Remark }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Client", SqlDbType = SqlDbType.NVarChar, Value = model.Client }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@AddDate", SqlDbType = SqlDbType.DateTime, Value = model.AddDate }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@ImgPath1", SqlDbType = SqlDbType.NVarChar, Value = model.ImgPath1 }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@ImgPath2", SqlDbType = SqlDbType.NVarChar, Value = model.ImgPath2 }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@ImgPath3", SqlDbType = SqlDbType.NVarChar, Value = model.ImgPath3 }); 
			sqlParams[0].Direction = ParameterDirection.Output;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			int identityV = Convert.ToInt32(sqlParams[0].Value);
			return identityV;
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(PopularSport model)
		{
			string sql = "update PopularSport set CategoryId=@CategoryId,Name=@Name,Remark=@Remark,Client=@Client,AddDate=@AddDate,ImgPath1=@ImgPath1,ImgPath2=@ImgPath2,ImgPath3=@ImgPath3 where Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = model.Id }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = model.CategoryId }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = model.Name }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Remark", SqlDbType = SqlDbType.NVarChar, Value = model.Remark }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@Client", SqlDbType = SqlDbType.NVarChar, Value = model.Client }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@AddDate", SqlDbType = SqlDbType.DateTime, Value = model.AddDate }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@ImgPath1", SqlDbType = SqlDbType.NVarChar, Value = model.ImgPath1 }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@ImgPath2", SqlDbType = SqlDbType.NVarChar, Value = model.ImgPath2 }); 
			sqlParams.Add(new SqlParameter() { ParameterName = "@ImgPath3", SqlDbType = SqlDbType.NVarChar, Value = model.ImgPath3 }); 
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			return result>0;
		}
		/// <summary>
		///Delete
		/// </summary>
		public bool Delete(Int32 Id)
		{
			string sql = "delete PopularSport where Id=@Id";
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
			string sql = "delete  PopularSport where "+ where;
			int result = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			return result>0;
		}
		/// <summary>
		///Query
		/// </summary>
		public PopularSport Get(Int32 Id)
		{
			string sql = "select a.*, b.name 'CategoryName' from  PopularSport a inner join Category b on a.categoryId = b.id where a.Id=@Id";
			List<SqlParameter> sqlParams = new List<SqlParameter>();
			sqlParams.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value =Id }); 
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql, sqlParams.ToArray());
			var list =Helper.DataSetToList<PopularSport>(ds, 0);
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
		public PopularSport GetWhere(string where)
		{
			string sql = "select a.*, b.name 'CategoryName' from  PopularSport a inner join Category b on a.categoryId = b.id where " + where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<PopularSport>(ds, 0);
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
			string sql = "select count(0) from  PopularSport where "+ where;
			var obj = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var count = (int)obj;
			return count;
		}
		/// <summary>
		///Query
		/// </summary>
		public List<PopularSport> GetList(string where)
		{
			string sql = "select a.*, b.name 'CategoryName' from  PopularSport a inner join Category b on a.categoryId = b.id where " + where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<PopularSport>(ds, 0);
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
		public List<PopularSport> GetPage(string where, int pageIndex, int pageSize)
		{
			string sql = "SELECT TOP "+pageSize+" * FROM (SELECT ROW_NUMBER() OVER(ORDER BY Id desc) AS RowNumber, * FROM PopularSport) as A WHERE RowNumber > "+(pageSize*(pageIndex-1)) +" and "+where;
			var ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString(), CommandType.Text, sql);
			var list =Helper.DataSetToList<PopularSport>(ds, 0);
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

