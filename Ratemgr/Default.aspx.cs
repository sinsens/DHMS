using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Base;

namespace DHMS.Ratemgr
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControls();
            }
        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            GridView1.DataSource = Record.getRecordByYid();
            GridView1.DataBind(); // 数据绑定
            if (GridView1.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据库中没有找到相关记录！')", true);
            }
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind(); // 数据绑定
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
    }
}