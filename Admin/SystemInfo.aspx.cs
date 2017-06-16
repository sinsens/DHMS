using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;

namespace DHMS.Admin
{
    public partial class SystemInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControls();
            }
        }

        /// <summary>
        /// 院别数量
        /// </summary>
        protected int YidCount { set; get; }
        /// <summary>
        /// 男生院别数量
        /// </summary>
        protected int YidCountM { set; get; }
        /// <summary>
        /// 女生院别数量
        /// </summary>
        protected int YidCountF { set; get; }
        /// <summary>
        /// 宿舍楼数量
        /// </summary>
        protected int BidCount { set; get; }
        protected int BidCountM { set; get; }
        protected int BidCountF { set; get; }
        protected int RidCount { set; get; }
        protected int RidCountM { set; get; }
        protected int RidCountF { set; get; }
        protected void initControls() {
            YidCount = Yid.Count();
            YidCountF = Yid.Count(1);
            YidCountM = Yid.Count(2);

            BidCount = Building.Count();
            BidCountF = Building.Count(2, 0);
            BidCountM = Building.Count(2, 1);

            RidCount = Room.Count();
            RidCountF = Room.Count(4, 0);
            RidCountM = Room.Count(4, 1);
        }
    }
}