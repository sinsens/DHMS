using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Base;
using System.Data.OleDb;

namespace DHMS.Roomgr
{
    public partial class ImportData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDownSample_Click(object sender, EventArgs e)
        {
            if (makeSample())
            {
                Response.Redirect("~/Uploads/导入宿舍信息样表.csv");
            }
        }

        /// <summary>
        /// 生成示例文件并返回文件路径提供下载
        /// </summary>
        /// <returns></returns>
        protected bool makeSample()
        {
            string path = "";
            /// 映射文件路径
            path = Server.MapPath("~/Uploads/导入宿舍信息样表.csv");
            /// 获取数据库相关表
            var data = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM T_Room;");
            data = SQL.ExecuteQuery(cmd);

            /// 列名
            string lname = "";
            for (var i = 0; i < data.Columns.Count; i++)
            {
                if (i < data.Columns.Count - 1)
                {
                    lname += data.Columns[i].ColumnName + ',';
                }
                else
                {
                    lname += data.Columns[i].ColumnName;
                }

            }


            try
            {
                CsvHelper.dt2csv(data, path, lname); // 导出
                return true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('发生错误！" + ex.Message + "')", true);
                return false;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /// 判断是否有文件且文件小于10Bytes
            if (!FileUpload1.HasFile || FileUpload1.FileBytes.LongLength <= 10)
            {
                msgBox.Show(this, "上传文件大小错误！应大于10个字节");
                return;
            }
            /// 先进行判断，如果当前数据不为空，则撤销导入
            var dt = new DataTable();
            if ( Room.Count() >= 1)
            {
                msgBox.Show(this,"当前数据表不为空，撤销导入！");
                return;
            }
            
            /// 设置临时文件名路径
            var path = Server.MapPath("~/Cache/files/temp_import_data.csv");
            try
            {
                FileUpload1.SaveAs(path);/// 保存临时文件
                /// 读取文件到DataTable

                dt = CsvHelper.csv2dt(path, dt);
                /// 更新数据库
                SQL.update("T_Room", dt);
                /// 删除临时文件
                FileInfo f = new FileInfo(path);
                f.Delete();

                msgBox.Show(this,"导入成功！");
            }
            catch (Exception ex)
            {
                msgBox.Show(this,"导入失败:"+ ex.Message);
            }

        }
    }
}