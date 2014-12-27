using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceWeb
{
    public partial class Neirong :Web.RequestBase
    {
        BLL.Post post = new BLL.Post();
        public string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            title= Request.QueryString["title"];
            if (title != "")
            {
                Binds(title);
            }
        }
        public void Binds(string title)
        {
            Bind_Post.DataSource = post.GetList("Subject='" + title + "' and Status>-1 and CountyID=" + CountyID);
            Bind_Post.DataBind();

            
        }
    }
}