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
    public partial class Modify : System.Web.UI.Page
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
            if (tbId.Text.Length <= 0 || tbName.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("UPDATE T_Dormitory SET 院名称=@nname,院类型=@ntype,备注=@info WHERE 院编号=@did;");
            cmd.Parameters.AddWithValue("nname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("ntype", tbType.SelectedValue);
            cmd.Parameters.AddWithValue("info", tbInfo.Text);
            cmd.Parameters.AddWithValue("did", Request["did"].ToString());
            try
            {
                /// 插入数据库
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    //Response.Redirect("./Modify.aspx?did=" + tbId.Text);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('修改成功！')", true);
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('修改失败！')", true);
                msgBox.Show(this,"修改失败"+ex.Message);
            }

        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            if (Request["did"] == null)
            {
                return;
            }

            var dt = new DataTable();
            dt = Yid.getYidDataTable(Request["did"].ToString());
            if (dt==null||dt.Rows.Count<=0)
            {
                return;
            }
            /// 显示
            tbId.Text = lbId.Text = dt.Rows[0][0].ToString();
            tbName.Text = lbName.Text = dt.Rows[0][1].ToString();
            tbType.SelectedValue = lbType.Text = dt.Rows[0][2].ToString();
            tbInfo.Text = dt.Rows[0][3].ToString();
        }
    }
}