using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using System.Data;
using System.Data.OleDb;


namespace DHMS.Recordmgr
{
    public partial class SetDefaultValues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initY(); // 初始化院信息
            }
        }

        /// <summary>
        /// 初始化院别
        /// </summary>
        protected void initY()
        {
            tbDid.Items.Add("全部");
            tbDid.Items.AddRange(Yid.getYidItem());
            initB(tbDid.SelectedValue); // 初始化楼信息
            initR(0, ""); // 显示所有宿舍信息
        }

        /// <summary>
        /// 宿舍院别刷选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbDid_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 显示全部
            if (tbDid.SelectedValue.Equals("全部"))
            {
                initR(0, "");
                return;
            }
            else
            {
                initB(tbDid.SelectedValue); // 初始化宿舍楼
                initR(1, tbDid.SelectedValue); // 显示宿舍信息
            }

        }

        /// <summary>
        /// 宿舍楼刷选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbBid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbBid.SelectedValue.Equals("全部"))
            {
                initR(1, tbDid.SelectedValue); // 按院刷选
            }
            else
            {
                initR(2, tbBid.SelectedValue); // 按宿舍楼刷选
            }
        }

        /// <summary>
        /// 显示筛选后的宿舍
        /// </summary>
        /// <param name="i">0:全部显示,1:按院刷选,2:按宿舍楼刷选</param>
        /// <param name="id"></param>
        protected void initR(int i, string id)
        {
            OleDbCommand cmd;
            var dt = new DataTable();

            switch (i)
            {
                default: // 全部显示
                    cmd = new OleDbCommand("SELECT * FROM 宿舍 ORDER BY 宿舍编号 DESC;");
                    break;
                case 1: // 按院刷选
                    if (id.Equals("全部"))
                    {
                        goto default;
                    }
                    else
                    {
                        cmd = new OleDbCommand("SELECT * FROM 宿舍 WHERE 院编号=@yid;");
                        cmd.Parameters.AddWithValue("yid", id);
                    }
                    break;
                case 2: // 按楼刷选
                    if (id.Equals("全部"))
                    {
                        cmd = new OleDbCommand("SELECT * FROM 宿舍 WHERE 院编号=@yid;");
                        cmd.Parameters.AddWithValue("yid", tbDid.SelectedValue);
                    }
                    else
                    {
                        cmd = new OleDbCommand("SELECT * FROM 宿舍 WHERE 宿舍楼编号=@bid;");
                        cmd.Parameters.AddWithValue("bid", id);
                    }
                    break;
            }
            GridView1.DataSource = SQL.ExecuteQuery(cmd);
            GridView1.DataBind(); // 数据绑定
        }

        /// <summary>
        /// 初始化宿舍楼信息
        /// </summary>
        /// <param name="yid">院编号</param>
        protected void initB(string yid)
        {
            /// 先重置
            tbBid.Items.Clear();
            tbBid.Items.Add("全部");
            tbBid.Items.AddRange(Building.getItems());
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            /// 判断刷选器
            if (!tbBid.Text.Equals("全部"))
            {
                initR(2, tbBid.SelectedValue);
            }
            else if (!tbDid.Text.Equals("全部"))
            {
                initR(2, tbBid.SelectedValue);
            }
            else
            {
                initR(0, null);
            }
            GridView1.DataBind(); // 数据绑定
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
    }
}