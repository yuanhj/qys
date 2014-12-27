using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceWeb
{
    public partial class PostDetail : System.Web.UI.Page
    {
        BLL.Post post = new BLL.Post();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id =Convert.ToInt32(Request.QueryString["id"]);
                Binds(id);
            }
        }
        public void Binds(int id)
        {
            Bind_Post.DataSource = post.GetList("ID="+id);
            Bind_Post.DataBind();
        }
        public  string NewType(string str)
        {
            if(str!="")
            {
                switch (str)
                {
                    case "1":
                        return "服务动态";
                        break;
                    case "2":
                        return "服务政策";
                        break;
                    default:
                        return "服务动态";
                        break;
                       
                }
            }
            else
            {
                return "";
            }
        }
    }
}