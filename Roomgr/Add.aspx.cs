using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using System.Data.OleDb;
using System.Data;

namespace DHMS.Roomgr
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

        /// <summary>
        /// 点击确定添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /// 检测数据输入
            if (tbName.Text.Length <= 0 || tbBid.SelectedValue == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("INSERT INTO T_Room(宿舍楼编号,宿舍名称,备注) VALUES(@did,@nname,@info);");
            cmd.Parameters.AddWithValue("bid", tbBid.SelectedValue);
            cmd.Parameters.AddWithValue("nname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("info", tbInfo.Text.Trim());
            /// 插入数据库
            try
            {
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('添加成功！')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('添加失败！" + ex.Message + "')", true);
            }
        }


        /// <summary>
        /// 初始化院信息显示
        /// </summary>
        protected void initControls()
        {
            tbDid.Items.Clear();
            tbDid.Items.AddRange(Yid.getYidItem());
            initB(tbDid.SelectedValue);
        }

        /// <summary>
        /// 初始化宿舍楼信息
        /// </summary>
        /// <param name="yid">院编号</param>
        protected void initB(string yid) {
            /// 先重置
            tbBid.Items.Clear();
            tbBid.Items.AddRange(Building.getItems(yid));
        }

        /// <summary>
        /// 更改院别后显示不同的宿舍楼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbDid_SelectedIndexChanged(object sender, EventArgs e)
        {
            initB(tbDid.SelectedValue);
        }
        
    }
}