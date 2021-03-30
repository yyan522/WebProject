using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Drawing;
using WebProject.Web.Lib;

namespace WebProject.Web.Admin
{
    public partial class BuildingList : AdminPage
    {
        WebProject.BLL.BuildingBLL bll = new WebProject.BLL.BuildingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要Delete吗？\")");
                BindData();
            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var idlist = GetSelIDlist();
            foreach (var item in idlist)
            {
                var result = bll.Delete(item);
            }
            BindData();
        }

        #region gridView

        public void BindData()
        {
            StringBuilder strWhere = new StringBuilder(" 1=1 ");
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and BuildName like '%{0}%'", txtKeyword.Text.Trim());
            }
            var ds = bll.GetList(strWhere.ToString());
            gridView.DataSource = ds;
            gridView.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                
                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}
               
            }
        }
        
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            //int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            //bll.Delete(ID);
            //gridView.OnBind();
        }

        private List<int> GetSelIDlist()
        {
            List<int> idlist = new List<int>();
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("DeleteThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    if (gridView.DataKeys[i].Value != null)
                    {
                        idlist.Add(int.Parse(gridView.DataKeys[i].Value.ToString()));
                    }
                }
            }
            return idlist;
        }
        #endregion


    }
}
