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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /// 检测数据输入
            if (tbCr.Text.Length <= 0 || tbCr.Text.Length <= 0 || tbName.Text.Length <= 0)
            {
                msgBox.Show(this.Page, "数据输入有误，请重新输入！");
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("INSERT INTO T_Rate(费率名称,冷水费率,热水费率,电力费率,备注,是否启用) VALUES(@rname,@cr,@hr,@dr,@info,@is_use);");
            cmd.Parameters.AddWithValue("rname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("cr", tbCr.Text.Trim());
            cmd.Parameters.AddWithValue("hr", tbHr.Text.Trim());
            cmd.Parameters.AddWithValue("dr", tbDr.Text.Trim());
            cmd.Parameters.AddWithValue("info", tbInfo.Text);
            cmd.Parameters.AddWithValue("is_use", tbUse.SelectedValue.Equals("是") ? true : false);// 判断是否启用
            /// 插入数据库
            try
            {
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    msgBox.Show(this,"新增费率信息成功！");
                }
                else
                {
                    msgBox.Show(this, "未知错误!");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this, "新增费率信息失败！"+ex.Message);
            }
        }
    }
}