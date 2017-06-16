using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using System.Data.OleDb;

namespace DHMS.Yardmgr
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

        protected void tbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            initControls(tbType.SelectedValue);
        }

        /// <summary>
        /// 筛选院别信息
        /// </summary>
        /// <param name="type">男,女</param>
        protected void initControls(string type="") {
            OleDbCommand cmd = new OleDbCommand();
            switch (type) {
                case "男":
                    cmd.CommandText=("SELECT * FROM T_Dormitory WHERE 院类型='男';");
                    break;
                case "女":
                    cmd.CommandText = ("SELECT * FROM T_Dormitory WHERE 院类型='女';");
                    break;
                default:
                    cmd.CommandText = ("SELECT * FROM T_Dormitory;");
                    break;
            }
            GridView1.DataSource = SQL.ExecuteQuery(cmd);
            GridView1.DataBind(); // 数据绑定 // 绑定显示
            if (GridView1.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据库中没有找到相关记录！')", true);
            }
        }
    }
}