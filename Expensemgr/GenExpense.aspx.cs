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
    public partial class GenExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["uid"]==null&&Session["role"]!="admin")
            {
                Session.Clear();
                Response.Redirect("~/");
            }
            */
            if (!IsPostBack)
            {
                initControls();
            }
        }

        /// <summary>
        /// 初始化院别
        /// </summary>
        protected void initControls()
        {
            tbDid.Items.Add("全部");
            tbDid.Items.AddRange(Yid.getYidItem());
            tbBid.Items.Add("全部");
            tbBid.Items.AddRange(Building.getItems(tbDid.SelectedValue));
        }

        /// <summary>
        /// 宿舍院别刷选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbDid_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbBid.Items.Clear();
            tbBid.Items.Add("全部");
            tbBid.Items.AddRange(Building.getItems(tbDid.SelectedValue));
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
                GridView1.DataSource = Record.getRecordByYid(tbDid.SelectedValue); // 按院别刷选
            }
            else
            {
                GridView1.DataSource = Record.getRecordByYid(tbBid.SelectedValue); // 按宿舍楼刷选
            }
            GridView1.DataBind();// 重新绑定
        }


        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            /// 判断刷选器
            if (!tbBid.Text.Equals("全部"))
            {
                GridView1.DataSource = Record.getRecordByYid(tbBid.SelectedValue); // 按宿舍楼刷选
            }
            else if (!tbDid.Text.Equals("全部"))
            {
                GridView1.DataSource = Record.getRecordByYid(tbDid.SelectedValue); // 按院别刷选
            }
            else
            {
                GridView1.DataSource = Record.getRecordByYid();
            }
            GridView1.DataBind(); // 数据绑定
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected int countRoom()
        {
            return Room.Count();
        }

    }
}