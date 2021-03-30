using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Web
{
    public partial class SportDetail : System.Web.UI.Page
    {
        public Model.PopularSport model;
        protected void Page_Load(object sender, EventArgs e)
        {
            var tmpId = Request["id"];
            var id = int.Parse(tmpId);
            model = new BLL.PopularSportBLL().Get(id);
            if (model == null)
            {
                model = new Model.PopularSport();
            }
        }
    }
}