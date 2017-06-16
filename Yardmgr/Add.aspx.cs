using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Base;

namespace DHMS.Yardmgr
{
    public partial class Add : System.Web.UI.Page
    {

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /// 检测数据输入
            if (tbId.Text.Length<=0||tbName.Text.Length<=0||Convert.ToInt32(tbId.Text)==0)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('院编号不能为0或为空，院名称不能为空')", true);
                msgBox.Show(this, "院编号不能为0或为空，院名称不能为空");
                return;
            }
            /*
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("INSERT INTO T_Dormitory VALUES(@nid,@nname,@ntype,@info);");
            cmd.Parameters.AddWithValue("nid", tbId.Text.Trim());
            cmd.Parameters.AddWithValue("nname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("ntype",tbType.SelectedValue);
            cmd.Parameters.AddWithValue("info", info.Text);
            /// 插入数据库
            try
            {
                if (SQL.ExecuteNonQuery(cmd)>=1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('添加成功！')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('添加失败！"+ex.Message+"')", true);
            }*/
            if (Yid.Add(Convert.ToInt32(tbId.Text.Trim()), tbName.Text.Trim(), tbType.SelectedValue, info.Text)) {
                msgBox.Show(this, "添加成功!");
            }
            else
            {
                msgBox.Show(this, "添加失败!");
            }
        }
    }
}