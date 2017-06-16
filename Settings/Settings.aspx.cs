using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using System.Data;
using System.Data.OleDb;


namespace DHMS.Settings
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            ///未登录或不是管理员
            if (Session["uid"] == null || (!Session["role"].Equals("admin")))
            {
                Session.Clear();
                Response.Redirect("~/");
            }*/
            if (!IsPostBack)
            {
                initControls();
            }
        }

        /// <summary>
        /// 初始化控件显示
        /// </summary>
        protected void initControls()
        {
            DataRow dt = dbHelper.Config();
            if (dt == null || dt.IsNull(0))
            {
                return;
            }

            tbCr.Text = dt["冷水额度"].ToString();
            tbHr.Text = dt["热水额度"].ToString();
            tbDr.Text = dt["电力额度"].ToString();
            tbRecordMode.Items.FindByText(dt["记录模式"].ToString()).Selected = true;
            tbEnable.Checked = (bool)dt["优惠额度"];
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            /// 测试是否已有配置,有则更新
            OleDbCommand cmd;
            OleDbCommand t = new OleDbCommand("SELECT TOP 1 * FROM T_Config");
            var dt = SQL.ExecuteQuery(t);
            if ( dt!=null&&dt.Rows.Count>= 1)
            {
                cmd = new OleDbCommand("UPDATE T_Config SET 冷水额度=@cr,热水额度=@hr,电力额度=@dr,记录模式=@mode,优惠额度=@is_use;");
            }
            else
            {
                /// 无则插入
                cmd = new OleDbCommand("INSERT INTO T_Config(冷水额度,热水额度,电力额度,记录模式,优惠额度) VALUES(@cr,@hr,@dr,@mode,@is_use);");
            }

            cmd.Parameters.AddWithValue("cr", tbCr.Text);
            cmd.Parameters.AddWithValue("hr", tbHr.Text);
            cmd.Parameters.AddWithValue("dr", tbDr.Text);
            cmd.Parameters.AddWithValue("mode", tbRecordMode.Text);
            cmd.Parameters.AddWithValue("is_use", (bool)tbEnable.Checked);

            try
            {
                if (SQL.ExecuteNonQuery(cmd) >= 1)
                {
                    msgBox.Show(this, "保存成功");
                }
                else
                {
                    msgBox.Show(this, "未知错误");
                }
            }
            catch (Exception ex)
            {
                msgBox.Show(this, "发生错误:" + ex.Message);
            }

        }
    }
}