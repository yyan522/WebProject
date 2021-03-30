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
using System.IO;

namespace WebProject.Web.Admin
{
	public partial class BuildingEdit : Lib.AdminPage
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
			WebProject.BLL.BuildingBLL bll = new WebProject.BLL.BuildingBLL();
			WebProject.Model.Building model = bll.Get(Id);
			this.TextBox1.Text = model.BuildName;
			this.TextBox2.Text = model.Address;
			this.TextBox3.Text = model.lng;
			this.TextBox3.Text = model.lat;
		}

		public void btnSave_Click(object sender, EventArgs e)
		{

			WebProject.BLL.BuildingBLL bll = new WebProject.BLL.BuildingBLL();
			try
			{
				WebProject.Model.Building model = new WebProject.Model.Building();
                if (Id>0)
				{
					model = bll.Get(Id);
                }
                else
                {
					model = new WebProject.Model.Building();
				}
				model.BuildName = this.TextBox1.Text;
				model.Address = this.TextBox2.Text;
				model.lng = this.TextBox3.Text;
				model.lat = this.TextBox4.Text;

				if (Id>0)
				{
					bll.Update(model);
				}
                else
				{
					model.AddDate = DateTime.Now;
					bll.Add(model);
				}
				Response.Write("<script language=javascript>alert('Success!');window.location.href='BuildingList.aspx';</script>");
			}
			catch (Exception ex)
			{
				Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
				return;
			}

		}


		public void btnCancle_Click(object sender, EventArgs e)
		{
			Response.Redirect("BuildingList.aspx");
		}
	}
}
