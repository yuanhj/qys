using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using System.Data.SqlClient;

namespace ServiceWeb.Admin.zdompany
{
    public partial class UpdateCompany : System.Web.UI.Page
    {
        private BLL.EmphasisComPany company = new EmphasisComPany();
        private Model.EmphasisComPany mpany = new Model.EmphasisComPany();
        private BLL.CompanyType ctypes = new CompanyType();
        private string uid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = Request.QueryString["id"];
            if (!IsPostBack)
            {

                SqlDataReader sdr = ctypes.GetCompany();
                while (sdr.Read())
                {
                    ctype.Items.Add(new ListItem(sdr["Name"].ToString(), sdr["ID"].ToString()));
                }
                mpany = company.GetModel(Convert.ToInt32(uid));
                this.CName.Text = mpany.Name;
                if (!string.IsNullOrEmpty(mpany.LogoImg))
                {
                    litIogo.Text = "<a href='" + mpany.LogoImg + "' target='_blank'><img src='" + mpany.LogoImg +
                                   "' class='clogo' alt='' border='0' /></a>";
                }

                ctype.SelectedValue = ctype.Items.IndexOf(ctype.Items.FindByValue(mpany.CID.ToString())).ToString();
            }
        }
        protected void But_add_Click(object sender, EventArgs e)
        {
            mpany.ID = Convert.ToInt32(uid);
            mpany.Name = this.CName.Text.Trim();
            string filename = string.Empty;
            string logo = string.Empty;
            mpany.CID = Convert.ToInt32(ctype.SelectedValue);
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
            mpany.LogoImg = !string.IsNullOrEmpty(logo) ? logo : mpany.LogoImg;
            mpany.AddTime = DateTime.Now;

            company.Update(mpany);
            
        }
    }
}