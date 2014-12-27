using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Web;

namespace ServiceWeb.Admin.uploadbanner
{
    public partial class UpdateBannImg : System.Web.UI.Page
    {
        BLL.Demands demands = new BLL.Demands();
        BLL.BannerImg img = new BLL.BannerImg();
        Model.BannerImg mimg = new Model.BannerImg();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader drs = demands.DataReader();
                while (drs.Read())
                {
                    country.Items.Add(new ListItem(drs["Name"].ToString(), drs["ID"].ToString()));
                   
                }
                mimg = img.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if(mimg!=null)
                {
                    this.country.SelectedValue = country.Items.IndexOf(country.Items.FindByValue(mimg.CountyID.ToString())).ToString();
                    this.title.Text = mimg.Subject;
                    Imagelink.Text = mimg.ImageLinks;
                    txteditor.InnerText = mimg.Contents;
                    Drop_Status.SelectedValue = Drop_Status.Items.IndexOf(Drop_Status.Items.FindByValue(mimg.Status.ToString())).ToString();
                    if (!string.IsNullOrEmpty(mimg.ImagePath))
                    {
                        litIogo.Text = "<a href='" + mimg.ImagePath + "' target='_blank'><img src='" + mimg.ImagePath + "' class='clogo' alt='' border='0' /></a>";
                    }
                }
            }
        }

        protected void But_Update_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            string logo = string.Empty;
            if (fuLogo.HasFile)
            {
                string dictionary = "/uploadimg/" + DateTime.Now.ToString("yyyyMM");
                if (!Directory.Exists(Server.MapPath(dictionary)))
                {
                    Directory.CreateDirectory(Server.MapPath(dictionary));
                }
                filename = dictionary + "/" + System.Guid.NewGuid().ToString("N") +
                                  System.IO.Path.GetExtension(fuLogo.FileName).ToLower();
                fuLogo.SaveAs(Server.MapPath(filename));
                logo = filename;
            }
            mimg.ID = Convert.ToInt32(Request.QueryString["id"]);
            mimg.Subject = this.title.Text;
            mimg.CountyID =Convert.ToInt32( country.SelectedValue);
            mimg.ImagePath = !string.IsNullOrEmpty(logo) ? logo : img.GetModel(Convert.ToInt32(Request.QueryString["id"])).ImagePath;
            mimg.ImageLinks = Imagelink.Text;
            mimg.Contents = txteditor.InnerText;
            mimg.AddTime = System.DateTime.Now;
            mimg.Status =Convert.ToInt32(Drop_Status.SelectedValue);
            img.Update(mimg);
            Response.Redirect("BannerShow.aspx");

        }
    }
}