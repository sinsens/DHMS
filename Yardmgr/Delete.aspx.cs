using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Base;
using System.Data;

namespace DHMS.Yardmgr
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControls();
            }   
        }

        protected string did = null;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request["did"] == null)
            {
                return;
            }

            /// 检测数据输入
            if (tbId.Text.Length<=0||tbName.Text.Length<=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /*
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("DELETE FROM T_Dormitory WHERE 院编号=@oid;");
            cmd.Parameters.AddWithValue("oid", Request["did"].ToString());
            /// 插入数据库
            if (SQL.ExecuteNonQuery(cmd)>=1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('删除成功！')", true);
                Response.Redirect("./");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('删除失败！')", true);
            }*/
            if (Yid.Delete(Request["did"]))
            {
                msgBox.Show(this, "删除成功!");
            }
            else
            {
                msgBox.Show(this, "删除失败");
            }
        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls() {
            if (Request["did"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('未设置did!请从查看页面(点击院管理根节点)访问本页面！')", true);
                return;
            }

            var dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT top 1 * FROM T_Dormitory WHERE 院编号=@did;");
            cmd.Parameters.AddWithValue("did", Request["did"].ToString());
            //dt = SQL.ExecuteQuery(cmd);
            dt = Yid.getYidDataTable(Request["did"]);
            if (dt==null || dt.Rows.Count<=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('非法访问！')", true);
                return;
            }
            /// 显示
            tbId.Text =  dt.Rows[0][0].ToString();
            tbName.Text =  dt.Rows[0][1].ToString();
            tbType.SelectedValue = dt.Rows[0][2].ToString();
            tbInfo.Text = dt.Rows[0][3].ToString();
        }

        /// <summary>
        /// 统计相关宿舍数量
        /// </summary>
        protected int countRoom {
            get {
                return Room.Count(1, Convert.ToInt32(Request["did"].ToString()));
            }
        }

        /// <summary>
        /// 统计相关宿舍楼数量
        /// </summary>
        protected int countBuilding
        {
            get
            {
                return Building.Count(1, Convert.ToInt32(Request["did"].ToString()));
            }
        }
    }
}