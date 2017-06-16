using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Base;
using System.Data;

namespace DHMS.Recordmgr
{
    /// <summary>
    /// Request["bid"]:宿舍楼id
    /// fid：用量编号
    /// </summary>
    public partial class ModifyRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["rid"] == null)
            {
                return;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("UPDATE T_Record SET 冷水用量=@cr,热水用量=@hr,电力用量=@dr,备注=@info WHERE 记录编号=@rid;");
            cmd.Parameters.AddWithValue("cr", tbCr.Text.Trim());
            cmd.Parameters.AddWithValue("hr", tbHr.Text.Trim());
            cmd.Parameters.AddWithValue("dr", tbDr.Text.Trim());
            cmd.Parameters.AddWithValue("info", tbInfo.Text);
            cmd.Parameters.AddWithValue("rid", Request["rid"]);
            /// 插入数据库
            try
            {
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    msgBox.Show(this, "修改记录成功！");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert(\"登记失败！" + ex.Message + "\")", true);
            }
        }

        /// <summary>
        /// 显示宿舍信息
        /// </summary>
        protected string DisInfo()
        {
            if (Request["rid"] == null)
            {
                return null;
            }
            string text = "";
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM 记录 WHERE 记录编号=@rid;");
            cmd.Parameters.AddWithValue("rid", Request["rid"]);

            /// 获取数据
            var dt = new DataTable();
            dt = SQL.ExecuteQuery(cmd);
            /// 返回信息

            if (dt == null | dt.Rows.Count <= 0)
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "该条记录信息不存在，无法编辑";
            }
            else
            {
                btnSave.ToolTip = "点击保存";
                btnSave.Enabled = true;
                text = dt.Rows[0]["院名称"].ToString() + dt.Rows[0]["宿舍楼名称"].ToString() + dt.Rows[0]["宿舍名称"].ToString();
                DisRecord();
            }
            return text;
        }

        /// <summary>
        /// 显示宿舍最新登记用量信息
        /// </summary>
        protected void DisRecord()
        {
            if (Request["rid"] == null)
            {
                return;
            }
            var dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM T_Record WHERE 记录编号=@rid");
            cmd.Parameters.AddWithValue("rid", Request["rid"]);
            dt = SQL.ExecuteQuery(cmd);
            /// 返回信息
            if (dt == null | dt.Rows.Count <= 0)
            {
                return;
            }
            else
            {
                btnSave.ToolTip = "点击保存";
                btnSave.Enabled = true;
                tbCr.Text = dt.Rows[0]["冷水用量"].ToString();
                tbHr.Text = dt.Rows[0]["热水用量"].ToString();
                tbDr.Text = dt.Rows[0]["电力用量"].ToString();
                tbInfo.Text = dt.Rows[0]["备注"].ToString();
            }
        }

        protected bool enableStat() {
            return dbHelper.enableStat();
        }
    }
}