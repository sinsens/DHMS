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
    /// <summary>
    /// Request["bid"]:宿舍楼id
    /// bid：宿舍楼id
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
            if (Request["bid"] == null)
            {
                return;
            }

            /// 检测数据输入
            if (tbBid.Text.Length <= 0 || tbBid.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('数据输入有误，请重新输入！')", true);
                return;
            }
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("UPDATE T_Building SET 宿舍楼名称=@bname,院编号=@did,备注=@info WHERE 宿舍楼编号=@bid;");
            cmd.Parameters.AddWithValue("bname", tbName.Text.Trim());
            cmd.Parameters.AddWithValue("did", tbDid.SelectedValue);
            cmd.Parameters.AddWithValue("info", tbInfo.Text);
            cmd.Parameters.AddWithValue("bid", Request["bid"].ToString());
            try
            {
                /// 插入数据库
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    //Response.Redirect("./Modify.aspx?bid=" + tbBid.Text);
                    msgBox.Show(this, "修改成功!");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this, "修改失败!" + ex.Message);
            }

        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            if (Request["bid"] == null)
            {
                msgBox.Show(this,"未设置bid!请从查看页面(点击宿舍楼管理根节点)访问本页面！");
                return;
            }
            tbDid.Items.AddRange(Yid.getYidItem());
            
            DataRow dt = Building.getOne(Request["bid"]);
            if (dt == null || (dt.IsNull(0)))
            {
                msgBox.Show(this, "非法访问！");
                return;
            }
            /// 显示
            tbDid.Text = lbDid.Text = dt["院名称"].ToString();
            tbBid.Text = dt["宿舍楼编号"].ToString();
            tbName.Text = lbName.Text = dt["宿舍楼名称"].ToString();
            tbInfo.Text = dt["备注"].ToString();

        }
    }
}