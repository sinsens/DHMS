using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Base;
using System.Data;

namespace DHMS.DBuidingmgr
{
    public partial class Add : System.Web.UI.Page
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
            if (tbName.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("INSERT INTO T_Building(院编号,宿舍楼名称,备注) VALUES(@did,@nname,@info);");
            //cmd.Parameters.AddWithValue("nid", tbDid.SelectedValue+tbId.Text.Trim());
            cmd.Parameters.AddWithValue("did", tbDid.SelectedValue);
            cmd.Parameters.AddWithValue("nname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("info", tbInfo.Text.Trim());
            /// 插入数据库
            try
            {
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('添加成功！')", true);
                    //Response.Redirect("./");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('添加失败！" + ex.Message + "')", true);
            }
        }


        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {

            var dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT 院编号,院名称 FROM T_Dormitory order By 院类型,院编号");
            dt = SQL.ExecuteQuery(cmd);
            if (dt.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('未找到相关数据！请先添加院别(点击院管理->添加宿舍院)')", true);
                return;
            }

            ListItem[] li = new ListItem[dt.Rows.Count];

            /// 显示
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                li[i] = new ListItem(dt.Rows[i]["院名称"].ToString(), dt.Rows[i]["院编号"].ToString());
            }
            tbDid.Items.AddRange(li);
        }

    }
}