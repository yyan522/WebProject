using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["adminId"] = null;
        }

		protected void btnSave_Click(object sender, EventArgs e)
		{

			string strErr = "";
			if (this.txtuserName.Text.Trim().Length == 0)
			{
				strErr += "userName不能为空！";
			}
			else if (this.txtpassWord.Text.Trim().Length == 0)
			{
				strErr += "passWord不能为空！";
			}

			if (strErr != "")
			{
				Response.Write("<script language=javascript>alert('" + strErr + "');</script>");
				return;
			}
			string userName = this.txtuserName.Text;
			string passWord = this.txtpassWord.Text;

			BLL.AdminBLL bll = new BLL.AdminBLL();
			var result = bll.Login(userName, passWord);
			if (result.IsOK)
			{
				Session["adminId"] = result.Data;
				Response.Write("<script language=javascript>alert('" + "登录成功" + "');window.location.href='/Admin/CategoryList.aspx';</script>");
			}
			else
			{
				Response.Write("<script language=javascript>alert('" + result.Msg + "');</script>");
			}
		}


		public void btnGo_Click(object sender, EventArgs e)
		{
			Response.Redirect("CategoryList.aspx");
		}
	}
}