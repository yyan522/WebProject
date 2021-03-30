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
	public partial class PopularSportEdit : Lib.AdminPage
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
				this.DropDownList1.DataSource = new BLL.CategoryBLL().GetList(" 1=1 ");
				this.DropDownList1.DataTextField = "name";
				this.DropDownList1.DataValueField = "id";
				this.DropDownList1.DataBind();

				if (Id>0)
                {
					ShowInfo(Id);

				}
			}
		}

		private void ShowInfo(int Id)
		{
			WebProject.BLL.PopularSportBLL bll = new WebProject.BLL.PopularSportBLL();
			WebProject.Model.PopularSport model = bll.Get(Id);
			this.DropDownList1.SelectedValue = model.CategoryId.ToString();
			this.TextBox1.Text = model.Name;
			this.TextBox2.Text = model.Remark;
			this.TextBox3.Text = model.Client;
		}

		public void btnSave_Click(object sender, EventArgs e)
		{

			WebProject.BLL.PopularSportBLL bll = new WebProject.BLL.PopularSportBLL();
			try
			{
				string imgPath1 = "";
				if (this.fileUpload1.HasFile)
				{
					var path = Server.MapPath("~/Uploads/");
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") +  "1"+ "." + this.fileUpload1.FileName.Split('.')[1];
					path = path + fileName;
					this.fileUpload1.SaveAs(path);
					imgPath1 = "/Uploads/" + fileName;
				}

				string imgPath2 = "";
				if (this.fileUpload2.HasFile)
				{
					var path = Server.MapPath("~/Uploads/");
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "2" + "." + this.fileUpload2.FileName.Split('.')[1];
					path = path + fileName;
					this.fileUpload2.SaveAs(path);
					imgPath2 = "/Uploads/" + fileName;
				}

				string imgPath3 = "";
				if (this.fileUpload3.HasFile)
				{
					var path = Server.MapPath("~/Uploads/");
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "3" + "." + this.fileUpload3.FileName.Split('.')[1];
					path = path + fileName;
					this.fileUpload3.SaveAs(path);
					imgPath3 = "/Uploads/" + fileName;
				}

				WebProject.Model.PopularSport model = new WebProject.Model.PopularSport();
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
					model = new WebProject.Model.PopularSport();
				}
				model.CategoryId = int.Parse(this.DropDownList1.SelectedValue);
				model.Name = this.TextBox1.Text;
				model.Remark = this.TextBox2.Text;
				model.Client = this.TextBox3.Text;
				if (!string.IsNullOrEmpty(imgPath1))
				{
					model.ImgPath1 = imgPath1;
				}
				if (!string.IsNullOrEmpty(imgPath2))
				{
					model.ImgPath2 = imgPath2;
				}
				if (!string.IsNullOrEmpty(imgPath3))
				{
					model.ImgPath3 = imgPath3;
				}

				if (Id>0)
				{
					bll.Update(model);
				}
                else
				{
					model.AddDate = DateTime.Now;
					bll.Add(model);
				}
				Response.Write("<script language=javascript>alert('Success!');window.location.href='PopularSportList.aspx';</script>");
			}
			catch (Exception ex)
			{
				Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
				return;
			}

		}


		public void btnCancle_Click(object sender, EventArgs e)
		{
			Response.Redirect("PopularSportList.aspx");
		}
	}
}
