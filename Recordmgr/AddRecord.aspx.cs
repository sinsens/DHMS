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
    public partial class AddRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["rid"] == null)
            {
                return;
            }
            if (Request["do"] != null && Request["do"].Equals("setValue"))
            {
                Title = "设定初始用量";
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("INSERT INTO T_Record (冷水用量,热水用量,电力用量,备注,宿舍编号) VALUES(@cr,@hr,@dr,@info,@rid);");
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
                    msgBox.Show(this, "登记成功！");
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
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM 宿舍 WHERE 宿舍编号=@rid;");
            cmd.Parameters.AddWithValue("rid", Request["rid"]);

            /// 获取数据
            var dt = new DataTable();
            dt = SQL.ExecuteQuery(cmd);
            /// 返回信息
            if (dt == null | dt.Rows.Count <= 0)
            {
                msgBox.Show(this, "没有该宿舍！");
                btnSave.Enabled = false;
                btnSave.ToolTip = "该宿舍信息不存在，无法编辑";
            }
            else
            {
                btnSave.ToolTip = "点击保存";
                btnSave.Enabled = true;
                text = dt.Rows[0]["院名称"].ToString() + dt.Rows[0]["宿舍楼名称"].ToString() + dt.Rows[0]["宿舍名称"].ToString();
            }
            return text;
        }

        /// <summary>
        /// 下一条链接
        /// </summary>
        /// <returns></returns>
        protected string NextLink()
        {
            if (Request["do"] != null && Request["do"].Equals("setValue"))
            {
                return (Convert.ToInt32(Request["rid"]) + 1).ToString() + "&do=setValue&";
            }
            else
            {
                return (Convert.ToInt32(Request["rid"]) + 1).ToString();
            }
        }
        /// <summary>
        /// 上一条链接
        /// </summary>
        /// <returns></returns>
        protected string PrvLink()
        {
            if (Request["do"] != null && Request["do"].Equals("setValue"))
            {
                return (Convert.ToInt32(Request["rid"]) - 1).ToString() + "&do=setValue&";
            }
            else
            {
                return (Convert.ToInt32(Request["rid"]) - 1).ToString();
            }
        }
    }
}