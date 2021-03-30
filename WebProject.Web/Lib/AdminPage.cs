using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebProject.Web.Lib
{
    public class AdminPage : Page
    {
        public int adminId = 0;
        protected void Page_Init(object sender, EventArgs e)
        {
            var tmpStrid = Session["adminId"];
            if (tmpStrid == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
            adminId = int.Parse(tmpStrid.ToString());
        }
    }
}