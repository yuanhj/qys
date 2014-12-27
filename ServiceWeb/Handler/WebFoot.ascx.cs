using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;

namespace ServiceWeb.Handler
{
    public partial class WebFoot : System.Web.UI.UserControl
    {
        private BLL.County bllcounty = new County();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Rpt_County.DataSource = bllcounty.GetAllList();
                //Rpt_County.DataBind();
            }
        }
    }
}