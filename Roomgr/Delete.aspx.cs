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
    /// 删除宿舍信息
    /// bid:宿舍编号
    /// </summary>
    public partial class Delete: System.Web.UI.Page
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
            /// 更新数据库
            try
            {
                if (Room.Delete(Request["rid"]) >= 1)
                {
                    msgBox.Show(this,"删除成功！");
                }
                else
                {
                    msgBox.Show(this, "删除失败！");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this, "发生错误！"+ex.Message);
            }
        }


        /// <summary>
        /// 初始化页面显示
        /// </summary>
        protected void initControls()
        {
            DataRow dt;
            if (Request["rid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('未设置bid!请从查看页面(点击宿舍楼管理根节点)访问本页面！')", true);
                return;
            }
            else
            {
                dt = Room.getOne(Request["rid"]);
                if (dt==null||dt.IsNull(0))
                {
                    return;
                }
            }
            tbDid.Items.AddRange(Yid.getYidItem());
            /// 显示
            tbDid.Text = dt["院名称"].ToString();
            tbBid.Text =  dt["宿舍楼编号"].ToString();
            tbName.Text = dt["宿舍楼名称"].ToString();
        }
    }
}