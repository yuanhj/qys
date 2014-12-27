using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ServiceWeb.Admin.Shuqiushouli
{
    public partial class SelectDemand : System.Web.UI.Page
    {
         BLL.Department dpt = new BLL.Department();
        BLL.DemandProfile dpf = new BLL.DemandProfile();
        Model.DemandProfile mdpf = new Model.DemandProfile();
        Model.Department mdpt = new Model.Department();
        BLL.Demands demands = new BLL.Demands();
        Model.Demands mdmands = new Model.Demands();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        
    
    }
}

