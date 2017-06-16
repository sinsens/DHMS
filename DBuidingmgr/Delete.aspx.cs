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
    /// 删除宿舍信息
    /// rid:宿舍编号
    /// </summary>
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControls();
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            /// 创建cmd
            OleDbCommand cmd = new OleDbCommand("DELETE FROM T_Room WHERE 宿舍楼编号=@bid;"); // 删除相关宿舍
            OleDbCommand cmd2 = new OleDbCommand("DELETE FROM T_Building WHERE 宿舍楼编号=@bid;"); // 删除目标宿舍楼
            cmd.Parameters.AddWithValue("bid", Request["bid"]);
            cmd2.Parameters.AddWithValue("bid", Request["bid"]);
            /// 插入数据库
            try
            {
                if ((SQL.ExecuteNonQuery(cmd) >= 1) & SQL.Execute(cmd2))
                {
                    msgBox.Show(this, "删除成功");
                }
                else
                {
                    msgBox.Show(this, "未知错误");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this,"发生错误:"+ex.Message);
            }
        }


        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            if (Request["bid"] == null)
            {
                msgBox.Show(this, "不存在该记录");
                return;
            }

            /// 院信息初始化

            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT top 1 * FROM 宿舍楼 WHERE 宿舍楼编号=@bid;");
            cmd.Parameters.AddWithValue("bid", Request["bid"]);
            dt = SQL.ExecuteQuery(cmd);
            if (dt == null || dt.Rows.Count <= 0)
            {
                msgBox.Show(this, "不存在该记录");
                return;
            }
            /// 显示
            lbYid.Text = dt.Rows[0]["院名称"].ToString();
            tbBid.Text = dt.Rows[0]["宿舍楼编号"].ToString();
            tbName.Text = dt.Rows[0]["宿舍楼名称"].ToString();

            /// 显示相关宿舍楼数量
            OleDbCommand cmd2 = new OleDbCommand("SELECT Count(宿舍编号) AS `数量` FROM T_Room WHERE 宿舍楼编号 = @bid;");
            cmd2.Parameters.AddWithValue("bid", Request["bid"]);
            dt.Reset();
            dt = SQL.ExecuteQuery(cmd2);
            if (dt == null || dt.Rows.Count <= 0)
            {
                msgBox.Show(this, "不存在该记录");
                return;
            }

            lbCount.Text = dt.Rows[0]["数量"].ToString();// 绑定宿舍数量
        }
    }
}