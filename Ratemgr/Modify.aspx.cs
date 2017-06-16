using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Base;
using System.Data;

namespace DHMS.Ratemgr
{
    /// <summary>
    /// Request["bid"]:宿舍楼id
    /// fid：费率编号
    /// </summary>
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControls();
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /// 检测数据输入
            if (tbCr.Text.Length <= 0 || tbCr.Text.Length <= 0 || tbName.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("UPDATE T_Rate SET 费率名称=@rname,冷水费率=@cr,热水费率=@hr,电力费率=@dr,备注=@info,创建时间=Now(),是否启用=@is_use WHERE 费率编号=@fid;");
            cmd.Parameters.AddWithValue("rname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("cr", tbCr.Text.Trim());
            cmd.Parameters.AddWithValue("hr", tbHr.Text.Trim());
            cmd.Parameters.AddWithValue("dr", tbDr.Text.Trim());
            cmd.Parameters.AddWithValue("info", tbInfo.Text);
            cmd.Parameters.AddWithValue("is_use", tbUse.SelectedValue.Equals("是") ? true : false);// 是否启用
            cmd.Parameters.AddWithValue("fid", Request["fid"].ToString());
            /// 插入数据库
            try
            {
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    msgBox.Show(this, "修改成功");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this, "修改失败！" + ex.Message);
            }

        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            if (Request["fid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('未设置fid!请从查看页面(点击水电费率管理根节点)访问本页面！')", true);
                return;
            }

            /// 信息初始化
            var dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT top 1 * FROM T_Rate WHERE 费率编号=@fid;");
            cmd.Parameters.AddWithValue("fid", Request["fid"].ToString());
            dt = SQL.ExecuteQuery(cmd);
            if (dt == null || dt.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('非法访问！')", true);
                return;
            }
            /// 显示
            lbUse.Text = (bool)dt.Rows[0]["是否启用"] ? "是" : "否";
            tbName.Text = dt.Rows[0]["费率名称"].ToString();
            tbCr.Text = lbCr.Text = dt.Rows[0]["冷水费率"].ToString();
            tbHr.Text = lbHr.Text = dt.Rows[0]["热水费率"].ToString();
            tbDr.Text = lbDr.Text = dt.Rows[0]["电力费率"].ToString();
            tbInfo.Text = dt.Rows[0]["备注"].ToString();

        }
    }
}