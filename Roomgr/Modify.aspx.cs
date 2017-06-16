using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Base;
using System.Data;

namespace DHMS.Roomgr
{
    /// <summary>
    /// Request["rid"]:宿舍编号
    /// rid：宿舍楼id
    /// did：院编号
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
            if (Request["rid"] == null)
            {
                return;
            }

            /// 检测数据输入
            if (tbName.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("UPDATE T_ROOM SET 宿舍名称=@bname,宿舍楼编号=@bid,备注=@info WHERE 宿舍编号=@rid;");
            cmd.Parameters.AddWithValue("bname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("bid", tbBid.Text); // 宿舍楼编号
            cmd.Parameters.AddWithValue("info", tbInfo.Text.Trim());
            cmd.Parameters.AddWithValue("rid", Request["rid"].ToString());
            try
            {
                /// 插入数据库
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    msgBox.Show(this, "修改成功！");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this, "修改失败:" + ex.Message);
            }

        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            /// 获取宿舍楼
            if (Request["rid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('未设置rid!请从查看页面(点击宿舍楼管理根节点)访问本页面！')", true);
                return;
            }

            /// 院信息初始化
            tbDid.Items.AddRange(Yid.getYidItem());


            /// 获取并显示宿舍信息
            DataRow dt = Room.getOne(Request["rid"]);
            if (dt == null || dt.IsNull(0))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('非法访问！')", true);
                return;
            }
            tbDid.SelectedValue = lbDid.Text = dt["院名称"].ToString();
            tbName.Text = lbName.Text = dt["宿舍名称"].ToString();
            tbInfo.Text = dt["备注"].ToString();
            lbBid.Text = dt["宿舍楼名称"].ToString();

            /// 获取并显示宿舍楼信息
            tbBid.Items.AddRange(Building.getItems()); // 添加到宿舍楼下拉选项
            tbBid.Items.FindByText(dt["宿舍楼名称"].ToString()).Selected = true;
        }

        /// <summary>
        /// 显示相关宿舍楼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbDid_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// 先重置
            tbBid.Items.Clear();
            tbBid.Items.AddRange(Building.getItems(tbDid.SelectedValue));
        }
    }
}