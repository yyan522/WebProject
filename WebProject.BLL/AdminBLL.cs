using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using WebProject.DAL;
using WebProject.Model;
namespace WebProject.BLL
{
	/// <summary>
	/// Admin
	/// </summary>
	public partial class AdminBLL
	{
		public AdminDAL dal = new AdminDAL();
		public AdminBLL()
		{}
		/// <summary>
		///Add
		/// </summary>
		public int Add(Admin model)
		{
			return dal.Add(model);
		}
		/// <summary>
		///更新
		/// </summary>
		public bool Update(Admin model)
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
		public Admin Get(Int32 Id)
		{
			return dal.Get(Id);
		}
		/// <summary>
		///Query
		/// </summary>
		public Admin GetWhere(string where)		{
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
		public List<Admin> GetList(string where)
		{
			return dal.GetList(where);
		}
		/// <summary>
		///Query
		/// </summary>
		public List<Admin> GetPage(string where, int pageIndex, int pageSize)
		{
			return dal.GetPage(where, pageIndex ,pageSize);
		}

		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="pwd">密码</param>
		public ResultEntity Login(string userName, string pwd)
		{
			ResultEntity result = new ResultEntity();

			if (string.IsNullOrEmpty(userName))
			{
				result.Msg = "请输入用户名";
				return result;
			}
			if (userName.Length > 20)
			{
				result.Msg = "用户名只能输入1-20个字符";
				return result;
			}
			if (string.IsNullOrEmpty(pwd))
			{
				result.Msg = "请输入密码";
				return result;
			}
			if (pwd.Length > 20)
			{
				result.Msg = "密码只能输入1-20个字符";
				return result;
			}
			var entity = dal.GetWhere(" username = '" + userName + "' ");
			if (entity == null)
			{
				result.Msg = "用户名不存在";
				return result;
			}
			if (entity.Password != pwd)
			{
				result.Msg = "密码错误";
				return result;
			}

			result.IsOK = true;
			result.Msg = "登录成功";
			result.Data = entity.Id;
			return result;
		}
	}
}

