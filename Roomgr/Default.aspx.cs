using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using System.Data;
using System.Data.OleDb;


namespace DHMS.Roomgr
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initYid(); // 初始化院信息
            }
        }

        /// <summary>
        /// 初始化院别
        /// </summary>
        protected void initYid()
        {
            tbDid.Items.Add("全部");
            tbDid.Items.AddRange(Yid.getYidItem());
            initBid(tbDid.SelectedValue); // 初始化楼信息
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
                initBid(tbDid.SelectedValue); // 初始化宿舍楼
                initR(1, tbBid.SelectedValue); // 显示宿舍信息
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
            switch (i)
            {
                default: // 全部显示
                    GridView1.DataSource = Room.getDataTableAll();
                    break;
                case 1: // 按院刷选
                    if (id.Equals("全部"))
                    {
                        goto default;
                    }
                    else
                    {
                        GridView1.DataSource = Room.getDataTableByYid(id);
                    }
                    break;
                case 2: // 按楼刷选
                    if (id.Equals("全部"))
                    {
                        GridView1.DataSource = Room.getDataTableByYid(tbDid.SelectedValue);
                    }
                    else
                    {
                        GridView1.DataSource = Room.getDataTableByBid(id);
                    }
                    break;
            }
            GridView1.DataBind(); // 数据绑定
        }

        /// <summary>
        /// 初始化宿舍楼信息
        /// </summary>
        /// <param name="yid">院编号</param>
        protected void initBid(string yid)
        {
            /// 先重置
            tbBid.Items.Clear();
            tbBid.Items.Add("全部");
            tbBid.Items.AddRange(Building.getItems(yid));
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

        /// <summary>
        /// 宿舍统计
        /// </summary>
        /// <returns></returns>
        protected int countRoom()
        {
            return Room.Count();
        }
    }
}