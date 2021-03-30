using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using WebProject.DAL;
using WebProject.Model;
namespace WebProject.BLL
{
	/// <summary>
	/// Building
	/// </summary>
	public partial class BuildingBLL
	{
		public BuildingDAL dal = new BuildingDAL();
		public BuildingBLL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(Building model)
		{
			return dal.Add(model);
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(Building model)
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
		public Building Get(Int32 Id)
		{
			return dal.Get(Id);
		}
		/// <summary>
		///Query
		/// </summary>
		public Building GetWhere(string where)		{
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
		public List<Building> GetList(string where)
		{
			return dal.GetList(where);
		}
		/// <summary>
		///Query
		/// </summary>
		public List<Building> GetPage(string where, int pageIndex, int pageSize)
		{
			return dal.GetPage(where, pageIndex ,pageSize);
		}
	}
}

