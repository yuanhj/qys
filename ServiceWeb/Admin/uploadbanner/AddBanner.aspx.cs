using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Web;

namespace ServiceWeb.Admin.uploadbanner
{
    public partial class AddBanner : System.Web.UI.Page
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
                country.Items.Insert(0, new ListItem("请选择...", "0"));
            }
        }
        protected void But_Add_Click(object sender, EventArgs e)
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

           
            if (title.Text != "" &&logo!="" &&txteditor.InnerText != "" && country.SelectedValue != "0")
            {
                mimg.Subject = title.Text;
                mimg.ImagePath = !string.IsNullOrEmpty(logo) ? logo : "";
                mimg.ImageLinks = Imagelink.Text;
                mimg.Contents = txteditor.InnerText;
                mimg.Status = 0;
                mimg.AddTime = System.DateTime.Now;
                mimg.CountyID = Convert.ToInt32(country.SelectedValue);
                img.Add(mimg);
                Response.Redirect("BannerShow.aspx");
            }
            else
            {
                Response.Write("<script>alert('信息填写不完整！')</script>");
            }
        }
    }
}