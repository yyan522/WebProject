using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Web.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected Model.Admin user;
        protected void Page_Load(object sender, EventArgs e)
        {
            var tmpStrid = Session["adminId"];
            if (tmpStrid == null)
            {
                return;
            }
            var userId = int.Parse(tmpStrid.ToString());
            user = new BLL.AdminBLL().Get(userId);
        }
    }
}