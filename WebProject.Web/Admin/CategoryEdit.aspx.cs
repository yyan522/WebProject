using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace WebProject.Web.Admin
{
	public partial class CategoryEdit : Lib.AdminPage
	{
		protected int Id;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
			{
				Id = (Convert.ToInt32(Request.Params["id"]));
			}
			if (!Page.IsPostBack)
			{
				if (Id>0)
                {
					ShowInfo(Id);

				}
			}
		}

		private void ShowInfo(int Id)
		{
			WebProject.BLL.CategoryBLL bll = new WebProject.BLL.CategoryBLL();
			WebProject.Model.Category model = bll.Get(Id);
			this.TextBox1.Text = model.Name;
		}

		public void btnSave_Click(object sender, EventArgs e)
		{

			WebProject.BLL.CategoryBLL bll = new WebProject.BLL.CategoryBLL();
			try
			{
				WebProject.Model.Category model = new WebProject.Model.Category();
                if (Id>0)
				{
					model = bll.GetWhere(" id <> " + Id + " and name = '" + this.TextBox1.Text + "'");
					if (model != null && model.Id > 0)
					{
						Response.Write("<script language=javascript>alert('" + "Name already exist" + "');</script>");
						return;
					}
					model = bll.Get(Id);
                }
                else
                {
					model = bll.GetWhere(" name = '" + this.TextBox1.Text + "'");
					if (model != null && model.Id > 0)
					{
						Response.Write("<script language=javascript>alert('" + "Name already exist" + "');</script>");
						return;
					}
					model = new WebProject.Model.Category();
				}
				model.Name = this.TextBox1.Text;

				if (Id>0)
				{
					bll.Update(model);
				}
                else
				{
					bll.Add(model);
				}
				Response.Write("<script language=javascript>alert('Success!');window.location.href='CategoryList.aspx';</script>");
			}
			catch (Exception ex)
			{
				Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
				return;
			}

		}


		public void btnCancle_Click(object sender, EventArgs e)
		{
			Response.Redirect("CategoryList.aspx");
		}
	}
}
