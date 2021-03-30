using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using WebProject.DAL;
using WebProject.Model;
namespace WebProject.BLL
{
	/// <summary>
	/// PopularSport
	/// </summary>
	public partial class PopularSportBLL
	{
		public PopularSportDAL dal = new PopularSportDAL();
		public PopularSportBLL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(PopularSport model)
		{
			return dal.Add(model);
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(PopularSport model)
		{
			return dal.Update(model);
		}
		/// <summary>
		///Delete
		/// </summary>
		public bool Delete(Int32 Id)
		{
			return dal.Delete(Id);
		}
		/// <summary>
		///Query
		/// </summary>
		public bool DeleteWhere(string where)		{
			return dal.DeleteWhere(where);
		}
		/// <summary>
		///Query
		/// </summary>
		public PopularSport Get(Int32 Id)
		{
			return dal.Get(Id);
		}
		/// <summary>
		///Query
		/// </summary>
		public PopularSport GetWhere(string where)		{
			return dal.GetWhere(where);
		}
		/// <summary>
		///Query
		/// </summary>
		public int GetCount(string where)		{
			return dal.GetCount(where);
		}
		/// <summary>
		///Query
		/// </summary>
		public List<PopularSport> GetList(string where)
		{
			return dal.GetList(where);
		}
		/// <summary>
		///Query
		/// </summary>
		public List<PopularSport> GetPage(string where, int pageIndex, int pageSize)
		{
			return dal.GetPage(where, pageIndex ,pageSize);
		}
	}
}

