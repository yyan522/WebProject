using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Model.Category> categoryList;
        public List<Model.PopularSport> sportList;
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryList = new BLL.CategoryBLL().GetList(" 1=1 ");
            if (categoryList == null)
            {
                categoryList = new List<Model.Category>();
            }
            sportList = new BLL.PopularSportBLL().GetList(" 1=1 ");
            if (sportList == null)
            {
                sportList = new List<Model.PopularSport>();
            }
        }
    }
}