using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using System.Data;
using System.Data.OleDb;

namespace DHMS.DBuidingmgr
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initYidList();
                initControls();
            }

        }

        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            GridView1.DataSource = Building.getDataTable();
            GridView1.DataBind(); // 数据绑定
            if (GridView1.Rows.Count <= 0)
            {
                msgBox.Show(this,"数据库中没有找到相关记录！");
            }
        }

        /// <summary>
        /// 初始化院别List
        /// </summary>
        protected void initYidList()
        {
            tbDid.Items.Add("全部");
            tbDid.Items.AddRange(Yid.getYidItem());
        }


        /// <summary>
        /// 刷选宿舍院别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbDid_SelectedIndexChanged(object sender, EventArgs e)
        {
            setData(tbDid.SelectedValue);
        }


        /// <summary>
        /// 分页处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            setData(tbDid.SelectedValue);
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind(); // 数据绑定
        }

        /// <summary>
        /// 设置GridView的数据源
        /// </summary>
        /// <param name="key"></param>
        protected void setData(string key)
        {
            if (key.Equals("全部"))
            {
                initControls();
                return;
            }
            GridView1.DataSource = Building.getDataTable(tbDid.SelectedValue);
            GridView1.DataBind(); // 数据绑定
        }
    }

}